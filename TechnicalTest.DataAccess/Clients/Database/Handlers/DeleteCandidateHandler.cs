using MediatR;
using TechnicalTest.Infraestructure.Services.Candidates.Commands;

namespace TechnicalTest.DataAccess.Clients.Database.Handlers;

public class DeleteCandidateHandler : IRequestHandler<DeleteCandidateCommand, bool>
{
    private readonly CandidateDbContext _dbContext;

    public DeleteCandidateHandler(CandidateDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
    {
        var candidate = await _dbContext.Candidates.FindAsync(new object[] { request.id }, cancellationToken);

        if (candidate is null)
        {
            return false;
        }

        _dbContext.Candidates.Remove(candidate);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}
