using MediatR;
using TechnicalTest.Domain.DTOs;
using TechnicalTest.Domain.Models;
using TechnicalTest.Infraestructure.Services.Candidates.Commands;

namespace TechnicalTest.DataAccess.Clients.Database.Handlers;

public class CreateCandidateExperienceHandler : IRequestHandler<CreateCandidateExperienceCommand, CandidateExperienceDto>
{
    private readonly CandidateDbContext _dbContext;

    public CreateCandidateExperienceHandler(CandidateDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CandidateExperienceDto> Handle(CreateCandidateExperienceCommand request, CancellationToken cancellationToken)
    {
        var candidateExperiences = new CandidateExperience()
        {
            IdCandidate = request.IdCandidate,
            Company = request.Company,
            Job = request.Job,
            Description = request.Description,
            Salary = request.Salary,
            BeginDate = request.BeginDate,
            EndDate = request.EndDate,
            InsertDate = DateTime.UtcNow
        };

        _dbContext.CandidateExperiences.Add(candidateExperiences);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new CandidateExperienceDto
        {
            IdCandidate = candidateExperiences.IdCandidate,
            Company = candidateExperiences.Company,
            Job = candidateExperiences.Job,
            Description = candidateExperiences.Description,
            Salary = candidateExperiences.Salary,
            BeginDate = candidateExperiences.BeginDate,
            EndDate = candidateExperiences.EndDate,
            InsertDate = candidateExperiences.InsertDate
        };
    }
}
