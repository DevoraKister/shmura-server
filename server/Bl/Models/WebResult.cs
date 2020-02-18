using BL.Models;
using Entities;
namespace BL
{
    internal class WebResult<T> : User
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public LoginData Value { get; set; }
    }
}