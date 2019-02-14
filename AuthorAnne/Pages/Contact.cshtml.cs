using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorAnne.Models;
using AuthorAnne.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthorAnne.Pages
{
    public class ContactModel : PageModel
    {
        public void OnGet()
        {
            FormSubmitted = false;
            EmailSent = false;
        }

        [BindProperty]
        public Contact Contact { get; set; }

        public bool FormSubmitted { get; set; }
        public bool EmailSent { get; set; }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                string EmailSubject;
                string EmailBody;

                EmailSubject = "Author Anne Contact Form";

                EmailBody =
                    @"
                    <html>
                    <head>
                    <title>" + EmailSubject + @"</title>
                    </head>
                    <body>
                    <table border=""0"" cellspacing=""0"" cellpadding=""6"">
                    <tr>
                    <td colspan=""4"">
                    <img border=""0"" src=""https://www.authoranne.co.uk/images/AuthorAnneLogoEmail.png"" alt=""Author Anne"" />
                    </td>
                    </tr>

                    <tr>
                    <td colspan=""4"">
                    <h2 style=""color: #d51f45;"">Personal Details</h2>
                    <hr stle=""border: 2px solid #1a9ead;"" />
                    </td>
                    </tr>

                    <tr>
                    <td>
                    Name
                    </td>
                    <td>
                    " + Contact.Name + @"
                    </td>
                    <td>
                    Telephone
                    </td>
                    <td>
                    <a href=""tel:" + Contact.Telephone + @""">" + Contact.Telephone + @"</a>
                    </td>
                    </tr>

                    <tr>
                    <td>
                    Email
                    </td>
                    <td colspan=""3"">
                    <a href=""mailto:" + Contact.Email + @"?subject=Website Enquiry"">" + Contact.Email + @"</a>
                    </td>
                    </tr>

                    <tr>
                    <td colspan=""4"">
                    <h2 style=""color: #b4ad17;"">Your Enquiry</h2>
                    <hr stle=""border: 2px solid #ebb90e;"" />
                    </td>
                    </tr>

                    <tr>
                    <td colspan=""4"">
                    " + Contact.Enquiry + @"
                    </td>
                    </tr>
                
                    <tr>
                    <td colspan=""4"">
                    <hr stle=""border: 2px solid #d51f45;"" />
                    <h3 style=""color: #1a9ead;"">Thanks for contacting authoranne.co.uk</h3>
                    <hr stle=""border: 2px solid #d51f45;"" />
                    </td>
                    </tr>

                    </table>
                    </body>
                    </html>";

                string EmailFrom = "anne.wilson@rwsservices.net";
                string EmailTo = "anne.wilson@rwsservices.net";

                FormSubmitted = true;
                EmailSent = Mailer.SendMail(EmailFrom, EmailTo, null, null, EmailSubject, EmailBody);
            }
        }
    }
}