using App.Core.Models;
using App.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Interfaces
{
    public interface IIssueService
    {
        void IssueBook(IssueRecord issue);
        void ReturnBook(string issueId, DateTime? returnDate = null);
        void UpdateStatus(string issueId, IssueStatus status);
        void DeleteIssue(string issueId);
        List<IssueRecord> GetAllIssues();
        List<IssueRecord> SearchIssues(string keyword);

    }
}