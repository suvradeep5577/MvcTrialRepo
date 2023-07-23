using MVCTrial.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTrial.BookRepositary
{
    public class LanRepositary : ILanRepositary
    {

        private readonly Context con = null;


        public LanRepositary()
        {
            con = new Context();
        }


        public List<Language> getLanguage()
        {
            var data = con.lang.Select(x => new Language()
            {
                ID = x.ID,
                text = x.text

            }).ToList();


            return data;
        }

    }
}
