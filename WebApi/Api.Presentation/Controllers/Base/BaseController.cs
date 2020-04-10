using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Presentation.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        public string SerializeObject(object dto)
        {
            return JsonConvert.SerializeObject(dto);
        }
    }
}
