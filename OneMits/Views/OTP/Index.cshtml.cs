using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OneMits.Models.OTP;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


    public partial class OTPModel : PageModel
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            GeneratePassword();
        }

        public string GeneratePassword()
        {
            string PasswordLength = "8";
            string NewPassword = "";
        string allowedChars = "1,2,3,4,5,6,7,8,9,0";
        allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedChars += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";


            char[] sep = {
            ','
        };
            string[] arr = allowedChars.Split(sep);


            string IDString = "";
            

            Random rand = new Random();

            for (int i = 0; i < Convert.ToInt32(PasswordLength); i++)
            {
               string temp = arr[rand.Next(0, arr.Length)];
                IDString += temp;
                NewPassword = IDString;

            }
            return NewPassword;
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            public string TextBox1 { get; set; }

            [Required]
            [EmailAddress]
            public string TxtEmail { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            // to save the username and password in database  
            SqlConnection con = new SqlConnection(@"Server=(localdb)\\mssqllocaldb;Database=OneMitsDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
            SqlCommand cmd = new SqlCommand("insert into Tbl_data(username,email) values (@username,@email)", con);
            cmd.Parameters.AddWithValue("Username", Input.TextBox1);
            cmd.Parameters.AddWithValue("Email", Input.TxtEmail);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();


           // to send the random password in email

            string strNewPassword = GeneratePassword().ToString();

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("Nishant4337@gamil.com");
            msg.To.Add(Input.TxtEmail);
            msg.Subject = "Random Password for your Account";
            msg.Body = "Your Random password is:" + strNewPassword;
            msg.IsBodyHtml = true;

            SmtpClient smt = new SmtpClient
            {
                Host = "smtp.gmail.com"
            };
            NetworkCredential ntwd = new NetworkCredential
            {
                UserName = "Nishant4337@gamil.com", //Your Email ID  
                Password = "" // Your Password  
            };
            smt.UseDefaultCredentials = true;
            smt.Credentials = ntwd;
            smt.Port = 587;
            smt.EnableSsl = true;
            smt.Send(msg);

        }
    }


