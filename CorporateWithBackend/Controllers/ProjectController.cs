using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CorporateWithBackend.Models;
using CorporateWithBackend.ViewModels;

namespace CorporateWithBackend.Controllers
{
    public class ProjectController : Controller
    {
        private CorporateDBEntities db = new CorporateDBEntities();
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        public ActionResult Create()
        {
            NewProjectViewModel viewModel = new NewProjectViewModel
            {
                Project = new Project(),
                Categories = db.Categories.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Project project, HttpPostedFileBase upload)
        {
            Models.File file = new Models.File();
            string filename;
            if (upload != null && ModelState.IsValid)
            {
                file.file_data = new byte[upload.ContentLength];
                upload.InputStream.Read(file.file_data, 0, upload.ContentLength);
                file.name = upload.FileName;
                file.file_type = upload.ContentType;
                filename = upload.FileName;
                upload.SaveAs(Server.MapPath("~/Content/img/" + upload.FileName));
                db.Files.Add(file);
                db.SaveChanges();

                var selectedFile = db.Files.SingleOrDefault(f => f.name == filename);
                project.file_id = selectedFile.Id;
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Delete(int id)
        {
            var selectedItem = db.Projects.SingleOrDefault(p => p.Id == id);
            db.Projects.Remove(selectedItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var selectedItem = db.Projects.SingleOrDefault(p => p.Id == id);
            NewProjectViewModel viewModel = new NewProjectViewModel
            {
                Project = selectedItem,
                Categories = db.Categories.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Project project, HttpPostedFileBase upload, int id)
        {
            if (upload == null)
            {
                var selectedItem = db.Projects.SingleOrDefault(p => p.Id == id);
                selectedItem.name = project.name;
                selectedItem.description = project.description;
                selectedItem.file_id = project.file_id;
                selectedItem.category_id = project.category_id;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                Models.File file = new Models.File();
                string filename;
                file.file_data = new byte[upload.ContentLength];
                upload.InputStream.Read(file.file_data, 0, upload.ContentLength);
                file.name = upload.FileName;
                file.file_type = upload.ContentType;
                filename = upload.FileName;
                upload.SaveAs(Server.MapPath("~/Content/img/" + upload.FileName));
                if (db.Files.SingleOrDefault(f => f.name == filename) == null)
                {
                    db.Files.Add(file);
                    db.SaveChanges();
                    var selectedItem = db.Projects.SingleOrDefault(p => p.Id == id);
                    var selectedFile = db.Files.SingleOrDefault(f => f.name == filename);
                    selectedItem.name = project.name;
                    selectedItem.description = project.description;
                    selectedItem.file_id = selectedFile.Id;
                    selectedItem.category_id = project.category_id;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    var selectedItem = db.Projects.SingleOrDefault(p => p.Id == id);
                    selectedItem.name = project.name;
                    selectedItem.description = project.description;
                    selectedItem.file_id = db.Files.SingleOrDefault(f => f.name == filename).Id;
                    selectedItem.category_id = project.category_id;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
        }
    }
}