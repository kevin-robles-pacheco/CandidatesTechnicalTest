using MediatR;
using TechnicalTest.Domain.DTOs;

namespace TechnicalTest.Infraestructure.Services.Candidates.Commands;

public record UpdateCandidateExperienceCommand(int IdCandidate, string Company, string Job, string Description, decimal Salary, DateTime BeginDate, DateTime? EndDate, int id)
: IRequest<CandidateExperienceDto>;
