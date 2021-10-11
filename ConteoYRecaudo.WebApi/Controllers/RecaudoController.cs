using AutoMapper;
using ConteoYRecaudo.Business.Business;
using ConteoYRecaudo.Data.Interface;
using ConteoYRecaudo.Data.Repositorio;
using ConteoYRecaudo.Dto.Dto;
using ConteoYRecaudo.Model.Models;
using ConteoYRecaudo.WebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConteoYRecaudo.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class RecaudoController : ApiController
    {

        private readonly RecaudoBusiness _recaudoBusiness = new RecaudoBusiness();

        /// <summary>
        /// Devuelve los datos RecaudoVehiculos que se obtuvieron del servicio, el metodo recibe dos parametros limit y skip, limit para delimitar la cantidad de registros a que va devolver y skip los registros que se va saltar
        /// </summary>
        /// <param name="skip"> cantidad de datos a saltar</param>
        /// <param name="limit">limited de datos a devolver</param>
        /// <returns>Devuelve una lista de tipo Recaudos con la cantidad de datos solicitados</returns>
        public Task<List<RecaudosDto>> Get(int skip, int limit)
        {
            try
            {
                return Task.FromResult(_recaudoBusiness.Get(skip, limit));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Devuelve los datos para visualizar el reporte de los ultimos 3 meses partiendo de la fecha actual 
        /// </summary>
        /// <returns> devuelve un objeto de tipo Reporte que a su ves esta compuesto por dos objetos</returns>
        public ReportDto GetReport()
        {
            try
            {
                return _recaudoBusiness.Reporte();
            }
            catch (Exception ex)
            {
                throw;
            };
        }

        /// <summary>
        /// Consulta en el api externa El RecaudoVehiculos y almacena los datos para su consulta previa 
        /// </summary>
        /// <param name="date"> toma como parametro un dato de tipo strin para la fecha en formato yyyy-MM-dd</param>
        /// <returns></returns>
        [HttpGet]
        public Task <List<RecaudosDto>> FindApi(string date)
        {
            var URL = $"http://190.145.81.67:5200/api/RecaudoVehiculos/{date}";

            var auth = GetToken();
            var req = (HttpWebRequest)WebRequest.Create(URL);
            req.Method = "GET";
            req.ContentType = "application/json";
            req.Accept = "application/json";
            req.Headers.Add("Authorization", "Bearer " + auth.token);

            try
            {
                using (WebResponse response = req.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return Task.FromResult(new List<RecaudosDto>());
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            if (responseBody.Equals(""))
                            {
                                return Task.FromResult(new List<RecaudosDto>());
                            }
                            var listRecaudo = JsonConvert.DeserializeObject<List<RecaudosDto>>(responseBody);

                            _recaudoBusiness.Add(listRecaudo, date);
                            return Task.FromResult(listRecaudo);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtienen el token del api externa
        /// </summary>
        /// <returns></returns>
        private Auth GetToken()
        {
            var URL = $"http://190.145.81.67:5200/api/login";
            var Data = "{ \"userName\":\"user\", \"password\": \"1234\" }";

            var req = (HttpWebRequest)WebRequest.Create(URL);


            req.Method = "POST";
            req.ContentType = "application/json";
            req.Accept = "application/json";

            using (var streamWriter = new StreamWriter(req.GetRequestStream()))
            {
                streamWriter.Write(Data);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                using (WebResponse response = req.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            Auth auth = JsonConvert.DeserializeObject<Auth>(responseBody);
                            return auth;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}