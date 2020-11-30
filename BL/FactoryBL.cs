using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class FactoryBL
    {
        protected FactoryBL() { }

        protected static IBL current = null;

        public static IBL GetBL()
        {
            if (current == null)
                current = new BL_basic();
            return current;
        }

    }
}
