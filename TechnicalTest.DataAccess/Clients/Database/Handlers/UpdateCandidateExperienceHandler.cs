using MediatR;
using TechnicalTest.Domain.DTOs;
using TechnicalTest.Infraestructure.Services.Candidates.Commands;

namespace TechnicalTest.DataAccess.Clients.Database.Handlers;

public class UpdateCandidateExperienceHandler : IRequestHandler<UpdateCandidateExperienceCommand, CandidateExperienceDto>
{
    private readonly CandidateDbContext _dbContext;

    public UpdateCandidateExperienceHandler(CandidateDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CandidateExperienceDto> Handle(UpdateCandidateExperienceCommand request, CancellationToken cancellationToken)
    {
        var candidateExperience = await _dbContext.CandidateExperiences.FindAsync(new object[] { request.id }, cancellationToken);

        if (candidateExperience is null)
        {
            return null;
        }

        candidateExperience.Company = request.Company;
        candidateExperience.Job = request.Job;
        candidateExperience.Description = request.Description;
        candidateExperience.Salary = request.Salary;
        candidateExperience.BeginDate = request.BeginDate;
        candidateExperience.EndDate = request.EndDate;
        candidateExperience.ModifyDate = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new CandidateExperienceDto
        {
            IdCandidateExperience = candidateExperience.IdCandidateExperience,
            IdCandidate = candidateExperience.IdCandidate,
            Company = candidateExperience.Company,
            Job = candidateExperience.Job,
            Description = candidateExperience.Description,
            Salary = candidateExperience.Salary,
            BeginDate = candidateExperience.BeginDate,
            EndDate = candidateExperience.EndDate,
            InsertDate = candidateExperience.InsertDate,
            ModifyDate = candidateExperience.ModifyDate
        };
    }
}
