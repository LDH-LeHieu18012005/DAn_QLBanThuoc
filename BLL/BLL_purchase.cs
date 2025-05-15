using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_purchase
    {
        public BLL_purchase() { }
        public DataTable GetDataPurchase(string keyword)
        {
            return SqlDataAccess.GetDataFromTable($"View_Purchase_Invoice_Details where name_supplier like N'%{keyword}%' OR name_staff like N'%{keyword}%'");
        }
        public DataTable GetSupplier()
        {
            return SqlDataAccess.GetDataFromTable("Supplier");
        }
        public DataTable GetStaff()
        {
            return SqlDataAccess.GetDataFromTable("Staff");
        }
        public DataTable GetMedicine()
        {
            return SqlDataAccess.GetDataFromTable("Medicine");
        }
        public void CreatePurchaseInvoice(DateTime dateCreate, int idSupplier, int idStaff, decimal totalAmount)
        {
            string command = $"exec Proc_AddPurchaseInvoice '{idStaff}', '{idSupplier}', '{dateCreate}', '{totalAmount}'";
            SqlDataAccess.ExecuteNonQuery(command);
        }

        public void CreatePurchaseDetail(int idPurchase, int idBatch)
        {
            string sqlCommand = $"EXEC Insert_Purchase_Details @id_purchase = {idPurchase}, @id_batch = {idBatch}";
            SqlDataAccess.ExecuteNonQuery(sqlCommand);
        }
        public void DeletePurchaseInvoice(int idPurchase)
        {
            string sqlCommand = $"EXEC Proc_DeletePurchaseInvoice @IdPurchase = {idPurchase}";
            SqlDataAccess.ExecuteNonQuery(sqlCommand);
        }

        public DataTable GetDataBatchID(string id)
        {
            return SqlDataAccess.GetDataFromTable($"View_Batch_Purchase_Details where id_purchase = '{id}'");
        }
        public DataRow GetRow(string id)
        {
            return SqlDataAccess.GetDataFromTable($"View_Purchase_Invoice_Details where id = {id}").Rows[0];
        }
        public string GetIDHDN()
        {
            return SqlDataAccess.GetDataFromProcedure("SELECT TOP 1 id_purchase \r\nFROM Purchase_Invoice \r\nORDER BY id_purchase DESC;\r\n").Rows[0][0].ToString();
        }
    }   
}
