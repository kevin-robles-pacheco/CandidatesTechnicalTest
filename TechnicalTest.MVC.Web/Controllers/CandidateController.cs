using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Business.Services;
using TechnicalTest.Infraestructure.Services.Candidates.Commands;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TechnicalTest.MVC.Web.Controllers;

public class CandidateController : Controller
{
    CandidateServices _candidateServices;

    public CandidateController(CandidateServices candidateServices)
    {
        _candidateServices = candidateServices;
    }

    // GET: CandidateController
    public async Task<IActionResult> Index()
    {
        var candidates = await _candidateServices.GetAllAsync();
        return View(candidates);
    }

    // GET: CandidateController/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var candidate = await _candidateServices.GetByIdAsync(id);

        return View(candidate);
    }

    // GET: CandidateController/Create
    public async Task<IActionResult> Create()
    {
        return View();
    }

    // POST: CandidateController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateCandidateCommand command)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var candidate = await _candidateServices.CreateAsync(command);

                return RedirectToAction(nameof(Index));
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Error creating candidate: " + ex.Message);
        }
        return View(command);
    }
    
    // GET: Candidate/CreateExperience
    public IActionResult CreateExperience(int id)
    {
        ViewBag.CandidateId = id;
        return View();
    }

    // POST: Candidate/CreateExperience
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateExperience([Bind("Company,Job,Description,BeginDate,EndDate,Salary,IdCandidate")] CreateCandidateExperienceCommand experience)
    {
        if (ModelState.IsValid)
        {
            await _candidateServices.CreateExperienceAsync(experience);
            return RedirectToAction("Details", new { id = experience.IdCandidate });
        }
        return View(experience);
    }

    // GET: CandidateController/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var candidate = await _candidateServices.GetByIdAsync(id);

        if (candidate is null)
        {
            return NotFound();
        }

        var command = new UpdateCandidateCommand(candidate.Name, candidate.Surname, candidate.Birthdate, candidate.Email, candidate.IdCandidate);

        return View(command);
    }

    // POST: CandidateController/Edit/
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateCandidateCommand command)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _candidateServices.UpdateAsync(command.id, command);

                return RedirectToAction(nameof(Index));
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Error updating candidate: " + ex.Message);
        }

        return View(command);
    }

    // GET: CandidateController/EditExperience/5
    public async Task<IActionResult> EditExperience(int id)
    {
        var experience = await _candidateServices.GetByIdExperienceAsync(id);

        if (experience is null)
        {
            return NotFound();
        }

        var command = new UpdateCandidateExperienceCommand(experience.IdCandidate, experience.Company, experience.Job, experience.Description, experience.Salary, experience.BeginDate, experience.EndDate, experience.IdCandidateExperience);

        return View(command);
    }

    // POST: CandidateController/EditExperience/
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditExperience(UpdateCandidateExperienceCommand experience)
    {
        if (ModelState.IsValid)
        {
            await _candidateServices.UpdateExperienceAsync(experience.id, experience);
            return RedirectToAction("Details", new { id = experience.IdCandidate });
        }

        return View(experience);
    }


    // GET: CandidateController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var candidate = await _candidateServices.GetByIdAsync(id);

        if (candidate is null)
        {
            return NotFound();
        }

        return View(candidate);
    }

    // POST: CandidateController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int IdCandidate)
    {
        try
        {
            var isDeleted = await _candidateServices.DeleteAsync(IdCandidate);

            if (isDeleted)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Error));
            }
        }
        catch (Exception ex)
        {
            return RedirectToAction(nameof(Error));
        }
    }

    // GET: Candidate/DeleteExperience/5
    public async Task<IActionResult> DeleteExperience(int id)
    {
        var experience = await _candidateServices.GetByIdExperienceAsync(id);

        if (experience is null)
        {
            return NotFound();
        }

        return View(experience);
    }

    // POST: Candidate/DeleteExperience/
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteExperienceConfirmed(int IdCandidateExperience)
    {
        try
        {
            var isDeleted = await _candidateServices.DeleteExperienceAsync(IdCandidateExperience);

            if (isDeleted)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Error));
            }
        }
        catch (Exception ex)
        {
            return RedirectToAction(nameof(Error));
        }
    }
}
