﻿using System.Net;
using System.Net.Mail;
using Topmass.Core.Model;
using Topmass.Core.Repository;

namespace Topmass.Bussiness.Mail
{
    public partial class MailBussiness : IMailBussiness
    {

        private readonly ICandidateRepository _candidateRepository;
        public MailBussiness(

                    ICandidateRepository candidateRepository
            )
        {

            _candidateRepository = candidateRepository;
        }

        private async Task<bool> SendMail(
            string content,
            string emailTo,
            string subjectTitle
            )
        {

            var mailconfig = new
            {
                MailConfigValue.Port,
                MailConfigValue.MailFrom,
                MailConfigValue.Host,
                MailConfigValue.userName,
                MailConfigValue.password
            };
            var contents = content;
            var mailFrom = mailconfig.MailFrom;
            var mailTo = emailTo;
            var subjectInfo = subjectTitle;
            var bodyContent = contents;
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(mailFrom);
            message.To.Add(new MailAddress(mailTo));
            message.Subject = subjectInfo;
            message.IsBodyHtml = true;
            message.Body = bodyContent;
            smtp.Port = mailconfig.Port;
            smtp.Host = mailconfig.Host;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(mailconfig.userName, mailconfig.password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);

            return true;

        }
        public async Task<MailReponse> PushMail(MailItem mailItem)
        {
            if (mailItem == null ||
                 string.IsNullOrEmpty(mailItem.MailTo)
                 )
            {
                return new MailReponse();
            }
            await SendMail(mailItem.Data.Content, mailItem.MailTo, mailItem.Data.Subject);
            return new MailReponse();
        }

        public async Task<ResultRequestSendMail> CanddidateCheckMailPassword(string email, string code)
        {
            var reponse = new ResultRequestSendMail();
            var candidateInfo = await _candidateRepository
            .FindOneByStatementSql<CandidateModel>
            (" select top 1 * from  Candidate where email = @Email",
            new
            {
                Email = email
            });

            if (candidateInfo == null)
            {
                reponse.IsSucess = false;
                return reponse;
            }
            var pathTemplate = @"C:\vietbank\crm\topmass\Topmass.Bussiness.Mail\Template\\resetPassword.html";
            var contents = File.ReadAllText(pathTemplate);
            contents = contents.Replace("{fullName}", (candidateInfo.FirstName + " " + candidateInfo.FullName));
            contents = contents.Replace("{baseLink}", "http://42.115.94.180:8588/khoi-tao-mat-khau");
            contents = contents.Replace("{code}", code);
            var mailData = new MailItem()
            {
                Data = new DataMailInfo()
                {
                    Content = contents,
                    Subject = "Cấp lại mật khẩu"
                },
                MailTo = email

            };
            await PushMail(mailData);
            return reponse;
        }

        public async Task<ResultRequestSendMail> CandidateSuccessRegister(string email)
        {
            var reponse = new ResultRequestSendMail();
            var candidateInfo = await _candidateRepository
            .FindOneByStatementSql<CandidateModel>
            (" select top 1 * from  Candidate where email = @Email",
            new
            {
                Email = email
            });

            if (candidateInfo == null)
            {
                reponse.IsSucess = false;
                return reponse;
            }
            var pathTemplate = @"C:\vietbank\crm\topmass\Topmass.Bussiness.Mail\Template\\RegisterSuccessUCV.html";
            var contents = File.ReadAllText(pathTemplate);
            contents = contents.Replace("{fullName}", (candidateInfo.FirstName + " " + candidateInfo.FullName));
            contents = contents.Replace("{email}", candidateInfo.Email);
            var mailData = new MailItem()
            {
                Data = new DataMailInfo()
                {
                    Content = contents,
                    Subject = "Thông báo tạo tài khoản thành công"
                },
                MailTo = email

            };
            await PushMail(mailData);
            return reponse;
        }


        public async Task<ResultRequestSendMail> CandidateSucessChangePassNoti(string email)
        {
            var reponse = new ResultRequestSendMail();
            var candidateInfo = await _candidateRepository
            .FindOneByStatementSql<CandidateModel>
            (" select top 1 * from  Candidate where email = @Email",
            new
            {
                Email = email
            });

            if (candidateInfo == null)
            {
                reponse.IsSucess = false;
                return reponse;
            }
            var pathTemplate = @"C:\vietbank\crm\topmass\Topmass.Bussiness.Mail\Template\\notificationPassword.html";
            var contents = File.ReadAllText(pathTemplate);
            contents = contents.Replace("{fullName}", (candidateInfo.FirstName + " " + candidateInfo.FullName));

            var mailData = new MailItem()
            {
                Data = new DataMailInfo()
                {
                    Content = contents,
                    Subject = "Thông báo thay đổi mật khẩu thành công"
                },
                MailTo = email

            };
            await PushMail(mailData);
            return reponse;
        }
    }
}
