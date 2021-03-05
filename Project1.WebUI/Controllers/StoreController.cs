using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.BL;

namespace Project1.WebUI.Controllers
{
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly Project1.BL.IStoreRepository _storeRepository;

        [HttpGet("api/store/{id}")]
        public BL.Store GetStoreById(int id)
        {
            return _storeRepository.GetStoreById(id);
        }
    }
}