using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OITReporting.Manager.DbModel
{
    public class clientDB
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=dbIOTReporting;Integrated Security=True");
        public List<clientMaster> ListAll()
        {
            List<clientMaster> lst = new List<clientMaster>();
            using (con)
            {

                con.Open();
                SqlCommand com = new SqlCommand("SelectClient", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new clientMaster
                    {
                        clientId = Convert.ToInt32(rdr["clientId"]),
                        userId = Convert.ToInt32(rdr["userId"]),
                        domainId = Convert.ToInt32(rdr["domainId"]),
                        status = rdr["status"].ToString(),
                        emailId = rdr["emailId"].ToString(),
                        companyName= rdr["companyName"].ToString(),
                        ContactPersonName = rdr["ContactPersonName"].ToString(),
                        ContactPersonDesignation = rdr["ContactPersonDesignation"].ToString(),
                        contactPersonContactNo1= Convert.ToDecimal(rdr["contactPersonContactNo1"]),
                        //contactPersonContactNo2=(decimal?)rdr["contactPersonContactNo2"],
                        //companyCellPhone=(decimal?)(rdr["companyCellPhone"] ),
                        address = rdr["address"].ToString(),
                        city = rdr["city"].ToString(),
                        state = rdr["state"].ToString(),
                        //counytryId = Convert.ToInt32(rdr["countryId"]),
                        isResponded = Convert.ToBoolean(rdr["isResponded"]),
                        isUnsubscribe = Convert.ToBoolean(rdr["isUnsubscribe"])

                    });
                }
                return lst;


            }
        }

        
    }
}
