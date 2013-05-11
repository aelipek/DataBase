using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
namespace WebService_DataShow
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Service1 : System.Web.Services.WebService
    {
        [WebMethod]
        public DataSet datashow(string urunID)
        {
            SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog = eticaret; Integrated Security=True");
            con.Open();
            string sorgu = String.Format("select * from tUrunler where urunID = '{0}'", urunID);
            SqlDataAdapter da = new SqlDataAdapter(sorgu, con);
            da.SelectCommand.ExecuteNonQuery();
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }
    }
}
