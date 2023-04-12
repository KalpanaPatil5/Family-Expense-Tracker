using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class Utilities
    {
        public static string GetConnectionString()
        {
            return @"data source=DESKTOP-ITV3G2A\SQLEXPRESS;initial catalog=Dec08;integrated security=sspi";
        }
    }
}
