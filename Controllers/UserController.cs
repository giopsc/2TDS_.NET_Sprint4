using Doracorde.API.DTO.Request;
using Doracorde.API.UseCases;
using Doracorde.Database.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Doracorde.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Tags("courses")]
    public class UserController(UserUseCase userUseCase) : ControllerBase
    {
        private readonly UserUseCase _userUseCase = userUseCase;

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult PostUser(UserRequest userRequest)
        {
            if (userRequest is null) return BadRequest();

            _userUseCase.CreateUser(userRequest);

            return Created();
        }

        [HttpPost]
        [Route("likeuser")]
        public async Task<IActionResult> PostUserLikeAsync([FromBody] UserLike userLike)
        {
            //_userUseCase.LikedUser(userLike);

            return Created();
        }

    }
}
