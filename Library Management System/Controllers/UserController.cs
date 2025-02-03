using Library_Management_System.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Library_Management_System
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly ILogger<UserController> _logger;

        public UserController(
            IUserRepository userRepository,
            IAuthorizationService authorizationService,
            ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _authorizationService = authorizationService;
            _logger = logger;
        }

        #region Member Operations

        // GET: api/user/members
        [HttpGet("members")]
        public async Task<ActionResult<IEnumerable<Member>>> GetAllMembers()
        {
            var authorizationResult = await _authorizationService.AuthorizeAsync(
                User, null, UserOperations.ViewMember);

            if (!authorizationResult.Succeeded)
                return Forbid();

            try
            {
                var members = await _userRepository.GetAllMembers();
                return Ok(members);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving members: {ex.Message}");
                return StatusCode(500, "Internal server error while retrieving members");
            }
        }

        // GET: api/user/members/5
        [HttpGet("members/{id}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            var authorizationResult = await _authorizationService.AuthorizeAsync(
                User, null, UserOperations.ViewMember);

            if (!authorizationResult.Succeeded)
                return Forbid();

            try
            {
                var member = await _userRepository.GetMemberById(id);
                if (member == null)
                    return NotFound($"Member with ID {id} not found");

                return Ok(member);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving member: {ex.Message}");
                return StatusCode(500, "Internal server error while retrieving member");
            }
        }

        // POST: api/user/members
        [HttpPost("members")]
        public async Task<ActionResult<Member>> CreateMember(MemberCreateDto memberDto)
        {
            var authorizationResult = await _authorizationService.AuthorizeAsync(
                User, null, UserOperations.CreateMember);

            if (!authorizationResult.Succeeded)
                return Forbid();

            try
            {
                var member = new Member
                {
                    FirstName = memberDto.FirstName,
                    LastName = memberDto.LastName,
                    Email = memberDto.Email,
                    PhoneNumber = memberDto.PhoneNumber,
                    Address = memberDto.Address,
                    Username = memberDto.Username,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    MembershipStartDate = DateTime.UtcNow
                };

                var result = await _userRepository.CreateMember(member);
                return CreatedAtAction(nameof(GetMember), new { id = result.UserId }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating member: {ex.Message}");
                return StatusCode(500, "Internal server error while creating member");
            }
        }

        // PUT: api/user/members/5
        [HttpPut("members/{id}")]
        public async Task<ActionResult> UpdateMember(int id, MemberUpdateDto memberDto)
        {
            var authorizationResult = await _authorizationService.AuthorizeAsync(
                User, null, UserOperations.UpdateMember);

            if (!authorizationResult.Succeeded)
                return Forbid();

            try
            {
                var member = await _userRepository.GetMemberById(id);
                if (member == null)
                    return NotFound($"Member with ID {id} not found");

                // Update only provided fields
                if (memberDto.FirstName != null)
                    member.FirstName = memberDto.FirstName;
                if (memberDto.LastName != null)
                    member.LastName = memberDto.LastName;
                if (memberDto.Email != null)
                    member.Email = memberDto.Email;
                if (memberDto.PhoneNumber != null)
                    member.PhoneNumber = memberDto.PhoneNumber;
                if (memberDto.Address != null)
                    member.Address = memberDto.Address;

                await _userRepository.UpdateMember(member);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating member: {ex.Message}");
                return StatusCode(500, "Internal server error while updating member");
            }
        }

        // DELETE: api/user/members/5
        [HttpDelete("members/{id}")]
        public async Task<ActionResult> DeleteMember(int id)
        {
            var authorizationResult = await _authorizationService.AuthorizeAsync(
                User, null, UserOperations.DeleteMember);

            if (!authorizationResult.Succeeded)
                return Forbid();

            try
            {
                var member = await _userRepository.GetMemberById(id);
                if (member == null)
                    return NotFound($"Member with ID {id} not found");

                await _userRepository.DeleteMember(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting member: {ex.Message}");
                return StatusCode(500, "Internal server error while deleting member");
            }
        }

        #endregion

        #region Librarian Operations

        // GET: api/user/librarians
        [HttpGet("librarians")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<IEnumerable<Librarian>>> GetAllLibrarians()
        {
            try
            {
                var librarians = await _userRepository.GetAllLibrarians();
                return Ok(librarians);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving librarians: {ex.Message}");
                return StatusCode(500, "Internal server error while retrieving librarians");
            }
        }

        // GET: api/user/librarians/5
        [HttpGet("librarians/{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<Librarian>> GetLibrarian(int id)
        {
            try
            {
                var librarian = await _userRepository.GetLibrarianById(id);
                if (librarian == null)
                    return NotFound($"Librarian with ID {id} not found");

                return Ok(librarian);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving librarian: {ex.Message}");
                return StatusCode(500, "Internal server error while retrieving librarian");
            }
        }

        // POST: api/user/librarians
        [HttpPost("librarians")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<Librarian>> CreateLibrarian(LibrarianCreateDto librarianDto)
        {
            try
            {
                var librarian = new Librarian
                {
                    FirstName = librarianDto.FirstName,
                    LastName = librarianDto.LastName,
                    Email = librarianDto.Email,
                    PhoneNumber = librarianDto.PhoneNumber,
                    StaffId = librarianDto.StaffId,
                    Department = librarianDto.Department,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    HireDate = DateTime.UtcNow
                };

                var result = await _userRepository.CreateLibrarian(librarian);
                return CreatedAtAction(nameof(GetLibrarian), new { id = result.UserId }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating librarian: {ex.Message}");
                return StatusCode(500, "Internal server error while creating librarian");
            }
        }

        // PUT: api/user/librarians/5
        [HttpPut("librarians/{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> UpdateLibrarian(int id, LibrarianUpdateDto librarianDto)
        {
            try
            {
                var librarian = await _userRepository.GetLibrarianById(id);
                if (librarian == null)
                    return NotFound($"Librarian with ID {id} not found");

                // Update only provided fields
                if (librarianDto.FirstName != null)
                    librarian.FirstName = librarianDto.FirstName;
                if (librarianDto.LastName != null)
                    librarian.LastName = librarianDto.LastName;
                if (librarianDto.Email != null)
                    librarian.Email = librarianDto.Email;
                if (librarianDto.PhoneNumber != null)
                    librarian.PhoneNumber = librarianDto.PhoneNumber;
                if (librarianDto.Department != null)
                    librarian.Department = librarianDto.Department;

                await _userRepository.UpdateLibrarian(librarian);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating librarian: {ex.Message}");
                return StatusCode(500, "Internal server error while updating librarian");
            }
        }

        // DELETE: api/user/librarians/5 (Not Allowed)
        [HttpDelete("librarians/{id}")]
        public async Task<ActionResult> DeleteLibrarian(int id)
        {
            return StatusCode(403, "Deleting librarians is not permitted");
        }

        #endregion

        #region Additional Operations

        // GET: api/user/members/overdue
        [HttpGet("members/overdue")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<List<Member>>> GetMembersWithOverdueBooks()
        {
            try
            {
                var members = await _userRepository.GetMembersWithOverdueBooks();
                return Ok(members);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving members with overdue books: {ex.Message}");
                return StatusCode(500, "Internal server error while retrieving members with overdue books");
            }
        }

        // GET: api/user/members/search
        [HttpGet("members/search")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<IEnumerable<Member>>> SearchMembers([FromQuery] string searchTerm)
        {
            try
            {
                var members = await _userRepository.SearchMembers(searchTerm);
                return Ok(members);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error searching members: {ex.Message}");
                return StatusCode(500, "Internal server error while searching members");
            }
        }

        #endregion
    }
}
