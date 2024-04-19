using MediatR;
using TechnicalTest.Domain.DTOs;

namespace TechnicalTest.Infraestructure.Services.Candidates.Commands;

public record CreateCandidateCommand(string name, string surname, DateTime birthdate, string email) : IRequest<CandidateDto>;
