using GenFu;
using Logen1986.API.Models;
using Logen1986.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logen1986.API.Service
{
    public class MemberService : IMemberService
    {
        List<Member> Members { get; set; }

        public MemberService()
        {
            var i = 0;
            Members = A.ListOf<Member>(50);
            Members.ForEach(person =>
            {
                i++;
                person.Id = i;
            });
        }

        public IEnumerable<Member> GetAll()
        {
            return Members;
        }

        public Member GetById(int id)
        {
            Console.WriteLine("Hello World!");
            return Members.First(_ => _.Id == id);
        }
    }
}
