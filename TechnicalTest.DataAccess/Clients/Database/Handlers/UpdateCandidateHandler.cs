using MediatR;
using TechnicalTest.Domain.DTOs;
using TechnicalTest.Infraestructure.Services.Candidates.Commands;

namespace TechnicalTest.DataAccess.Clients.Database.Handlers;

public class UpdateCandidateHandler : IRequestHandler<UpdateCandidateCommand, CandidateDto>
{
    private readonly CandidateDbContext _dbContext;

    public UpdateCandidateHandler(CandidateDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CandidateDto> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
    {
        var candidate = await _dbContext.Candidates.FindAsync(new object[] { request.id }, cancellationToken);

        if (candidate is null)
        {
            return null;
        }

        candidate.IdCandidate = request.id;
        candidate.Name = request.name;
        candidate.Surname = request.surname;
        candidate.Birthdate = request.birthdate;
        candidate.Email = request.email;
        candidate.ModifyDate = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new CandidateDto
        {
            IdCandidate = candidate.IdCandidate,
            Name = candidate.Name,
            Surname = candidate.Surname,
            Birthdate = candidate.Birthdate,
            Email = candidate.Email,
            InsertDate = candidate.InsertDate,
            ModifyDate = candidate.ModifyDate
        };
    }
}
