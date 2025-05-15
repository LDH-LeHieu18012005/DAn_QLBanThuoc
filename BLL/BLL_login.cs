using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_login
    {
        public DataTable GetNV()
        {
            return SqlDataAccess.GetDataFromTable("Staff");
        }
    }
}
