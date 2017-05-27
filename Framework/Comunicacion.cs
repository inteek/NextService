using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class Comunicacion
    {
        public bool EnviarSolicitud(int idCliente, string asunto, string correoSalida, string mensaje) 
        {
            string correoEntrada, urlLogotipo;

            try
            {
               // correoEntrada = "raul.mtz.f@hotmail.com";

                if (idCliente == 1)
                {
                    correoEntrada = System.Configuration.ConfigurationSettings.AppSettings["Mago"];
                    //"rodandoseguromty@gmail.com";
                    urlLogotipo = "http://inteek.mx/mail/magoautomotriz.png";

                }
                else
                {
                    correoEntrada = System.Configuration.ConfigurationSettings.AppSettings["Soluciones"];
                    //"jorgenoe.ramos@gmail.com";
                    urlLogotipo = "http://inteek.mx/mail/solucionesautomotrices.jpg";
                }

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("inteekdev.com");

                mail.From = new MailAddress(correoSalida);
                mail.To.Add(correoEntrada);
                mail.Subject =  asunto;
                mail.IsBodyHtml = true;


                string body = "<!DOCTYPE html>";
                body += "<html lang='es'>";
                body += "<head>";
                body += "<meta name='viewport' content='width=device-width'>";
                body += "<style>";
                body += "@media only screen and (max-width:319px)  { body{font-size:8px}}";
                body += "@media only screen and (min-width:320px) and (max-width:767px)  { body{font-size:10px} }";
                body += "@media only screen and (min-width:768px) and (max-width:1023px)  { body{font-size:12px} }";
                body += "@media only screen and (min-width:1024px) and (max-width:1899px) { body{font-size:14px} }";
                body += "@media only screen and (min-width:1900px) { body{font-size:16px} }";
                body += "</style>";
                body += "</head>";
                body += "<body>";
                body += "<div style='width:100%;' align='center'> ";

                body += "   <div style='height:180px; width:621px;'>";
                body += "       <img src='http://inteek.mx/mail/header3.png' style='height:100%; width:100%' />";
                body += "   </div>";

                body += "   <div style='height:65px; width:200px;' align='center'>";
                body += "       <img src= '" + urlLogotipo + "' style='height:100%; width:100%' />"; 
                body += "   </div>";

                body += "   <br></br>";

                body += "   <div style='height:100%; width:621px;' align='center's>";
                body += mensaje;
                body += "   </div>";

                body += "   <div style='height:180px; width:621px;'>";
                body += "       <img src='http://inteek.mx/mail/foter3.png' style='height:100%; width:100%' />";
                body += "   </div>";

                body += "</div>";

                body += "</body>";
                body += "<html>";


                mail.Body = body;


                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("agalindo@inteekdev.com", "DeveloperNet.2016");
                //SmtpServer.EnableSsl = true;


                SmtpServer.Send(mail);


                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


    }
}
