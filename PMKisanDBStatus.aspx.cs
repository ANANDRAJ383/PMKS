using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PMKisanDBStatus : System.Web.UI.Page
{
    clsDataAccessPMKisanNew objcls = new clsDataAccessPMKisanNew();
    int total = 0;
    protected void Page_Load(object sender, EventArgs e)
    {  if(!IsPostBack)
        {
            BindData();
        }
        
    }
    #region Function&Method

    void BindData()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetDistrictWiseCount");
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
            }
        }
        catch
        { }
    }

    #endregion

    protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                total = total + Convert.ToInt32(e.Row.Cells[2].Text);
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[2].Text = total.ToString();
            }
        }
        catch(Exception ee)
        { }
    }
}