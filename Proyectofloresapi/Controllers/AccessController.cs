using Proyectofloresapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Proyectofloresapi.Controllers
{
    public class AccessController : Controller
    {
        //cambia la url del dominio 
        string urlDomain = "http://localhost:61867/";
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult StartRecovery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StartRecovery(RecoveryViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                string token = Guid.NewGuid().ToString();

                using (proyectofloresEntities db = new proyectofloresEntities())
                {
                    var oUser = db.usuario.Where(d => d.email == model.Email).FirstOrDefault();
                    if (oUser != null)
                    {
                        oUser.token = token;
                        db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        //enviar correo 
                        SendEmail(oUser.email, token);
                    }
                }
                return View();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            
        }

        [HttpGet]
        public ActionResult Recovery(string token)
        {
            RecoveryPasswordViewModel model = new RecoveryPasswordViewModel();
            model.token = token;
            using (proyectofloresEntities db = new proyectofloresEntities())
            {
                if (model.token == null || model.token.Trim().Equals(""))
                {
                    return View("Index");
                }
                var oUser = db.usuario.Where(d => d.token == model.token).FirstOrDefault();
                if (oUser == null)
                {
                    ViewBag.Error = "Tu token ha expirado";
                    return View("Index");

                }
            }


            return View(model);
        }

        [HttpPost]
        public ActionResult Recovery(RecoveryPasswordViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                using (proyectofloresEntities db = new proyectofloresEntities())
                {
                    var oUser = db.usuario.Where(d => d.token == model.token).FirstOrDefault();

                    if (oUser != null)
                    {
                        oUser.password = model.Password;
                        oUser.token = null;
                        db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            ViewBag.Message = "Contraseña modificada con éxito";
            return RedirectToAction("Login", "Acceso");
        }

        #region HELPERS
        private string GetSha256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        private void SendEmail(string EmailDestino, string token)
        {
            string EmailOrigen = "programandounmundo1@gmail.com";
            string Contraseña = "P4p4doculus";
            string url = urlDomain+"/Access/Recovery/?token="+token;

            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Recuperación de contraseña",
                "<p>Correo para recuperación de contraseña</p><br>"+
                "<a href='"+url+"'>Click para recuperar</a>");

            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;
            oSmtpClient.Port = 25; //465//587
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contraseña);
            oSmtpClient.Send(oMailMessage);
            oSmtpClient.Dispose();

        }

        #endregion
    }
}