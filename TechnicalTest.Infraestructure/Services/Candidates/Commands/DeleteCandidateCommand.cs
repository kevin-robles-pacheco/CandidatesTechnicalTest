using MediatR;

namespace TechnicalTest.Infraestructure.Services.Candidates.Commands;

public record DeleteCandidateCommand(int id) : IRequest<bool>;
