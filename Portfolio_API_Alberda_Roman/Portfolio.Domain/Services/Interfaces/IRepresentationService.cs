using Portfolio.Data.Entities;
using Portfolio.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portfolio.Domain.Services.Interfaces
{
    public interface IRepresentationService
    {
        Task<Representation> GetRepresentation(int representationId);
        Task<List<Representation>> GetAvailableRepresentation(string userName);
        Task<Representation> AssigneUserToRepresentation(int representationId, string userName);
        Task<Representation> DeleteAssignedRepresentationFromUser(int representationId, string userName);
        Task<List<Representation>> GetAssignedRepresentation(string userName);
        Task<Representation> CreateRepresentation(RepresentationModel representation);
        Task<Representation> UpdateRepresentation(RepresentationModel representation);
        Task<Representation> DeleteRepresentation(int representationId);
    }
}
