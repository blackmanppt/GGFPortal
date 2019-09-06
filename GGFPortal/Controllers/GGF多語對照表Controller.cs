using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GGFPortal.DataSetSource;
using GGFPortal.test;

namespace GGFPortal.Controllers
{
    public class GGF多語對照表Controller : Controller
    {
        //private GGFEntitiestest db = new GGFEntitiestest();
        private MISEntities db = new MISEntities();
        // GET: GGF多語對照表
        public ActionResult Index()
        {
            return View(db.GGF多語對照表.ToList());
        }

        // GET: GGF多語對照表/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GGF多語對照表 gGF多語對照表 = db.GGF多語對照表.Find(id);
            if (gGF多語對照表 == null)
            {
                return HttpNotFound();
            }
            return View(gGF多語對照表);
        }

        // GET: GGF多語對照表/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GGF多語對照表/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,程式,資料代號,中文,英文,越文,說明,建立時間,異動時間")] GGF多語對照表 gGF多語對照表)
        {
            if (ModelState.IsValid)
            {
                db.GGF多語對照表.Add(gGF多語對照表);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gGF多語對照表);
        }

        // GET: GGF多語對照表/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GGF多語對照表 gGF多語對照表 = db.GGF多語對照表.Find(id);
            if (gGF多語對照表 == null)
            {
                return HttpNotFound();
            }
            return View(gGF多語對照表);
        }

        // POST: GGF多語對照表/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,程式,資料代號,中文,英文,越文,說明,建立時間,異動時間")] GGF多語對照表 gGF多語對照表)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gGF多語對照表).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gGF多語對照表);
        }

        // GET: GGF多語對照表/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GGF多語對照表 gGF多語對照表 = db.GGF多語對照表.Find(id);
            if (gGF多語對照表 == null)
            {
                return HttpNotFound();
            }
            return View(gGF多語對照表);
        }

        // POST: GGF多語對照表/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GGF多語對照表 gGF多語對照表 = db.GGF多語對照表.Find(id);
            db.GGF多語對照表.Remove(gGF多語對照表);
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
