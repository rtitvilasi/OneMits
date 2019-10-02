//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using OneMits.Data.Models;
//using Microsoft.AspNetCore.Identity.UI.Services;
//using Microsoft.AspNetCore.Authorization;
//using System.Threading.Tasks;
//using System.Text.Encodings.Web;
//using System.ComponentModel.DataAnnotations;
//using System.Data.SqlClient;
//using System;
//using System.Data;

//namespace OneMits.Controllers
//{
//    [AllowAnonymous]
//    public class OTPController : Controller
//    {
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly IEmailSender _emailSender;


//        public OTPController(UserManager<ApplicationUser> userManager, IEmailSender emailSender)
//        {
//            _userManager = userManager;
//            _emailSender = emailSender;
//        }

//        [BindProperty]
//        public InputModel Input { get; set; }

//        public class InputModel
//        {
//            [Required]
//            [EmailAddress]
//            public string User { get; set; }
//        }

//        protected void SearchByTagButton_Click(object sender, EventArgs e)
//        {

//            String strConn = @"Server=(localdb)\\mssqllocaldb;Database=OneMitsDatabase;Trusted_Connection=True;MultipleActiveResultSets=true";
//            SqlConnection conn = new SqlConnection(strConn);
//            conn.Open();
//            SqlCommand cmd = new SqlCommand("Select * FROM Patients WHERE Admin_ID = @admin_id and Admin_Password = @admin_password ", conn);
//            try
//            {

//                SqlParameter search = new SqlParameter();
//                search.ParameterName = "@admin_id";
//                search.ParameterName = "@admin_password";
//                search.Value = SearchByTagTB.Text.Trim();

//                cmd.Parameters.Add(search);
//                SqlDataReader dr = cmd.ExecuteReader();
//                DataTable dt = new DataTable();
//                dt.Load(dr);
//            }
//            catch (Exception)
//            {

//            }
//            conn.Close();

//        }

//        public async Task<IActionResult> OTPAsync()
//        {
//            var user = await _userManager.FindByNameAsync(Input.User);
//            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
//            {
//                // Don't reveal that the user does not exist or is not confirmed
//                return RedirectToPage("./ForgotPasswordConfirmation");
            
//            }

//            var Email1 = user.Email; 
//            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
//            var callbackUrl = Url.Page(
//                "/Account/ResetPassword",
//                pageHandler: null,
//                values: new { code },
//                protocol: Request.Scheme);

//            await _emailSender.SendEmailAsync(
//                Email1,
//                "Reset Password",
//                $"Click Here For MAke Password <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>Link</a>.");

//            return RedirectToPage("./Not_Matched");
//        }

//            return Page();
        

//    }
//}