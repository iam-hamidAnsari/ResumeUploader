using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace ResumeUploader
{
    public partial class Home : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cd = ConfigurationManager.ConnectionStrings["resume_con"].ConnectionString;
            conn = new SqlConnection(cd);
            conn.Open();

            if (!IsPostBack)
            { 
                additionalFields.Visible=false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {  
            string page = DropDownList1.SelectedValue.ToString();
            FileUpload1.SaveAs(Server.MapPath("resume/") + Path.GetFileName(FileUpload1.FileName));
            string file = "resume/" + Path.GetFileName(FileUpload1.FileName);

            if (page.Equals("Experienced"))
            {
                string q = $"exec for_experience '{TxtName.Text}','{TxtContct.Text}','{txtEmail.Text}','{DropDownList2.SelectedValue.ToString()}',{DropDownList1.SelectedValue.ToString()},'{file}',{int.Parse(txtExp.Text)},{int.Parse(txtNP.Text)},{int.Parse(txtCTC.Text)},{int.Parse(txtECTC.Text)}";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("mpoke1928@gmail.com");
                // Send the email to the sender's email
                mail.To.Add("ah91373244@gmail.com");
                mail.Subject = "New Application Received";

                // Add user details to the email body
                mail.Body = $"Hi HR,\n\nA new application has been received. Here are the details:\n" +
                            $"Name: {TxtName.Text}\n" +
                            $"Contact: {TxtContct.Text}\n" +
                            $"Email: {txtEmail.Text}\n" +
                            $"Position Applied: {DropDownList2.SelectedValue.ToString()}\n" +
                            $"Experience: {txtExp.Text} years\n" +
                            $"Notice Period: {txtNP.Text} days\n" +
                            $"Current CTC: {txtCTC.Text}\n" +
                            $"Expected CTC: {txtECTC.Text}\n\n" +
                            "Please find the CV attached.\n\nRegards,\nHR Dept";

                string resumeadd = "C:\\Users\\Ansari Hamid\\source\\repos\\ResumeUploader\\ResumeUploader\\" + file;

                Attachment cvAttachment = new Attachment(resumeadd);
                mail.Attachments.Add(cvAttachment);

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("mpoke1928@gmail.com", "dhfx widi jvps itnr"); // Add your email password here
                smtp.EnableSsl = true;
                smtp.Send(mail);


                MailMessage userMail = new MailMessage();
                userMail.From = new MailAddress("mpoke1928@gmail.com");
                userMail.To.Add(txtEmail.Text); // Send to the applicant's email
                userMail.Subject = "Thank You For Applying";
                userMail.Body = $"Hi {TxtName.Text},\n\nThank you for applying. We will let you know once your CV gets shortlisted.\n\nRegards,\nHR Dept";
                smtp.Send(userMail);

                Response.Write("<script>alert('Applied Successfully...')</script>");

            }
            else if (page.Equals("Fresher"))
            {
                string q = $"exec for_fresher '{TxtName.Text}','{TxtContct.Text}','{txtEmail.Text}','{DropDownList2.SelectedValue.ToString()}',{DropDownList1.SelectedValue.ToString()},'{file}'";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();
                Session["name"] = TxtName.Text;
                Session["email"] = txtEmail.Text;
                Response.Write("<script>window.location.href='InterviewSchedular.aspx'</script>");
            }
           
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Fresher")
            {
                additionalFields.Visible = false;
            }
            else if(DropDownList1.SelectedValue == "Experienced")
            {
                additionalFields.Visible = true;
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue == "others")
            {
                Response.Write("<script>alert('There is no oppenings for Non-IT Depts')</script>");
            }

        }
    }
}