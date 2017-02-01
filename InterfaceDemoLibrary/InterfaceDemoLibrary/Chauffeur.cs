using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemoLibrary
{
    class Chauffeur
    {
        public void TestMe()
        {
            IRijden rijden = new TestVoertuig();
            WilRijden(rijden);
        }
        public void WilRijden(IRijden voertuig)
        {
            voertuig.Rijden();
        }
    }
}
