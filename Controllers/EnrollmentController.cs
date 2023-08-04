

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc; 
using Advance_Form.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Advance_Form.Controllers
{
    public class EnrollmentController : Controller 
    {
        public string value = "";

        [HttpGet]
        public IActionResult Index() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Enroll e) 
        {
            if (Request.Method != "POST") 
            {
                return View();
            }
            Enroll er = new Enroll();
            using (SqlConnection con = new SqlConnection("Data Source=DIVAKAR\\SQLEXPRESS;Integrated Security=true;Initial Catalog=Sample"))
            {
                using (SqlCommand cmd = new SqlCommand("SP_EnrollDetail", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", e.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", e.LastName);
                    cmd.Parameters.AddWithValue("@Password", e.Password);
                    cmd.Parameters.AddWithValue("@Gender", e.Gender);
                    cmd.Parameters.AddWithValue("@Email", e.Email);
                    cmd.Parameters.AddWithValue("@Phone", e.PhoneNumber);
                    cmd.Parameters.AddWithValue("@SecurityAnwser", e.SecurityAnwser);
                    cmd.Parameters.AddWithValue("@status", "INSERT");
                    con.Open();
                    ViewData["result"] = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return View();
        }
    }
}