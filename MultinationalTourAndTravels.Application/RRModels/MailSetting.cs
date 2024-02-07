using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Infrastructure.Model
{
    public sealed class EmailSetting
    {
        public List<string> To { get; set; } = null!;


        public List<string> CC { get; set; } = null!;


        public MailAddress From { get; set; } = null!;


        public string Subject { get; set; } = null!;


        public string Body { get; set; } = null!;


        public List<Attachment> Attachments { get; set; } = null!;
    }
}
