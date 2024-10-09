using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResumeUploader
{
    public partial class InterviewSchedular : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Label1.Text = Session["name"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = Session["name"].ToString();
            string senderMail = Session["email"].ToString();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("mpoke1928@gmail.com");
            mail.To.Add($"{senderMail}");
            mail.Subject = "Interview Scheduled - Please Confirm";
            mail.Body = $"Hi {name}, \n\n We are pleased to inform you that your interview has been scheduled!\nTime:{DropDownList1.SelectedValue.ToString()} \n\nRegards,\nHR dept ";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("mpoke1928@gmail.com", "dhfx widi jvps itnr");
            smtp.EnableSsl = true;
            smtp.Send(mail);
            Response.Write("<script>alert('Interview Scheduled Succussfully...'); window.location.href='Home.aspx'</script>");

        }
    }
}