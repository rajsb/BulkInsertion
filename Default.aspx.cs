using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InsertEmpIDToVIPList
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

             List<string> ListUID = new List<string>();
             List<string> ListempFName = new List<string>();
             string[] empUIDs = {
                                    
                                    "615772",
                                    "629826",
                                    "825653"
            };

             string[] empFName = { 

                                     "Raj, 
                                     "Rahul", 
                                     "Crazy" 
                                 
             };
             ListUID.AddRange(empUIDs);
             ListempFName.AddRange(empFName);

            string connectionString = null;
            connectionString = "Data Source=RAJKUMARSB;Database=Training_2017;Integrated Security = true; Connection Timeout=3600;Max Pool Size=100;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("usp_InsertEmpIDToVIPUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    for(int index=0;index<ListUID.Count;index++)
                    {
                        cmd.Parameters.Add("@EmpUID", SqlDbType.VarChar).Value = ListUID[index];
                        cmd.Parameters.Add("@EmpFName", SqlDbType.VarChar).Value = ListempFName[index];
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    //foreach ( var EmpUID in ListUID)
                    //{
                    //cmd.Parameters.Add("@EmpUID", SqlDbType.VarChar).Value = EmpUID;
                    //cmd.ExecuteNonQuery();
                    //cmd.Parameters.Clear();
                    //}             
                    con.Close();
                }
            }
        }
    }
}

