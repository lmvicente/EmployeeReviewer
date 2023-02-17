using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;
using EmployeeReviewer;

namespace EmployeeReviewer.Controllers
{
    public class ReviewsController : Controller
    {
        private EmployeeReviewEntities db = new EmployeeReviewEntities();

        public async Task<ActionResult> Index(string SearchName, string ReviewerName)
        {
            if (db.vw_AllReviews == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var reviews = from r in db.vw_AllReviews
                          select r;


            if (!String.IsNullOrEmpty(SearchName))
            {
                reviews = reviews.Where(st => st.EmployeeName.Contains(SearchName));
            }

            if (!String.IsNullOrEmpty(ReviewerName))
            {
                reviews = reviews = reviews.Where(st => st.ReviewerName.Contains(ReviewerName));
            }

            return View(await reviews.ToListAsync());
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            Review review = new Review();

            review.CreateDate = DateTime.Now;

            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName");
            ViewBag.ReviewerId = new SelectList(db.vw_AllReviewers, "ReviewerId", "EmployeeName");
            ViewBag.ReviewType = new SelectList(db.ReviewTypes, "ReviewId", "ReviewType1");


            return View(review);
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewId,EmployeeId,ReviewerId,CreateDate,Summary,EmployeeSigned,EmployerSigned,ReviewType")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", review.EmployeeId);
            ViewBag.ReviewerId = new SelectList(db.vw_AllReviewers, "ReviewerId", "EmployeeName");
            ViewBag.ReviewType = new SelectList(db.ReviewTypes, "ReviewId", "ReviewType1", review.ReviewType);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", review.EmployeeId);
            ViewBag.ReviewerId = new SelectList(db.vw_AllReviewers, "ReviewerId", "EmployeeName");
            ViewBag.ReviewType = new SelectList(db.ReviewTypes, "ReviewId", "ReviewType1", review.ReviewType);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewId,EmployeeId,ReviewerId,CreateDate,Summary,EmployeeSigned,EmployerSigned,ReviewType")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", review.EmployeeId);
            ViewBag.ReviewerId = new SelectList(db.vw_AllReviewers, "ReviewerId", "EmployeeName");
            ViewBag.ReviewType = new SelectList(db.ReviewTypes, "ReviewId", "ReviewType1", review.ReviewType);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
