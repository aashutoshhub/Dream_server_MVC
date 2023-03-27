using Microsoft.Build.Framework;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DreamServe.Models
{
    public class AdminModel
    {
        //String connStr= @"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\'C:\\Users\\Awadhesh Gupta\\Documents\\dream.mdf\';Integrated Security=True;Connect Timeout=30";
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dreamServeDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        [Required]
        [DisplayName("jobID")]
        public int jobID { get; set; }


        [Required]
        [DisplayName("companyname")]
        public string companyname { get; set; }

        [Required]
        [DisplayName("jobTitle")]
        public string jobTitle { get; set; }

        [Required]
        [DisplayName("applylink")]
        public string applylink { get; set; }
        
        [Required]
        [DisplayName("txtDescription")]
        public string txtDescription { get; set; }

        [Required]
        [DisplayName("inputDate")]
        public string inputDate { get; set; }

        //companyImageUrl
        [Required]
        [DisplayName("companyImageUrl")]
        public string companyImageUrl { get; set; }

        //
        [Required]
        [DisplayName("id")]
        public int id { get; set; }

        [Required]
        [DisplayName("name")]
        public string name { get; set; }

        [Required]
        [DisplayName("email")]
        public string email { get; set; }


        [Required]
        [DisplayName("pass")]
        public string pass { get; set; }


        //new Job 
        [HttpPost]
        public bool insert(AdminModel amm)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dreamServeDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into jobList_tbl(company_name,job_title,apply_link,description,last_date,company_image) " +
                       "values (@company_name,@job_title,@apply_link,@description,@last_date,@company_image)", con);
            cmd.Parameters.AddWithValue("@company_name", amm.companyname);
            cmd.Parameters.AddWithValue("@job_title", amm.jobTitle);
            cmd.Parameters.AddWithValue("@apply_link", amm.applylink);
            cmd.Parameters.AddWithValue("@description", amm.txtDescription);
            cmd.Parameters.AddWithValue("@last_date", amm.inputDate);
            cmd.Parameters.AddWithValue("@company_image", amm.companyImageUrl);


            int i = cmd.ExecuteNonQuery();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


     

        //Retrieve all records from a table
        public List<AdminModel> getData()
        {
            List<AdminModel> lst = new List<AdminModel>();

            con.Open();

            SqlDataAdapter ad = new SqlDataAdapter("select * from registration_tbl", con);
            DataSet ds = new DataSet();
            ad.Fill(ds);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lst.Add(new AdminModel
                {
                    id = Convert.ToInt32(dr["id"].ToString()),
                    name = dr["name"].ToString(),
                    email = dr["email"].ToString(),
                    pass = dr["password"].ToString(),
                    // re_pass = dr["re_pass"].ToString(),
                });
            }
            return lst;
        }


        //getJobListData
        public List<AdminModel> getJobListData()
        {
            List<AdminModel> lst = new List<AdminModel>();

            con.Open();

            SqlDataAdapter ad = new SqlDataAdapter("select * from jobList_tbl", con);
            DataSet ds = new DataSet();
            ad.Fill(ds);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lst.Add(new AdminModel
                {
                   
                    jobID = Convert.ToInt32(dr["jobID"].ToString()),
                    companyname = dr["company_name"].ToString(),
                    jobTitle = dr["job_title"].ToString(),
                    applylink = dr["apply_link"].ToString(),
                    txtDescription = dr["description"].ToString(),
                    inputDate = dr["last_date"].ToString(),
                    companyImageUrl = dr["company_image"].ToString(),
                });
            }
            return lst;
        }


    }
}
