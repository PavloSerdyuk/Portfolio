using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Data.Entities;
using Portfolio.Data.Infrastructure;
using Portfolio.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepository<Representation> representationRepository;
        private readonly IRepository<User> userRepository;

        public UserService(IRepository<Representation> representationRepository, IRepository<User> userRepository)
        {
            this.representationRepository = representationRepository;
            this.userRepository = userRepository;
        }

        public bool CheckUser(string userName, string password)
        {
            return userName.Equals("1") && password.Equals("1");
        }

        public async Task<Representation> CreateRepresentation(Representation representation)
        {
            return await representationRepository.AddAsync(representation);
        }

        public async Task<Representation> DeleteRepresentation(int representationId)
        {
            var representation = await representationRepository.GetByIdAsync(representationId);
            var isDeleted = await representationRepository.DeleteAsync(representation);
            await representationRepository.SaveChangesAsync();

            if (isDeleted is true)
            {
                return representation;
            }

            throw new Exception("User haven't been deleted");
        }
        public async Task<Representation> GetRepresentation(int representationId) => await representationRepository.GetByIdAsync(representationId);
        private ClaimsIdentity GetIdentity(string username, string password)
        {
            User person = userRepository.Query().FirstOrDefault(x => x.Username == username && x.Password == password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, person.Username),
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Username),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role),
                };

                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
        public string Login(string userName, string password)
        {
            var identity = GetIdentity(userName, password);
            if (identity == null)
            {
                throw new Exception("Invalid username or password.");
            }

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        public async Task<Representation> UpdateRepresentation(Representation representation)
        {
            return await representationRepository.UpdateAsync(representation);
        }
    }
}
