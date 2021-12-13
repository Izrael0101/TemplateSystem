using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using TemplateSystem.Entity.Models;
using TemplateSystem.Services;

namespace TemplateSystem.WebMvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        // GET: Student
        public async Task<ActionResult> Index()
        {
            IList<Student> stars = await _service.GetAllStarsAsync();

            return View(stars);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student star = await _service.GetStudentriptionByIdAsync(id);
            if (star == null)
            {
                return HttpNotFound();
            }
            return View(star);
        }

        // GET: Notes/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StarName,StarSize,StarDistanceFromSun,StarGalaxyName,StarBrightness,SpectralType")] Student stardesc)
        {
            if (ModelState.IsValid)
            {
                await _service.AddStarAsync(stardesc);

                return RedirectToAction("Index");
            }

            return View(stardesc);
        }

        // GET: Notes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student stardesc = await _service.GetStudentriptionByIdAsync(id);
            if (stardesc == null)
            {
                return HttpNotFound();
            }
            return View(stardesc);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,StarName,StarSize,StarDistanceFromSun,StarGalaxyName,StarBrightness,SpectralType")] Student stardesc)
        {
            if (ModelState.IsValid)
            {
                await _service.EditStudentAsync(stardesc);

                return RedirectToAction("Index");
            }
            return View(stardesc);
        }

        // GET: Notes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student stardesc = await _service.GetStudentriptionByIdAsync(id);
            if (stardesc == null)
            {
                return HttpNotFound();
            }
            return View(stardesc);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteStarAsync(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}