using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

public partial class DBT_DistrictWiseEKYCData : System.Web.UI.Page
{
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindReport();
        }
    }
    void BindReport()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetEKYC_Report");
            objcls.storeProcedure.FieldName = "Type";
            objcls.storeProcedure.FieldValue = new object[] { 1};
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                gvdata.DataSource = dt;
                gvdata.DataBind();
            }
            
            gvdata.HeaderRow.Cells[0].Style["background-color"] = "#FFBE33";
            gvdata.HeaderRow.Cells[1].Style["background-color"] = "#FFBE33";
            gvdata.HeaderRow.Cells[2].Style["background-color"] = "#FFBE33";
            gvdata.HeaderRow.Cells[3].Style["background-color"] = "#FFBE33";
            foreach (GridViewRow row in gvdata.Rows)
            {
                foreach (TableCell cell in row.Cells)
                {
                    gvdata.Columns[0].ItemStyle.BackColor = Color.Goldenrod;
                    gvdata.Columns[1].ItemStyle.BackColor = Color.Aqua;
                    gvdata.Columns[2].ItemStyle.BackColor = Color.DarkOrange;
                    gvdata.Columns[3].ItemStyle.BackColor = Color.Coral;
                }
            }
        }
        catch (Exception ee)
        { }
    }
}