using MediatR;
using Microsoft.EntityFrameworkCore;
using TechnicalTest.Domain.DTOs;
using TechnicalTest.Infraestructure.Services.Candidates.Queries;

namespace TechnicalTest.DataAccess.Clients.Database.Handlers;

public class GetByIdCandidateHandler : IRequestHandler<GetByIdCandidateQuery, CandidateDto>
{
    private readonly CandidateDbContext _dbContext;

    public GetByIdCandidateHandler(CandidateDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CandidateDto> Handle(GetByIdCandidateQuery request, CancellationToken cancellationToken)
    {
        var candidate = await _dbContext.Candidates.FindAsync(new object[] { request.id }, cancellationToken);

        if (candidate is null)
        {
            return null;
        }

        var candidateExperiences = await _dbContext.CandidateExperiences
            .Where(ce => ce.IdCandidate == candidate.IdCandidate)
            .ToListAsync(cancellationToken);

        var experienceDtos = candidateExperiences.Select(ce => new CandidateExperienceDto
        {
            IdCandidateExperience = ce.IdCandidateExperience,
            IdCandidate = ce.IdCandidate,
            Company = ce.Company,
            Job = ce.Job,
            Description = ce.Description,
            Salary = ce.Salary,
            BeginDate = ce.BeginDate,
            EndDate = ce.EndDate,
            InsertDate = ce.InsertDate,
            ModifyDate = ce.ModifyDate
        }).ToList();

        var candidateDto = new CandidateDto
        {
            IdCandidate = candidate.IdCandidate,
            Name = candidate.Name,
            Surname = candidate.Surname,
            Birthdate = candidate.Birthdate,
            Email = candidate.Email,
            InsertDate = candidate.InsertDate,
            ModifyDate = candidate.ModifyDate,
            Experiences = experienceDtos
        };

        return candidateDto;
    }
}
