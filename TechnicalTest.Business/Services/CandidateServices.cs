using MediatR;
using TechnicalTest.Domain.DTOs;
using TechnicalTest.Infraestructure.Services.Candidates.Commands;
using TechnicalTest.Infraestructure.Services.Candidates.Queries;

namespace TechnicalTest.Business.Services;

public class CandidateServices
{
    IMediator _mediator;
    public CandidateServices(IMediator mediator) 
    {
        _mediator = mediator;
    }

    public async Task<IEnumerable<CandidateDto>> GetAllAsync()
    {
        return await _mediator.Send(new GetAllCandidateQuery());
    }

    public async Task<CandidateDto> GetByIdAsync(int id)
    {
        var query = new GetByIdCandidateQuery(id);
        var candidate = await _mediator.Send(query);

        if (candidate is null)
            return new CandidateDto();

        return candidate;
    }

    public async Task<CandidateExperienceDto> GetByIdExperienceAsync(int id)
    {
        var query = new GetByIdCandidateExperienceQuery(id);
        var candidate = await _mediator.Send(query);

        if (candidate is null)
            return new CandidateExperienceDto();

        return candidate;
    }

    public async Task<CandidateDto> CreateAsync(CreateCandidateCommand command)
    {
        var candidate = await _mediator.Send(command);

        return candidate;
    }

    public async Task<CandidateExperienceDto> CreateExperienceAsync(CreateCandidateExperienceCommand command)
    {
        var candidateExperience = await _mediator.Send(command);

        return candidateExperience;
    }

    public async Task<CandidateDto> UpdateAsync(int id, UpdateCandidateCommand command)
    {
        if (id != command.id) 
            return new CandidateDto();
        
        var candidate = await _mediator.Send(command);

        if (candidate is null)
            return new CandidateDto();

        return candidate;
    }

    public async Task<CandidateExperienceDto> UpdateExperienceAsync(int id, UpdateCandidateExperienceCommand command)
    {
        if (id != command.id)
            return new CandidateExperienceDto();

        var candidate = await _mediator.Send(command);

        if (candidate is null)
            return new CandidateExperienceDto();

        return candidate;
    }

    public async Task<bool> DeleteAsync(int id)
    {            
        var result = await _mediator.Send(new DeleteCandidateCommand(id));

        return result;
    }

    public async Task<bool> DeleteExperienceAsync(int id)
    {            
        var result = await _mediator.Send(new DeleteCandidateExperienceCommand(id));

        return result;
    }
}
