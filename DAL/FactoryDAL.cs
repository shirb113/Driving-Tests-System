using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactoryDAL
    {
        protected FactoryDAL() { }

        protected static IDAL current = null;

        public static IDAL GetDal()
        {
            if (current == null)
                current = new DAL_XML_imp();
            return current;
        }

    }
}
