using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemoLibrary
{
    class Auto: IRijden, IRijden2
    {
        public void IRijden.Rijden()
        {

        }

        public Boolean IRijden2.Gereden()
        {
            return false;
        }
    }
}
