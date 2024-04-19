using MediatR;
using TechnicalTest.Domain.DTOs;

namespace TechnicalTest.Infraestructure.Services.Candidates.Queries;

public record GetByIdCandidateQuery(int id) : IRequest<CandidateDto>;
