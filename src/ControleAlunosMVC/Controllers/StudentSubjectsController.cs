using ControleAlunosMVC.Models;
using ControleAlunosMVC.Models.ViewModels;
using ControleAlunosMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ControleAlunosMVC.Controllers
{
    public class StudentSubjectsController : Controller
    {
        private readonly StudentService _studentService;
        private readonly SubjectsService _subjectsService;
        private readonly StudantSubjectService _studantSubjectService;

        public StudentSubjectsController(StudentService studentService, SubjectsService subjectsService, StudantSubjectService studantSubjectService)
        {
            _studentService = studentService;
            _subjectsService = subjectsService;
            _studantSubjectService = studantSubjectService;
        }

        public async Task<IActionResult> Index()
        {
            var studantSubjects = await _studantSubjectService.FindAllAsync();
            var students = await _studentService.FindAllAsync();
            var subjects = await _subjectsService.FindAllAsync();
            var viewModel = new StudentSubjectViewModel { Students = students, StudentSubjects = studantSubjects, Subjects = subjects};

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var studens = await _studentService.FindAllAsync();
            var subjects = await _subjectsService.FindAllAsync();
            var viewModel = new StudentSubjectViewModel { Students = studens, Subjects = subjects };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentSubject studentSubject)
        {
            if (!ModelState.IsValid)
            {
                var students = await _studentService.FindAllAsync();
                var subjects = await _subjectsService.FindAllAsync();
                var viewModel = new StudentSubjectViewModel { Students = students, Subjects = subjects };
                return View(viewModel);
            }

            await _studantSubjectService.InsertAsync(studentSubject);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id, int id2)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _studantSubjectService.FindByKeyAsync(id2, id);

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
            await _studantSubjectService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id, int id2)
        {
            if (id == null) 
            {
                return RedirectToAction(nameof(Error), new { message = "Id da matricula não fornecido" });
            }
            if (id2 == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id do aluno não fornecido" });
            }

            var obj = await _studantSubjectService.FindByKeyAsync(id2, id);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Item não encontrado" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,int? id2, StudentSubject obj)
        {
            if (!ModelState.IsValid)
            {
                var students = await _studentService.FindAllAsync();
                var subjects = await _subjectsService.FindAllAsync();
                var viewModel = new StudentSubjectViewModel { Students = students, Subjects = subjects };
                return View(viewModel);
            }
            if (id2 != obj.StudentId && id != obj.SubjectId) 
            {
                return RedirectToAction(nameof(Error), new { message = "Item não encontrado" });
            }
            try
            {
                await _studantSubjectService.UpdateAsync(obj);
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
