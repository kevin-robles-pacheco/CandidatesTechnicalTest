using MediatR;
using TechnicalTest.Infraestructure.Services.Candidates.Commands;
using TechnicalTest.Domain.DTOs;
using TechnicalTest.Domain.Models;

namespace TechnicalTest.DataAccess.Clients.Database.Handlers;

public class CreateCandidateHandler : IRequestHandler<CreateCandidateCommand, CandidateDto>
{
    private readonly CandidateDbContext _dbContext;

    public CreateCandidateHandler(CandidateDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CandidateDto> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
    {
        var candidate = new Candidate()
        {
            Name = request.name,
            Surname = request.surname,
            Birthdate = request.birthdate,
            Email = request.email,
            InsertDate = DateTime.UtcNow,
        };

        _dbContext.Candidates.Add(candidate);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new CandidateDto
        {
            IdCandidate = candidate.IdCandidate,
            Name = candidate.Name,
            Surname = candidate.Surname,
            Birthdate = candidate.Birthdate,
            Email = candidate.Email,
            InsertDate = candidate.InsertDate
        };
    }
}
