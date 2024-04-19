using MediatR;
using TechnicalTest.Domain.DTOs;

namespace TechnicalTest.Infraestructure.Services.Candidates.Commands;

public record UpdateCandidateCommand(string name, string surname, DateTime birthdate, string email, int id) : IRequest<CandidateDto>;
