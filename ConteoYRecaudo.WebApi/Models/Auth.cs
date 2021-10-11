using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConteoYRecaudo.WebApi.Models
{
    public class Auth
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
}