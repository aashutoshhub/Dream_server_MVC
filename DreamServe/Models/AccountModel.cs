
using Microsoft.Build.Framework;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;

namespace DreamServe.Models
{
    public class AccountModel
    {

        //String connStr= @"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\'C:\\Users\\Awadhesh Gupta\\Documents\\dream.mdf\';Integrated Security=True;Connect Timeout=30";
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dreamServeDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

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

        //[Required]
        //[DisplayName("re-pass")]
        //public string re_pass { get; set; }




        //retrive data

        public List<AccountModel> getData()
        {
            List<AccountModel> lst = new List<AccountModel>();

            con.Open();

            SqlDataAdapter ad = new SqlDataAdapter("select * from registration_tbl", con);
            DataSet ds = new DataSet();
            ad.Fill(ds);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lst.Add(new AccountModel
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


        //insert data

        [HttpPost]
        public bool insert(AccountModel amm)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dreamServeDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into registration_tbl(name,email,password) values (@name,@email,@pass)", con);
            cmd.Parameters.AddWithValue("@name", amm.name);
            cmd.Parameters.AddWithValue("@email", amm.email);
            cmd.Parameters.AddWithValue("@pass", amm.pass);
            //cmd.Parameters.AddWithValue("@re_pass", amm.re_pass);
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


    }
}