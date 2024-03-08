using api.Domain.Models;

namespace api.Domain.Services.Communication
{
    public class LogradouroResponse : BaseResponse
    {
        public Logradouro Logradouro { get; private set; }
        private LogradouroResponse(bool success, string message, Logradouro logradouro) : base(success, message)
        {
            Logradouro = logradouro;
        }
      
        public LogradouroResponse(Logradouro logradouro) : this(true, string.Empty, logradouro)
        { }
      
        public LogradouroResponse(string message) : this(false, message, null)
        { }
    }
}
