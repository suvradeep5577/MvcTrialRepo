using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTrial.Models
{
    public class UserEmailOption
    {
        public string Body { get; set; }

        public List<KeyValuePair<string,string>> Placeholders { get; set; }

        public string Subject { get; set; }
    }
}
