using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RevalsysCrudOperation
{
    public partial class ViewProductPradeep : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetProductPradeep();
                //SelectProductPradeep();
            }

        }

        private void GetProductPradeep()
        {
            string cs = "Data Source =PRADEEP-SAHOO56\\MSSQLSERVER1; Database=PradeepDB; Integrated Security=true";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("GetDataproductPradeep", con);
            con.Open();
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();
            con.Close();
        }

        

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string cs = "Data Source =PRADEEP-SAHOO56\\MSSQLSERVER1; Database=PradeepDB; Integrated Security=true";
            SqlConnection con = new SqlConnection(cs);
            string ProductName=txtProductName.Text;
            string Category = ddlCategory.Text;
            string ProductDescription=txtProductDescription.Text;
            decimal MRP=Convert.ToDecimal(txtMRP.Text);

            SqlCommand cmd=new SqlCommand("InsertproductPradeep", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductName", ProductName);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@ProductDescription", ProductDescription);
            cmd.Parameters.AddWithValue("@MRP", MRP);
            
            con.Open(); 
            cmd.ExecuteNonQuery();
            con.Close();

            IblMsg.Text = "Inserted Sucessfully....";
            GetProductPradeep();
            txtProductName.Text = "";
            ddlCategory.Text = "";
            txtProductDescription.Text = "";
            txtMRP.Text = "";
           
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ProductID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string cs = "Data Source =PRADEEP-SAHOO56\\MSSQLSERVER1; Database=PradeepDB; Integrated Security=true";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("DeleteproductPradeep", con);
            cmd.CommandType=System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productID", ProductID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GetProductPradeep();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GetProductPradeep();
            
           
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GetProductPradeep();
            
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int ProductID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string cs = "Data Source =PRADEEP-SAHOO56\\MSSQLSERVER1; Database=PradeepDB; Integrated Security=true";
            SqlConnection con = new SqlConnection(cs);
            string ProductName = (GridView1.Rows[e.RowIndex].FindControl("txtProductName")as TextBox).Text;
            string Category = (GridView1.Rows[e.RowIndex].FindControl("ddlCategory")as DropDownList).Text;
            string ProductDescription = (GridView1.Rows[e.RowIndex].FindControl("txtProductDescription")as TextBox).Text;
            decimal MRP = Convert.ToDecimal((GridView1.Rows[e.RowIndex].FindControl("txtMRP")as TextBox).Text);

            SqlCommand cmd = new SqlCommand("UpdateproductPradeep", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ProductName", ProductName);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@ProductDescription", ProductDescription);
            cmd.Parameters.AddWithValue("@MRP", MRP);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            IblMsg.Text = "Updated sucessfully";
            GridView1.EditIndex = -1;
            GetProductPradeep();
        }

        
    }
}