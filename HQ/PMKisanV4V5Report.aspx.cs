using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;
using System.IO;

public partial class ADM_PMKisanReport : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    clsDataAccessNew clsNew = new clsDataAccessNew();
    protected void Page_Load(object sender, EventArgs e)
    {

        BindDataV4();
    }

    void BindDataV4()
    {
        try
        {
            string QUERY = @"select Districtname,count(*) TotalFarmers from  Registration_PMKISAN_New 
                             where LandMutationDate is  null and CO_Status=1 and ADMR_Status=1 and XMLStatus is null
                             group by Districtname
                             order by Districtname";
            DataTable dt = clsNew.GetDataTable(QUERY);
            if (dt.Rows.Count>0)
            {
                GridV4.DataSource = dt;
                GridV4.DataBind();
                GridV4.Visible = true;

            }

            string QUERYv5 = @"select d.DistName,count(*) TotalFarmers1 from  tbl_PMKisan_LandSeeding_No l
                             inner join Districts d on d.DistCode=l.Distcode 
                             where LandMutationDate is  null and dataReturnDate is not null and XMLStatusNew is null
                             group by d.DistName
                             order by d.DistName";
            DataTable dtv5 = clsNew.GetDataTable(QUERYv5);
            if (dtv5.Rows.Count > 0)
            {
                GridV5.DataSource = dtv5;
                GridV5.DataBind();
                GridV5.Visible = true;

            }

        }
        catch(Exception ex)
        {

        }
    }
   
}