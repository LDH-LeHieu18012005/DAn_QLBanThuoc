using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_batch
    {
        public BLL_batch() { }
        public DataTable GetDataBatch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return SqlDataAccess.GetDataFromTable("View_Batch_Details");
            }
            else
            {
                return SqlDataAccess.GetDataFromTable($"View_Batch_Details where name_medicine like N'%{keyword}%' OR medicine_is_active like N'%{keyword}%'");
            }
        }
        public int CreateBatch(int idMedicine, int quantityInBatch, decimal entryPrice, DateTime manufacturingDate, DateTime expiryDate, string status)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@IdMedicine", idMedicine },
                { "@QuantityInBatch", quantityInBatch },
                { "@EntryPrice", entryPrice },
                { "@ManufacturingDate", manufacturingDate },
                { "@ExpiryDate", expiryDate },
                { "@Status", status }
            };
            return SqlDataAccess.ExecuteProcedureWithOutput("Proc_AddBatch", parameters, "@IdBatch");
        }
        public DataRow GetRow(string id)
        {
            return SqlDataAccess.GetDataFromTable($"View_Batch_With_Medicine where id_batch = {id}").Rows[0];
        }
        public void UpdateBatch(int idBatch, int quantityInBatch, decimal entryPrice, DateTime manufacturingDate, DateTime expiryDate, string status, int quantityShortage, string note)
        {
            string command = $@"
            EXEC Proc_UpdateBatch 
                @IdBatch = {idBatch}, 
                @QuantityInBatch = {quantityInBatch}, 
                @EntryPrice = {entryPrice}, 
                @ManufacturingDate = '{manufacturingDate}', 
                @ExpiryDate = '{expiryDate}', 
                @Status = N'{status}', 
                @QuantityShortage = {quantityShortage}, 
                @Note = N'{note}'";
            SqlDataAccess.ExecuteNonQuery(command);
        }
        public void DeleteBatch(string id)
        {
            SqlDataAccess.ExecuteNonQuery($"Exec Proc_DeleteBatch '{id}'");
        }
    }
}