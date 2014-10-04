using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace LibChess
{
    public class Register : Component
    {
        // All the fields that are needed
        private MailAddress mMailFrom;
        private MailAddress mMailTo;
        private string mMailSubject;
        private string mMailBody;
        private string mSMTPServer;
        private int mSMTPPort;
        private string mSMTPUsername;
        private string mSMTPPassword;
        private bool mSMTPSSL;
        private MailMessage MailObject;
        private string message;
        private string userPassword;

        public string Message
        {
            set { message = value; }
            get { return message; }
        }

        public string UserPassword
        {
            set { userPassword = value; }
            get { return userPassword; }
        }

        // Properties
        public MailAddress MailFrom
        {
            set { mMailFrom = value; }
            get { return mMailFrom; }
        }
        public MailAddress MailTo
        {
            set { mMailTo = value; }
            get { return mMailTo; }
        }
        public string MailSubject
        {
            set { mMailSubject = value; }
            get { return mMailSubject; }
        }
        public string MailBody
        {
            set { mMailBody = value; }
            get { return mMailBody; }
        }
        public string SMTPServer
        {
            set { mSMTPServer = value; }
            get { return mSMTPServer; }
        }
        public int SMTPPort
        {
            set { mSMTPPort = value; }
            get { return mSMTPPort; }
        }
        public string SMTPUsername
        {
            set { mSMTPUsername = value; }
            get { return mSMTPUsername; }
        }
        public string SMTPPassword
        {
            set { mSMTPPassword = value; }
            get { return mSMTPPassword; }
        }
        public Boolean SMTPSSL
        {
            set { mSMTPSSL = value; }
            get { return mSMTPSSL; }
        }


        // Functions
        public Boolean Send()
        {
            // build the email message
            MailMessage Email = new MailMessage();
            MailAddress MailFrom = mMailFrom;
            Email.From = MailFrom;
            try { Email.To.Add(mMailTo); }
            catch (Exception e) { }

            Email.Subject = mMailSubject;
            Email.Body = mMailBody;

            // Smtp Client
            SmtpClient SmtpMail =
             new SmtpClient(mSMTPServer, mSMTPPort);
            SmtpMail.Credentials =
             new NetworkCredential(mSMTPUsername, mSMTPPassword);
            SmtpMail.EnableSsl = mSMTPSSL;

            Boolean bTemp = true;
            try
            {
                message = "The password has been sent to your email";
                SmtpMail.Send(Email);
                return true;
            }
            catch (Exception e)
            {
                message = "The password was not sent, check your input";
                bTemp = false;
            }
            return bTemp;
        }

        // Constructor
        public Register(string mailFrom, string mailTo)
        {

            MailObject = new MailMessage();
            mMailFrom = new MailAddress(mailFrom);
            try { mMailTo = new MailAddress(mailTo); }
            catch (Exception e) { }
            mMailSubject = "Webchess Registration";
            userPassword = Password.Generate();
            mMailBody = "Your registration is submitted, your password is: " + userPassword + Environment.NewLine + "Use "+ mMailTo+ " as user name" + Environment.NewLine + "Team notD1s";
            mSMTPServer = "";
            mSMTPPort = 25;
            mSMTPUsername = "";
            mSMTPPassword = "";
            mSMTPSSL = false;
        }

        public Register(IContainer container)
        {
            container.Add(this);

        }

    }
}
