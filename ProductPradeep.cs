using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace RevalsysCrudOperation
{
    public class ProductPradeep
    {
        SqlCommand cmd=new SqlCommand();
        SqlConnection con;
        public ProductPradeep()
        {
            con = new SqlConnection("PradeepDB");
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

        }
        public DataSet Product_Select(int? ProductID, bool? Status)
        {
            DataSet ds;
            try
            {
                cmd.CommandText = "Product_Select";
                cmd.Parameters.Clear();
                if (ProductID != null && Status == null)
                    cmd.Parameters.AddWithValue("@ProductID", ProductID);
                else if (ProductID == null && Status != null)
                    cmd.Parameters.AddWithValue("@Status", Status);
                else if (ProductID != null && Status != null)
                {
                    cmd.Parameters.AddWithValue("@Custid", ProductID);
                    cmd.Parameters.AddWithValue("@Status", Status);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "ProductID");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Product_Update(int? Custid, string Name, decimal? Balance, string City)
        {
            int Count = 0;
            try
            {
                cmd.CommandText = "Product_Update";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Custid", Custid);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Balance", Balance);
                cmd.Parameters.AddWithValue("@City", City);
                con.Open();
                Count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return Count;
        }


    }
}