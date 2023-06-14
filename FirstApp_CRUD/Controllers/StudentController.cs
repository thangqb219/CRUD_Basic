using FirstApp_CRUD.Data;
using FirstApp_CRUD.Models;
using FirstApp_CRUD.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstApp_CRUD.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDBContext studentDBContext;
        public StudentController(StudentDBContext studentDBContext)
        {
            this.studentDBContext = studentDBContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var student = await studentDBContext.Students.ToListAsync();
            return View(student);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel addStudentRequest)
        {
            var student = new Student()
            {
                Id = Guid.NewGuid(),
                Name = addStudentRequest.Name,
                Birthday = addStudentRequest.Birthday,
                Address = addStudentRequest.Address,
                Faculty = addStudentRequest.Faculty
            };
            await studentDBContext.Students.AddAsync(student);
            await studentDBContext.SaveChangesAsync();
            return RedirectToAction("Index");


        }
        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var student = await studentDBContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student != null)
            {
                var ViewModel = new UpdateStudentViewModel()
                {
                    Id = student.Id,
                    Name = student.Name,
                    Birthday = student.Birthday,
                    Address = student.Address,
                    Faculty = student.Faculty
                };
                return await Task.Run(() => View("View", ViewModel));
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateStudentViewModel model)
        {
            var student = await studentDBContext.Students.FindAsync(model.Id);
            if (student != null)
            {
                student.Id = model.Id;
                student.Name = model.Name;
                student.Birthday = model.Birthday;
                student.Address = model.Address;
                student.Faculty = model.Faculty;

                await studentDBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(UpdateStudentViewModel model)
        {
            var student = await studentDBContext.Students.FindAsync(model.Id);
            if (student != null)
            {
                studentDBContext.Students.Remove(student);
                await studentDBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
