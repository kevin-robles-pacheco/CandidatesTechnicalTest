using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechnicalTest.Domain.DTOs;

public class CandidateExperienceDto
{
    public int IdCandidateExperience { get; set; }
    public int IdCandidate { get; set; }
    [MaxLength(100)]
    public string Company { get; set; }
    [MaxLength(100)]
    public string Job { get; set; }
    [MaxLength(4000)]
    public string Description { get; set; }
    [Column(TypeName = "decimal(8, 2)")]
    public decimal Salary { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime InsertDate { get; set; }
    public DateTime? ModifyDate { get; set; }
}
