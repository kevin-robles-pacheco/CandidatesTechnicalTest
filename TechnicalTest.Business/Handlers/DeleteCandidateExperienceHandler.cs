using MediatR;
using TechnicalTest.DataAccess.Clients.Database;
using TechnicalTest.Infraestructure.Services.Candidates.Commands;

namespace TechnicalTest.Business.Handlers;

public class DeleteCandidateExperienceHandler : IRequestHandler<DeleteCandidateExperienceCommand, bool>
{
    private readonly CandidateDbContext _dbContext;

    public DeleteCandidateExperienceHandler(CandidateDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Handle(DeleteCandidateExperienceCommand request, CancellationToken cancellationToken)
    {
        var candidateExperiences = await _dbContext.CandidateExperiences.FindAsync(new object[] { request.id }, cancellationToken);

        if (candidateExperiences is null)
        {
            return false;
        }

        _dbContext.CandidateExperiences.Remove(candidateExperiences);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}
