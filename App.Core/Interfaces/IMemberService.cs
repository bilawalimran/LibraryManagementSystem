using App.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Interfaces
{
    public interface IMemberService
    {
        void AddMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(string id);
        List<Member> GetAllMembers();

    }
}
