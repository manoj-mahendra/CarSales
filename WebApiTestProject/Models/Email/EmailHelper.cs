﻿using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks; 

namespace WebApiTestProject.Models
{
    public class EmailHelper
    {
        public static readonly string EMAIL_SENDER = "abc@gmail.com"; // change it to actual sender email id or get it from UI input  
        public static readonly string EMAIL_CREDENTIALS = "password"; // Provide credentials   
        public static readonly string SMTP_CLIENT = "smtp.gmail.com";//"smtp-mail.outlook.com"; // as we are using outlook so we have provided smtp-mail.outlook.com   
        public static readonly string EMAIL_BODY = "Reset your Password <a href='http://{0}.safetychain.com/api/Account/forgotPassword?{1}'>Here.</a>";
        public static readonly string EMAIL_SUBJECT = "Report of stocks archived today";

        private string senderAddress;  
        private string clientAddress;  
        private string netPassword;
        public EmailHelper(string sender, string Password, string client)  
        {  
            senderAddress = sender;  
            netPassword = Password;  
            clientAddress = client;  
        }  
        public bool SendEMail(string recipient, string subject, string message)  
        {  
            bool isMessageSent = false;  
            //Intialise Parameters  
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(clientAddress);  
            client.Port = 587;  
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;  
            client.UseDefaultCredentials = false;  
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(senderAddress, netPassword);  
            client.EnableSsl = true;  
            client.Credentials = credentials;  
            try  
            {  
                var mail = new System.Net.Mail.MailMessage(senderAddress.Trim(), recipient.Trim());  
                mail.Subject = subject;  
                mail.Body = message;  
                mail.IsBodyHtml = true;  
                //System.Net.Mail.Attachment attachment;  
                //attachment = new Attachment(@"C:\Users\XXX\XXX\XXX.jpg");  
                //mail.Attachments.Add(attachment);  
                client.Send(mail);  
                isMessageSent = true;  
            }  
            catch(Exception ex)  
            {  
                isMessageSent = false;  
            }  
            return isMessageSent;  
        }  
    }
}