using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuraevKursovoi
{
    class Helper
    {
        private static KompShopEntities s_Entities;
        public static KompShopEntities GetContext()
        {
            if(s_Entities == null)
            {
                s_Entities = new KompShopEntities();
            }
                return s_Entities;
        }       
    }
}
