using Logen1986.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logen1986.API.Services
{
    public interface IMemberService
    {
        IEnumerable<Member> GetAll();
        Member GetById(int id);
    }
}