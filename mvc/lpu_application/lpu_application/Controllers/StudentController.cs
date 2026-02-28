using lpu_application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lpu_application.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public StudentController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        // ── HOME PAGE ──
        public IActionResult Index()
        {
            return View();
        }

        // ── REGISTER GET ──
        public IActionResult Register()
        {
            return View();
        }

        // ── REGISTER POST ──
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Student student)
        {
            // Remove Password confirmation from validation
            ModelState.Remove("PhotoFile");

            if (ModelState.IsValid)
            {
                var existing = await _db.Students
                    .FirstOrDefaultAsync(s => s.Email == student.Email);

                if (existing != null)
                {
                    ModelState.AddModelError("Email", "Email already registered!");
                    return View(student);
                }

                // ✅ FIXED: Safe photo upload with null check
                if (student.PhotoFile != null && student.PhotoFile.Length > 0)
                {
                    try
                    {
                        string webRoot = _env.WebRootPath;

                        // ✅ Create wwwroot if it doesn't exist
                        if (string.IsNullOrEmpty(webRoot))
                        {
                            webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                        }

                        string uploadsFolder = Path.Combine(webRoot, "uploads");

                        if (!Directory.Exists(uploadsFolder))
                            Directory.CreateDirectory(uploadsFolder);

                        string uniqueFileName = Guid.NewGuid().ToString() + "_" +
                                               Path.GetFileName(student.PhotoFile.FileName);
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await student.PhotoFile.CopyToAsync(stream);
                        }

                        student.PhotoPath = "/uploads/" + uniqueFileName;
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Photo upload failed: " + ex.Message);
                        return View(student);
                    }
                }

                student.Password = BCrypt.Net.BCrypt.HashPassword(student.Password);
                student.CreatedAt = DateTime.Now;

                _db.Students.Add(student);
                await _db.SaveChangesAsync();

                student.RegistrationNo = "LPU" + DateTime.Now.Year +
                                         student.StudentId.ToString("D4");
                await _db.SaveChangesAsync();

                TempData["Success"] = "Registration Successful! Your ID: " + student.RegistrationNo;
                return RedirectToAction("Login");
            }

            return View(student);
        }

        // ── LOGIN GET ──
        public IActionResult Login()
        {
            return View();
        }

        // ── LOGIN POST ──
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            var student = await _db.Students
                .FirstOrDefaultAsync(s => s.Email == email);

            if (student != null && BCrypt.Net.BCrypt.Verify(password, student.Password))
            {
                HttpContext.Session.SetInt32("StudentId", student.StudentId);
                HttpContext.Session.SetString("StudentName", student.FirstName);
                HttpContext.Session.SetString("RegNo", student.RegistrationNo ?? "");
                return RedirectToAction("Dashboard");
            }

            TempData["Error"] = "Invalid email or password!";
            return View();
        }

        // ── DASHBOARD ──
        public async Task<IActionResult> Dashboard()
        {
            var id = HttpContext.Session.GetInt32("StudentId");
            if (id == null) return RedirectToAction("Login");

            var student = await _db.Students.FindAsync(id);
            if (student == null) return RedirectToAction("Login");
            return View(student);
        }

        // ── LOGOUT ──
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // ── EDIT GET ──
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        // ── EDIT POST ──
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student student)
        {
            ModelState.Remove("PhotoFile");
            ModelState.Remove("Password");

            if (ModelState.IsValid)
            {
                var existing = await _db.Students.FindAsync(student.StudentId);
                if (existing == null) return NotFound();

                existing.FirstName = student.FirstName;
                existing.LastName = student.LastName;
                existing.Phone = student.Phone;
                existing.DateOfBirth = student.DateOfBirth;
                existing.Gender = student.Gender;
                existing.Course = student.Course;
                existing.Branch = student.Branch;
                existing.Address = student.Address;

                if (student.PhotoFile != null && student.PhotoFile.Length > 0)
                {
                    try
                    {
                        string webRoot = _env.WebRootPath;
                        if (string.IsNullOrEmpty(webRoot))
                            webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

                        string uploadsFolder = Path.Combine(webRoot, "uploads");
                        if (!Directory.Exists(uploadsFolder))
                            Directory.CreateDirectory(uploadsFolder);

                        string uniqueFileName = Guid.NewGuid().ToString() + "_" +
                                               Path.GetFileName(student.PhotoFile.FileName);
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await student.PhotoFile.CopyToAsync(stream);
                        }

                        existing.PhotoPath = "/uploads/" + uniqueFileName;
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Photo upload failed: " + ex.Message);
                        return View(student);
                    }
                }

                await _db.SaveChangesAsync();
                TempData["Success"] = "Profile updated successfully!";
                return RedirectToAction("Dashboard");
            }

            return View(student);
        }

        // ── DELETE POST ──
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student != null)
            {
                _db.Students.Remove(student);
                await _db.SaveChangesAsync();
            }

            HttpContext.Session.Clear();
            TempData["Success"] = "Account deleted successfully!";
            return RedirectToAction("Index", "Home");
        }

        // ── ID CARD ──
        public async Task<IActionResult> IDCard(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }
    }
}
