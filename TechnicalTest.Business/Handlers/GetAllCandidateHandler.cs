using MediatR;
using Microsoft.EntityFrameworkCore;
using TechnicalTest.DataAccess.Clients.Database;
using TechnicalTest.Domain.DTOs;
using TechnicalTest.Infraestructure.Services.Candidates.Queries;

namespace TechnicalTest.Business.Handlers;

public class GetAllCandidateHandler : IRequestHandler<GetAllCandidateQuery, IEnumerable<CandidateDto>>
{
    private readonly CandidateDbContext _dbContext;

    public GetAllCandidateHandler(CandidateDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<CandidateDto>> Handle(GetAllCandidateQuery request, CancellationToken cancellationToken)
    {
        var candidates = await _dbContext.Candidates.ToListAsync(cancellationToken);

        return candidates.Select(candidate => new CandidateDto
        {
            IdCandidate = candidate.IdCandidate,
            Name = candidate.Name,
            Surname = candidate.Surname,
            Birthdate = candidate.Birthdate,
            Email = candidate.Email,
            InsertDate = candidate.InsertDate,
            ModifyDate = candidate.ModifyDate,
        });
    }
}
