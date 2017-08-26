using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace OITReporting.Manager.DbModel
{
    public class userDB
    {
        public List<userMaster> ListAll()
        {
            List<userMaster> lst = new List<userMaster>();
            using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=dbIOTReporting;Integrated Security=True"))
            {
                
                    con.Open();
                    SqlCommand com = new SqlCommand("SelectUser", con);
                    com.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        lst.Add(new userMaster
                        {
                            userId = Convert.ToInt32(rdr["userId"]),
                            firstName = rdr["firstName"].ToString(),
                            lastName = rdr["lastName"].ToString(),
                            dob = Convert.ToDateTime(rdr["dob"]),
                            gender = rdr["gender"].ToString(),
                            address = rdr["address"].ToString(),
                            city = rdr["gender"].ToString(),
                            state = rdr["state"].ToString(),
                            countryId = Convert.ToInt32(rdr["countryID"]),
                            contactNo = Convert.ToInt32(rdr["contactNo"]),
                            emailID = rdr["emailID"].ToString(),
                            password = rdr["password"].ToString()

                        });
                    }
                    return lst;
                
                
            }
        }

        //Method for Adding an Employee
        public int Add(userMaster user)
        {
            int i;
            using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=dbIOTReporting;Integrated Security=True"))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdateUser", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@userID",user.userId);
                com.Parameters.AddWithValue("@firstName",user.firstName);
                com.Parameters.AddWithValue("@lastName", user.lastName);
                com.Parameters.AddWithValue("@dob", user.dob);
                com.Parameters.AddWithValue("@gender", user.gender);
                com.Parameters.AddWithValue("@address", user.address);
                com.Parameters.AddWithValue("@city", user.city);
                com.Parameters.AddWithValue("@state", user.state);
                com.Parameters.AddWithValue("@countryId", user.countryId);
                com.Parameters.AddWithValue("@contactNo", user.contactNo);
                com.Parameters.AddWithValue("@emailID", user.emailID);
                com.Parameters.AddWithValue("@password", user.password);
                com.Parameters.AddWithValue("@Action", "Insert");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Updating Employee record
        public int Update(userMaster user)
        {
            int i;
            using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=dbIOTReporting;Integrated Security=True"))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdateUser", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@userID", user.userId);
                com.Parameters.AddWithValue("@firstName", user.firstName);
                com.Parameters.AddWithValue("@lastName", user.lastName);
                com.Parameters.AddWithValue("@dob", user.dob);
                com.Parameters.AddWithValue("@gender", user.gender);
                com.Parameters.AddWithValue("@address", user.address);
                com.Parameters.AddWithValue("@city", user.city);
                com.Parameters.AddWithValue("@state", user.state);
                com.Parameters.AddWithValue("@countryId", user.countryId);
                com.Parameters.AddWithValue("@contactNo", user.contactNo);
                com.Parameters.AddWithValue("@emailID", user.emailID);
                com.Parameters.AddWithValue("@password", user.password);
                com.Parameters.AddWithValue("@Action", "Update");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Deleting an Employee
        public int Delete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=dbIOTReporting;Integrated Security=True"))
            {
                con.Open();
                SqlCommand com = new SqlCommand("DeleteUser", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@userId", ID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}
