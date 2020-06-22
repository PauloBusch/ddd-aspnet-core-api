using System;

namespace Domain.ViewModels.Auth
{
    public class AuthResult
    {
        public bool Authenticated { get; set; } 
        public DateTime Creation { get; set; }
        public DateTime Expiration { get; set; }
        public string AccessToken { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}
