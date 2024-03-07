using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class DBT_Drought1819status : System.Web.UI.Page
{
    clsDataAccess cls = new clsDataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void btnShow_Click(object sender, EventArgs e)
    {
          try
        {

            string query = @"SELECT *  FROM DryCropy_OnlineApplyMaster p 
                                     WHERE p.Registrationid='" + txtRegId.Text.Trim() + "' and reconsider in (1,3)";
            DataTable dt = cls.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                lblAppId.Text = dt.Rows[0]["ApplicationId"].ToString();
                lblAppName.Text = dt.Rows[0]["FarmerName"].ToString();
                string q = @"select * from Dry_HDFC_PayDetails where Application_Id='"+ lblAppId.Text.Trim() + "'";
                DataTable dtq = cls.GetDataTable(q);
                if (dtq.Rows.Count > 0)
                {
                    int code = Convert.ToInt32(dtq.Rows[0]["code"].ToString());
                   // decimal amount=Convert.ToDecimal()
                    if (code == 0)
                    {
                        lblMsg.Text = "";
                    }
                    else
                    {
                        lblMsg.Text = dt.Rows[0]["FarmerName"].ToString() + ",दिनांक " + dtq.Rows[0]["actiondate"].ToString() + " को राशि " + dtq.Rows[0]["11"].ToString() + " आपके आधार लिंक खाते में भेजा गया था,परन्तु आधार एवं बैंक का NPCI लिंक नहीं रहने के कारण राशि हस्तांतरित नहीं हो पाया|अब योजना समाप्त हो गई है | ";
                    }
                }
                
            }
            else
            {
                lblMsg.Text = "यह आवेदन संख्या से कोई पुनर्विचार आवेदन नहीं हुआ है , या आवेदन संख्या गलत है |";
            }

        }
        catch (Exception ee)
        { }
    }

}