using MediatR;

namespace TechnicalTest.Infraestructure.Services.Candidates.Commands;

public record DeleteCandidateExperienceCommand(int id) : IRequest<bool>;
