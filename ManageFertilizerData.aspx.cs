using System;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI;

public partial class ManageFertilizerData : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    public ManageFertilizerData()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (txtPasscode.Text.Trim() == "Dbt#@!123")
        {
            pnlPasscode.Visible = false;
            pnlStep.Visible = true;

        }
    }
    protected void btnBackup_Click(object sender, EventArgs e)
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_Fertilizer_Availabality_Backup");
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["r"]) == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Backup successfully created..!');", true);
                }
            }
        }
        catch(Exception ee)
        {

        }
    }
    protected void btnTruncate_Click(object sender, EventArgs e)
    {
        try
        {
            con.Close();
            con.Open();
            cmd = con.CreateCommand();
            string qry = @"Truncate table Fertilizer_Availabality";
            cmd.CommandText = qry;
            int result = 0;
            result = cmd.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Step 2 process done Successfully..!');", true);
            //if (result > 0)
            //{
            //    ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Step 2 process done Successfully..!');", true);
            //}
            con.Close();
        }
        catch(Exception ee)
        { }

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {

            //Upload and save the file
            string excelPath = Server.MapPath("~/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(excelPath);

            string conString = string.Empty;
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            switch (extension)
            {
                case ".xls": //Excel 97-03
                    conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    break;
                case ".xlsx": //Excel 07 or higher
                    conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                    break;

            }
            conString = string.Format(conString, excelPath);
            using (OleDbConnection excel_con = new OleDbConnection(conString))
            {
                excel_con.Open();
                string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                DataTable dtExcelData = new DataTable();

                //[OPTIONAL]: It is recommended as otherwise the data will be considered as String by default.
                dtExcelData.Columns.AddRange(new DataColumn[9] {
                new DataColumn("Rid", typeof(string)),
                 new DataColumn("DistName", typeof(string)),
                  new DataColumn("BlockName", typeof(string)),
                new DataColumn("MobileNo", typeof(string)),
            new DataColumn("RetailerName", typeof(string)),
                 new DataColumn("Comname", typeof(string)),
                  new DataColumn("ProductName", typeof(string)),
                new DataColumn("Stock", typeof(string)),
            new DataColumn("Product", typeof(string)),

                });

                using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                {
                    oda.Fill(dtExcelData);
                }
                Int32 rw = dtExcelData.Rows.Count;
                excel_con.Close();
                string consString = ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;

                using (SqlConnection conT = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(conT))
                    {
                        if (rw > 0)
                        {
                            //lblMsg.Text = rw + " Row Inserted";
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = "Fertilizer_Availabality";

                            //[OPTIONAL]: Map the Excel columns with that of the database table
                            // sqlBulkCopy.ColumnMappings.Add("Id", "PersonId");
                            sqlBulkCopy.ColumnMappings.Add("Rid", "Rid");
                            sqlBulkCopy.ColumnMappings.Add("DistName", "DistName");
                            sqlBulkCopy.ColumnMappings.Add("BlockName", "BlockName");
                            sqlBulkCopy.ColumnMappings.Add("MobileNo", "MobileNo");
                            sqlBulkCopy.ColumnMappings.Add("RetailerName", "RetailerName");
                            sqlBulkCopy.ColumnMappings.Add("Comname", "Comname");
                            sqlBulkCopy.ColumnMappings.Add("ProductName", "ProductName");
                            sqlBulkCopy.ColumnMappings.Add("Stock", "Stock");
                            sqlBulkCopy.ColumnMappings.Add("Product", "Product");
                            conT.Open();
                            sqlBulkCopy.WriteToServer(dtExcelData);
                            conT.Close();
                            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Step 3 process done Successfully . Data Saved ..!');", true);
                            BindData();
                        }
                    }
                }
            }
        }

        catch (Exception ee)
        { }

    }

    void BindData()
    {
        objcls.storeProcedure.NewStoreProcedure("SP_Fertilizer_Availabality_Data");
        DataTable dt = objcls.storeProcedure.getData();
        if(dt.Rows.Count>0)
        {
            gvView.DataSource = dt;
            gvView.DataBind();
        }
    }
}