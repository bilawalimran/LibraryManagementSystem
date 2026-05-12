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
        void DeleteMember(int id);
        List<Member> GetAllMembers();

    }
}
