using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeniorProjectClassLibrary.DAL;

namespace SeniorProjectClassLibrary.Classes
{
    public class Issue
    {
        private int id;
        private DateTime dateCreated;
        private string status;
        private DateTime? dateClosed;
        private string submittedBy;
        private string type;
        private string reply;
        private string title;
        private string description;

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public DateTime DateCreated
        {
            get
            {
                return dateCreated;
            }
            set
            {
                dateCreated = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public DateTime? DateClosed
        {
            get
            {
                return dateClosed;
            }
            set
            {
                dateClosed = value;
            }
        }

        public string SubmittedBy
        {
            get
            {
                return submittedBy;
            }
            set
            {
                submittedBy = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        public string Reply
        {
            get
            {
                return reply;
            }
            set
            {
                reply = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public static string saveIssue(Issue issue)
        {
            return IssueDA.saveIssue(issue);
        }

        public static Issue getIssue(int issueID)
        {
            return IssueDA.getIssue(issueID);
        }

        public static Issue updateIssue(Issue issue)
        {
            return IssueDA.updateIssue(issue);
        }
    }
}
