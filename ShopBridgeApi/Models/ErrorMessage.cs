using System;
namespace ShopBridgeApi.Models
{
    public class ErrorMessage
    {
        private readonly bool is_error;
        private readonly string error_message;
        public ErrorMessage(bool is_e,string e_message)
        {
            is_error = is_e;
            error_message = e_message;
            
        }
        
    }
}
