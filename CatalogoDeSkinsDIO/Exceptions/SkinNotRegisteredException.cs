using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeSkinsDIO.Exceptions
{
    public class SkinNotRegisteredException : Exception
    {

        public SkinNotRegisteredException()
           : base("Esta skin não esta cadastrada")
        {

        }
    }
}
