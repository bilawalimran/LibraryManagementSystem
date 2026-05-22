using App.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Interfaces
{
    public interface IIssueService 
    {
        void IssueBook(IssueRecord issue);
        void ReturnBook(string issueId);
        void ReturnBook(string issueId, DateTime returnDate);
        void DeleteIssue(string issueId);
        List<IssueRecord> GetAllIssues();

    }
}
