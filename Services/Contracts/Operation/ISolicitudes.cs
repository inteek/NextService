using Next.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;   
using System.Web; 
    
namespace Next.Contracts.Operation
{
    [ServiceContract]
    public interface ISolicitudes
    {

        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/Contacto")]
        Response<String> Contacto(int idCliente, string nombre, string correo, string telefono, string mensaje);


        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/Cotizacion")]
        Response<String> Cotizacion(int idCliente, string nombre, string correo, string telefono, string ciudad, string empresa, string descripcionAuto, string mensaje);

    }
}