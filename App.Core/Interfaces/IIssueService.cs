using App.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Interfaces
{
    public interface IIssueService 
    {
        void IssueBook(IssueRecord issue);
        void ReturnBook(int issueId);
        List<IssueRecord> GetAllIssues();

    }
}
