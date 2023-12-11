using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornie
{
    internal class Connect
    {
        public static DATABASE1Entities c;
        public static DATABASE1Entities context
        {
            get
            {
                if (c == null)
                    c = new DATABASE1Entities();
                return c;
            }
        }
    }
}
