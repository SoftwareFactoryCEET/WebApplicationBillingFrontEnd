using Newtonsoft.Json.Linq;
using System.Net;

namespace WebApplicationBilling.Models
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
            ErrorMessages = new List<string>();
        }

        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessages { get; set; }
        public JObject Result { get; set; }  // Cambiado a JObject
    }


}
