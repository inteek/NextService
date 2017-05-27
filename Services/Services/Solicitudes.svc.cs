using Next.Contracts.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Next.Services
{
    public class Solicitudes : ISolicitudes
    {
        public Contracts.Data.Response<string> Contacto(int idCliente, string nombre, string correo, string telefono, string mensaje)
        {

            try
            {
                Contracts.Data.Response<String> result = new Contracts.Data.Response<String>();

                Framework.Comunicacion framework = new Framework.Comunicacion();

                string mensajeNuevo = string.Format("<div style='width:501px; text-align:left;'><p style='width:501px;'><strong>Contacto:</strong> {0}<br><strong>Correo:</strong> {1}<br><strong>Teléfono:</strong> {2}<br><br><strong>Mensaje:</strong><br>{3}<br></p></div>", nombre, correo, telefono, mensaje);

                framework.EnviarSolicitud(idCliente, "Mensaje de contacto", correo, mensajeNuevo);


                return result;
            } 
            catch(Exception ex){


                Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(ex);
                return result;
            
            
            }

        }


        public Contracts.Data.Response<string> Cotizacion(int idCliente, string nombre, string correo, string telefono, string ciudad, string empresa, string descripcionAuto, string mensaje)
        {
            try
            {
                Contracts.Data.Response<String> result = new Contracts.Data.Response<String>();

                Framework.Comunicacion framework = new Framework.Comunicacion();

                string mensajeNuevo = string.Format("<div style='width:501px; text-align:left;'><p style='width:501px;'><strong>Contacto:</strong> {0}<br><strong>Correo:</strong> {1}<br><strong>Teléfono:</strong> {2}<br><strong>Ciudad:</strong> {3}<br><strong>Empresa o Particular: </strong> {4}<br><br><strong>Descripcion Vehículo:</strong><br>{5}<br><br><strong>Mensaje:</strong><br>{6}<br></p></div>", nombre, correo, telefono, ciudad, empresa, descripcionAuto, mensaje);

                framework.EnviarSolicitud(idCliente, "Solicitud de cotizacion", correo, mensajeNuevo);


                return result;
            }
            catch (Exception ex)
            {


                Contracts.Data.ResponseError<String> result = new Contracts.Data.ResponseError<String>(ex);
                return result;


            }
        }
    }
}
