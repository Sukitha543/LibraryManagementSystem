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
    public class UserController
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<ActionResult<Member>> CreateMember(MemberCreateDto memberDto)
        {
           
        }

        public async Task<ActionResult<Member>> UpdateMember(int id, MemberUpdateDto memberDto)
        {
           
        }

        public async Task<ActionResult<Librarian>> CreateLibrarian(LibrarianCreateDto librarianDto)
        {
           
        }

        public async Task<ActionResult> DeactivateUser(int userId)
        {
           
        }

        public async Task<ActionResult<List<Member>>> GetOverdueMembersWithFines()
        {
           
        }
    }
}
