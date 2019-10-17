using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Minuto_Seguro.Model;

namespace Test_Minuto_Seguro.Interfaces
{
    public interface IFormatDataXml
    {
        BlogMinutoXml GetWordsHighestRelevanceByPostAndTotal(BlogMinutoXml xml);
    }
}
