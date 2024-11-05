using Doracorde.Services.CEP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Doracorde.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Tags("Consulta de CEP")]
    public class CEPController : ControllerBase
    {
        private readonly ICEPService _cepService;

        public CEPController(ICEPService cepService)
        {
            _cepService = cepService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(AddressResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public Task<AddressResponse> GetCEP(string cep)
        {
            return _cepService.FindCEP(cep);
        }

    }
}
