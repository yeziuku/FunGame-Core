﻿using System.Net.Mail;
using Milimoe.FunGame.Core.Api.Transmittal;
using Milimoe.FunGame.Core.Library.Constant;

namespace Milimoe.FunGame.Core.Library.Common.Network
{
    public class MailObject
    {
        /// <summary>
        /// 发件人邮箱
        /// </summary>
        public string Sender { get; } = "";

        /// <summary>
        /// 发件人名称
        /// </summary>
        public string SenderName { get; } = "";

        /// <summary>
        /// 邮件主题
        /// </summary>
        public string Subject { get; } = "";

        /// <summary>
        /// 邮件内容
        /// </summary>
        public string Body { get; } = "";

        /// <summary>
        /// 邮件优先级
        /// </summary>
        public MailPriority Priority { get; } = MailPriority.Normal;

        /// <summary>
        /// 内容是否支持HTML
        /// </summary>
        public bool HTML { get; } = true;

        /// <summary>
        /// 收件人列表
        /// </summary>
        public List<string> ToList { get; } = new();

        /// <summary>
        /// 抄送列表
        /// </summary>
        public List<string> CCList { get; } = new();

        /// <summary>
        /// 密送列表
        /// </summary>
        public List<string> BCCList { get; } = new();

        public MailObject()
        {

        }

        /// <summary>
        /// 使用MailSender工具类创建邮件对象
        /// </summary>
        /// <param name="Sender"></param>
        public MailObject(MailSender Sender)
        {
            this.Sender = Sender.SmtpClientInfo.SenderMailAddress;
            this.SenderName = Sender.SmtpClientInfo.SenderName;
        }
        
        /// <summary>
        /// 使用地址和名称创建邮件对象
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="SenderName"></param>
        public MailObject(string Sender, string SenderName)
        {
            this.Sender = Sender;
            this.SenderName = SenderName;
        }

        /// <summary>
        /// 使用地址和名称创建邮件对象，同时写主题、内容、单个收件人
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Subject"></param>
        /// <param name="Body"></param>
        /// <param name="To"></param>
        public MailObject(MailSender Sender, string Subject, string Body, string To)
        {
            this.Sender = Sender.SmtpClientInfo.SenderMailAddress;
            this.SenderName = Sender.SmtpClientInfo.SenderName;
            this.Subject = Subject;
            this.Body = Body;
            ToList.Add(To);
        }

        /// <summary>
        /// 使用地址和名称创建邮件对象，同时写主题、内容、单个收件人、单个抄送
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Subject"></param>
        /// <param name="Body"></param>
        /// <param name="To"></param>
        /// <param name="CC"></param>
        public MailObject(MailSender Sender, string Subject, string Body, string To, string CC)
        {
            this.Sender = Sender.SmtpClientInfo.SenderMailAddress;
            this.SenderName = Sender.SmtpClientInfo.SenderName;
            this.Subject = Subject;
            this.Body = Body;
            ToList.Add(To);
            CCList.Add(CC);
        }

        /// <summary>
        /// 完整的创建邮件对象
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="Subject"></param>
        /// <param name="Body"></param>
        /// <param name="Priority"></param>
        /// <param name="HTML"></param>
        /// <param name="ToList"></param>
        /// <param name="CCList"></param>
        /// <param name="BCCList"></param>
        public MailObject(MailSender Sender, string Subject, string Body, MailPriority Priority, bool HTML, string[] ToList, string[]? CCList = null, string[]? BCCList = null)
        {
            this.Sender = Sender.SmtpClientInfo.SenderMailAddress;
            this.SenderName = Sender.SmtpClientInfo.SenderName;
            this.Subject = Subject;
            this.Body = Body;
            this.Priority = Priority;
            this.HTML = HTML;
            AddTo(ToList);
            if (CCList != null) AddCC(CCList);
            if (BCCList != null) AddBCC(BCCList);
        }

        /// <summary>
        /// 发送邮件
        /// -- 适合创建一次性邮件并发送 --
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public MailSendResult Send(MailSender sender)
        {
            return sender.Send(this);
        }

        /// <summary>
        /// 添加收件人
        /// </summary>
        /// <param name="to"></param>
        public void AddTo(string to)
        {
            if (!ToList.Contains(to)) ToList.Add(to);
        }

        /// <summary>
        /// 添加多个收件人
        /// </summary>
        /// <param name="to"></param>
        public void AddTo(params string[] to)
        {
            foreach (string t in to) AddTo(t);
        }

        /// <summary>
        /// 添加抄送
        /// </summary>
        /// <param name="cc"></param>
        public void AddCC(string cc)
        {
            if (!CCList.Contains(cc)) CCList.Add(cc);
        }

        /// <summary>
        /// 添加多个抄送
        /// </summary>
        /// <param name="cc"></param>
        public void AddCC(params string[] cc)
        {
            foreach (string c in cc) AddCC(c);
        }

        /// <summary>
        /// 添加密送
        /// </summary>
        /// <param name="bcc"></param>
        public void AddBCC(string bcc)
        {
            if (!BCCList.Contains(bcc)) BCCList.Add(bcc);
        }

        /// <summary>
        /// 添加多个密送
        /// </summary>
        /// <param name="bcc"></param>
        public void AddBCC(params string[] bcc)
        {
            foreach (string b in bcc) AddBCC(b);
        }
    }
}
