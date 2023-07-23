using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTrial.Data
{
    public class books
    {
        public int ID { get; set; }
        public string author { get; set; }
        public string title { get; set; }

        public string Email { get; set; }

        
        public string Language { get; set; }

        // public int Language { get; set; }

        public string ImagePath { get; set; }
    }
    
}
