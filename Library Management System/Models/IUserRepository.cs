using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public interface IUserRepository
    {
        Task<Member> CreateMember(Member member);
        Task<Member> UpdateMember(Member member);
        Task<Librarian> CreateLibrarian(Librarian librarian);
        Task<User> GetUserById(int userId);
        Task<Member> GetMemberById(int memberId);
        Task UpdateUser(User user);
        Task<List<Member>> GetMembersWithOutstandingFines();
    }
}
