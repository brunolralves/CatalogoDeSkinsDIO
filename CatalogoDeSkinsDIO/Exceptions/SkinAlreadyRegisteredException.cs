using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeSkinsDIO.Exceptions
{
    public class SkinAlreadyRegisteredException : Exception
    {
        public SkinAlreadyRegisteredException() 
            :base("Esta skin já esta cadastrada")
        {
            
        }

    }
}
