using ControleAlunosMVC.Models;
using ControleAlunosMVC.Models.ViewModels;
using ControleAlunosMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ControleAlunosMVC.Controllers
{
    public class ScoresController : Controller
    {
        private readonly SubjectsService _subjectsService;
        private readonly ScoreService _scoreService;
        private readonly StudentService _studentService;

        public ScoresController(SubjectsService subjectsService, ScoreService scoreService, StudentService studentService)
        {
            _subjectsService = subjectsService;
            _scoreService = scoreService;
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            var scoreList = await _scoreService.FindAllAsync();
            var students = await _studentService.FindAllAsync();
            var subjects = await _subjectsService.FindAllAsync();
            var viewModel = new ScoreFormViewModel { Scores = scoreList, Students = students, Subjects = subjects };

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var studens = await _studentService.FindAllAsync();
            var subjects = await _subjectsService.FindAllAsync();
            var viewModel = new ScoreFormViewModel { Students = studens, Subjects = subjects };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Score score)
        {
            if (!ModelState.IsValid)
            {
                var students = await _studentService.FindAllAsync();
                var subjects = await _subjectsService.FindAllAsync();
                var viewModel = new ScoreFormViewModel { Students = students, Subjects = subjects };
                return View(viewModel);
            }

            await _scoreService.InsertAsync(score);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _scoreService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _scoreService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _scoreService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj = await _scoreService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            List<Student> students = await _studentService.FindAllAsync();
            List<Subject> subjects = await _subjectsService.FindAllAsync();
            var viewModel = new ScoreFormViewModel { Score = obj, Students = students, Subjects = subjects };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Score score)
        {
            if (!ModelState.IsValid)
            {
                var students = await _studentService.FindAllAsync();
                var subjects = await _subjectsService.FindAllAsync();
                var viewModel = new ScoreFormViewModel { Score = score, Students = students, Subjects = subjects };
                return View(viewModel);
            }
            if (id != score.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não compatível" });
            }
            try
            {
                await _scoreService.UpdateAsync(score);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }

    }
}
