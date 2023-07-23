using MVCTrial.Data;
using System.Collections.Generic;

namespace MVCTrial.BookRepositary
{
    public interface ILanRepositary
    {
        List<Language> getLanguage();
    }
}