using System;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class HQ_UDEKYC : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();

    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
BindTable();
    }

    public HQ_UDEKYC()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conPMKISANDB"].ConnectionString; //conPMKISANDB
    }
    void BindTable()
    {
        string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";
        DataTable dt = new DataTable();
        SqlDataAdapter chkadpp = new SqlDataAdapter();
        cmd.Connection = con;
        cmd.CommandText = query;
        chkadpp.SelectCommand = cmd;
        chkadpp.Fill(dt);
        ddlTable.DataSource = dt;
        ddlTable.DataTextField = "TABLE_NAME";
        //  ddlTable.DataValueField = "distcode";
        ddlTable.DataBind();
        ddlTable.Items.Insert(0, new ListItem("--Select --", "0"));

        ddlTable.SelectedItem.Text = "tbl_NewData_eKYC_300523";
    }
    protected void Upload(object sender, EventArgs e)
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
            dtExcelData.Columns.AddRange(new DataColumn[8] {
                new DataColumn("PMKisanId", typeof(string)),
                 new DataColumn("FarmerName", typeof(string)),
                  new DataColumn("StateName", typeof(string)),
                new DataColumn("DistrictName", typeof(string)),
            new DataColumn("SubDistrictName", typeof(string)),
                 new DataColumn("BlockName", typeof(string)),
                  new DataColumn("VillageName", typeof(string)),
                new DataColumn("MobileNo", typeof(string))

                });

            using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
            {
                oda.Fill(dtExcelData);
            }
            Int32 rw = dtExcelData.Rows.Count;
            excel_con.Close();
            string consString = ConfigurationManager.ConnectionStrings["conPMKISANDB"].ConnectionString;

            using (SqlConnection conT = new SqlConnection(consString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(conT))
                {
                    if (rw > 0)
                    {
                        lblMsg.Text = rw + " Row Inserted";
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = ddlTable.SelectedItem.Text;

                        //[OPTIONAL]: Map the Excel columns with that of the database table
                        // sqlBulkCopy.ColumnMappings.Add("Id", "PersonId");
                        sqlBulkCopy.ColumnMappings.Add("PMKisanId", "PMKisanId");
                        sqlBulkCopy.ColumnMappings.Add("FarmerName", "FarmerName");
                        sqlBulkCopy.ColumnMappings.Add("StateName", "StateName");
                        sqlBulkCopy.ColumnMappings.Add("DistrictName", "DistrictName");
                        sqlBulkCopy.ColumnMappings.Add("SubDistrictName", "SubDistrictName");
                        sqlBulkCopy.ColumnMappings.Add("BlockName", "BlockName");
                        sqlBulkCopy.ColumnMappings.Add("VillageName", "VillageName");
                        sqlBulkCopy.ColumnMappings.Add("MobileNo", "MobileNo");
                        conT.Open();
                        sqlBulkCopy.WriteToServer(dtExcelData);
                        conT.Close();
                    }
                }
            }
        }
    }
}