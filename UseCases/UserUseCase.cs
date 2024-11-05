using Doracorde.API.DTO.Request;
using Doracorde.Database.Models;
using Doracorde.Repository;
using Doracorde.Services.CEP;

namespace Doracorde.API.UseCases
{
    public class UserUseCase(IRepository<User> userRepository, IRepository<UserLike> userLikeRepository, ICEPService cepService)
    {
        private readonly IRepository<User> _userRepository = userRepository;
        private readonly IRepository<UserLike> _userLikeRepository = userLikeRepository;
        private readonly ICEPService _cepService = cepService;


        public void CreateUser(UserRequest userRequest)
        {
            try
            {
                User user = new(userRequest.Email, userRequest.Name, userRequest.Password);

                _userRepository.Add(user);

                _cepService.FindCEP(userRequest.CEP);
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void LikedUser(UserLike userLike)
        {
            _userLikeRepository.Add(userLike);
        }
    }
}
