using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICBrowser.Common
{
    public class EmailDetailsForUser
    {
        public string Email { get; set; }
        public int MessageId { get; set; }
        public Guid FromUserId { get; set; }
        public Guid ToUserId { get; set; }
        public string Subject { get; set; }
        public string MessageDescription { get; set; }
        public DateTime SentDate { get; set; }
        public Boolean Status { get; set; }
        public string toEmailAddress { get; set; }
        public string fromEmailAddress { get; set; }
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public int ParentId { get; set; }
        public string AttachedFile { get; set; }
    }
}
