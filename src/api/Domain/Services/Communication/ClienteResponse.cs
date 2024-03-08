using api.Domain.Models;

namespace api.Domain.Services.Communication
{
    public class ClienteResponse: BaseResponse
    {
        public Cliente Cliente { get; private set; }
        private ClienteResponse(bool success, string message, Cliente cliente) : base(success, message)
        {
            Cliente = cliente;
        }
      
        public ClienteResponse(Cliente cliente) : this(true, string.Empty, cliente)
        { }
      
        public ClienteResponse(string message) : this(false, message, null)
        { }
    }
}
