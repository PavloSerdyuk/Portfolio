using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Entities;
using Portfolio.Data.Infrastructure;
using Portfolio.Domain.Models;
using Portfolio.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Services.Implementation
{
    public class RepresentationService : IRepresentationService
    {
        private readonly IRepository<Representation> representationRepository;
        private readonly IRepository<User> userRepository;

        public RepresentationService(IRepository<Representation> representationRepository, IRepository<User> userRepository)
        {
            this.representationRepository = representationRepository;
            this.userRepository = userRepository;
        }

        public async Task<Representation> CreateRepresentation(RepresentationModel representation)
        {
            var newRepresentation = new Representation()
            {
                Id = representation.Id,
                Description = representation.Description,
                SpeakerId = representation.SpeakerId,
                StartTime = representation.StartTime,
                EndTime = representation.EndTime,
            };
            var addedRepresentation = await representationRepository.AddAsync(newRepresentation);
            await representationRepository.SaveChangesAsync();
            return addedRepresentation;
        }

        public Task<List<Representation>> GetAvailableRepresentation(string userName)
        {
            var user = userRepository.Query().FirstOrDefault(x => x.Username == userName);
            var listOfRepresentations = representationRepository.Query().Include(x => x.Speaker).Include(x => x.Subscribers).Where(x => x.SpeakerId != user.Id && !x.Subscribers.Any(s => s.Id == user.Id)).ToListAsync();
            return listOfRepresentations;
        }

        public Task<List<Representation>> GetAssignedRepresentation(string userName)
        {
            var user = userRepository.Query().FirstOrDefault(x => x.Username == userName);

            var listOfRepresentations = representationRepository.Query().Where(x => x.Subscribers.Any(s => s.Id == user.Id)).Include(x => x.Speaker).ToListAsync();
            return listOfRepresentations;
        }

        public async Task<Representation> AssigneUserToRepresentation(int representationId, string userName)
        {
            var representation = await representationRepository.Query().Include(i => i.Speaker).Where(x => x.Id == representationId).FirstOrDefaultAsync();
            var user = userRepository.Query().FirstOrDefault(x => x.Username == userName);
            if(user.AssignedRepresentations is null)
            {
                user.AssignedRepresentations = new List<Representation>();
            }
            user.AssignedRepresentations.Add(representation);
            await userRepository.SaveChangesAsync();
            return representation;
        }

        public async Task<Representation> DeleteAssignedRepresentationFromUser(int representationId, string userName)
        {
            var representation = await representationRepository.Query().Include(i => i.Speaker).Where(x => x.Id == representationId).FirstOrDefaultAsync();
            var user = userRepository.Query().Include(x => x.AssignedRepresentations).FirstOrDefault(x => x.Username == userName);
            if (user.AssignedRepresentations is null)
            {
                user.AssignedRepresentations = new List<Representation>();
                throw new Exception("User do not has any assigned representation");
            }
            user.AssignedRepresentations.Remove(representation);
            await userRepository.SaveChangesAsync();
            return representation;
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

        public async Task<Representation> UpdateRepresentation(RepresentationModel? representation)
        {
            if(representation is null)
            {
                throw new Exception("Representation is null");
            }
            var newRepresentationInfo = new Representation()
            {
                Id = representation.Id,
                Description = representation.Description,
                SpeakerId = representation.SpeakerId,
                StartTime = representation.StartTime,
                EndTime = representation.EndTime,
            };

            var updatedRepresentation = await representationRepository.UpdateAsync(newRepresentationInfo);
            await representationRepository.SaveChangesAsync();
            return updatedRepresentation;
        }
    }
}
