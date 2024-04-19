﻿namespace TechnicalTest.Domain.Models;

public class CandidateExperience
{
    public int IdCandidateExperience { get; set; }
    public int IdCandidate { get; set; }
    public string Company { get; set; }
    public string Job { get; set; }
    public string Description { get; set; }
    public int Salary { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime InsertDate { get; set; }
    public DateTime? ModifyDate { get; set; }
}
