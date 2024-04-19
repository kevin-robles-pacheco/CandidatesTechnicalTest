using System.ComponentModel.DataAnnotations;

namespace TechnicalTest.Domain.DTOs;

public class CandidateDto
{
    public int IdCandidate { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(150)]
    public string Surname { get; set; }
    public DateTime Birthdate { get; set; }
    [MaxLength(250)]
    public string Email { get; set; }
    public DateTime InsertDate { get; set; }
    public DateTime? ModifyDate { get; set; }
    public List<CandidateExperienceDto> Experiences { get; set; }
}
