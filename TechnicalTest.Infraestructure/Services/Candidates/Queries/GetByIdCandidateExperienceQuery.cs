using MediatR;
using TechnicalTest.Domain.DTOs;

namespace TechnicalTest.Infraestructure.Services.Candidates.Queries;

public record GetByIdCandidateExperienceQuery(int id) : IRequest<CandidateExperienceDto>;
