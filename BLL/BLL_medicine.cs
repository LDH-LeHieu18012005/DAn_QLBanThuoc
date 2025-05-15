using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_medicine
    {
        public DataTable GetData(string keyword)
        {
            string cleanedKeyword = keyword?.Trim().Replace("'", "''") ?? "";
            string query = $"View_Full_Medicine_Info WHERE [name] LIKE N'%{cleanedKeyword}%' OR [type_name] LIKE N'%{cleanedKeyword}%'";
            DataTable result = SqlDataAccess.GetDataFromTable(query);
            return result;
        }

        public DataRow GetRecord(string id)
        {
            DataTable dt = SqlDataAccess.GetDataFromTable($"Medicine WHERE id_medicine = '{id}'");
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public DataTable GetMedicineTypes()
        {
            return SqlDataAccess.GetDataFromTable("Medicine_Type");
        }

        public void AddRecord(int? idType, string nameMedicine, string activeIngredient, string contraindication, string sideEffects, string unit, string isActive, string images)
        {
            string idTypeValue = idType.HasValue ? $"'{idType}'" : "NULL";
            string command = $"EXEC Proc_AddMedicine {idTypeValue}, N'{nameMedicine}', N'{activeIngredient}', N'{contraindication}', N'{sideEffects}', N'{unit}', '{isActive}', N'{images}'";
            SqlDataAccess.ExecuteNonQuery(command);
        }

        public void UpdateRecord(string id, int? idType, string nameMedicine, string activeIngredient, string contraindication, string sideEffects, string unit, decimal price, string isActive, string images)
        {
            string idTypeValue = idType.HasValue ? $"'{idType}'" : "NULL";
            string command = $"EXEC Proc_UpdateMedicine '{id}', {idTypeValue}, N'{nameMedicine}', N'{activeIngredient}', N'{contraindication}', N'{sideEffects}', N'{unit}', '{price}', '{isActive}', N'{images}'";
            SqlDataAccess.ExecuteNonQuery(command);
        }

        public void DeleteRecord(string id)
        {
            string command = $"EXEC Proc_DeleteMedicine '{id}'";
            SqlDataAccess.ExecuteNonQuery(command);
        }
    }
}
