using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.Library;

namespace EmailApp.WebUI.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // each method here ("action method") will respond to one type of AJAX request
        // from the app, and optionally return an object (will be serialized to
        // json by ASP.NET and System.Text.Json in the response body)

        private readonly CustomerRepository _customerRepository;

        public CustomerController()
        {
            _customerRepository = new CustomerRepository();
        }

        // distinguish what HTTP method (GET, POST, etc.) this will accept, and, what URL
        [HttpGet("api/inbox")]
        public IEnumerable<Message> GetInbox()
        {
            return _messageRepository.List();
        }

        [HttpGet("api/message/{id}")]
        public Message GetMessage(int id)
        {
            return _messageRepository.Get(id);
        }

        // "model binding" (useful feature of ASP.NET)
        // will deserialize data in the request body (JSON text)
        // into the action method parameters.
        [HttpPost("api/send-message")]
        public void SendMessage(Message message)
        {
            _messageRepository.Create(message);
        }

        [NonAction]
        public void HelperMethod()
        {
        }
    }
}