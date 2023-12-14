using Newtonsoft.Json;
using System.Net;
using System.Text;
using WebApplicationBilling.Models;
using WebApplicationBilling.Models.DTO;
using WebApplicationBilling.Repository.Interfaces;

namespace WebApplicationBilling.Repository
{
    public class AccountRepository : Repository<UserRegisterDTO>, IAccountRepository
    {
        //Injección de dependencias se debe importar el IHttpClientFactory
        private readonly IHttpClientFactory _clientFactory;

        public AccountRepository(IHttpClientFactory httpClientFactory) 
            : base(httpClientFactory)
        {
            this._clientFactory = httpClientFactory;    
        }



        public async Task<UserLoginResponseDTO> LoginAsync(string url, UserLoginDTO userLoginDTO)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (userLoginDTO != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(userLoginDTO), Encoding.UTF8, "application/json"
                );
            }
            else
            {
                return new UserLoginResponseDTO();
            }

            var cliente = _clientFactory.CreateClient();

            HttpResponseMessage respuesta = await cliente.SendAsync(request);

            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                var jsonString = await respuesta.Content.ReadAsStringAsync();

                // Deserialize the response JSON
                var response = JsonConvert.DeserializeObject<ApiResponse<UserLoginResponseDTO>>(jsonString);

                if (response.IsSuccess)
                {
                    // Perform specific deserialization for RegisterUser
                    var registerUser = JsonConvert.DeserializeObject<UserLoginResponseDTO>(response.Result.ToString());

                    // Return the deserialized RegisterUser
                    return registerUser;
                }
            }

            // Handle other cases or return an empty RegisterUser as needed
            return new UserLoginResponseDTO();
        }

       

        public async Task<bool> RegisterAsync(string url, UserRegisterDTO itemCrear)
        {
           

            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (itemCrear != null)
            {
                request.Content = new StringContent(
                        JsonConvert.SerializeObject(itemCrear), Encoding.UTF8, "application/json"
                    );
            }
            else
            {
                return false;
            }

            var cliente = _clientFactory.CreateClient();

            HttpResponseMessage respuesta = await cliente.SendAsync(request);


            if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

      
    }
}
