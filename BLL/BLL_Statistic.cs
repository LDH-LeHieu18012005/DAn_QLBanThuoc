using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_Statistic
    {
        public DataTable Counts()
        {
            return SqlDataAccess.GetDataFromTable("View_Counts");
        }
        public DataTable TopSale()
        {
            DataTable dataTable = SqlDataAccess.GetDataFromTable("View_TopSale");
            DataView dataView = dataTable.DefaultView;
            dataView.Sort = "TotalQuantitySold DESC";
            DataTable top10Table = dataView.ToTable("TopSale", false, "MedicineName", "TotalQuantitySold", "TotalRevenue");
            if (top10Table.Rows.Count > 10)
            {
                while (top10Table.Rows.Count > 10)
                {
                    top10Table.Rows.RemoveAt(top10Table.Rows.Count - 1);
                }
            }
            return top10Table;
        }
        public DataTable GetData()
        {
            return SqlDataAccess.GetDataFromTable("View_BatchExpiryStatus");
        }
        public DataTable TKDoanhThu(int? month, int year)
        {
            string procedureCall = month.HasValue
                ? $"exec ThongKeDoanhThuTheoThangNam {month}, {year}"
                : $"exec ThongKeDoanhThuTheoThangNam NULL, {year}";
            return SqlDataAccess.GetDataFromProcedure(procedureCall);
        }
        public DataTable TKDoanhThuTheoQuy(int? quarter, int year)
        {
            string procedureCall = quarter.HasValue
                ? $"exec ThongKeDoanhThuTheoQuy {quarter}, {year}"
                : $"exec ThongKeDoanhThuTheoQuy NULL, {year}";
            return SqlDataAccess.GetDataFromProcedure(procedureCall);
        }
    }
}
