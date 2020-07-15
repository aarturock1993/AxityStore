using AutoMapper;
using AxityStoreBackEnd.Domain.DTO;
using AxityStoreBackEnd.Domain.Interfaces;
using AxityStoreBackEnd.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace AxityStoreBackEnd.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<DTOUser> Login(string name, string lastName)
        {
            DTOUser dtoUser = null;

            var result = await _userRepository.Login(name, lastName);
            dtoUser = _mapper.Map<DTOUser>(result);

            return dtoUser;
        }
    }
}
