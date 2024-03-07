using api.Domain.Models;

namespace api.Domain.Services.Communication
{
    public class ClienteResponse: BaseResponse
    {
        public Cliente Cliente { get; private set; }
        private ClienteResponse(bool success, string message, Cliente category) : base(success, message)
        {
            Cliente = category;
        }
      
        public ClienteResponse(Cliente cliente) : this(true, string.Empty, cliente)
        { }
      
        public ClienteResponse(string message) : this(false, message, null)
        { }
    }
}
