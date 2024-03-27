using Antlr.Runtime.Tree;
using MVC_MasterDetails_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MasterDetails_CRUD.Controllers
{
    public class ApplicantController : Controller
    {
        Client_ExperienceEntities1 db = new Client_ExperienceEntities1();

        // GET: Applicant
        public ActionResult Index()
        {   
            return View(db.Clients.ToList());
        }
        public ActionResult Create()
        {
            Client client = new Client();
            client.Experiences.Add(new Experience
            {
                Company = "",
                Designation = "",
                Year_Of_Experience = 0
            });

            return View(client);
        }
        [HttpPost]
        public ActionResult Create(Client client, string btn)
        {
            if (btn == "Add")
            {
                client.Experiences.Add(new Experience());
            }
            if (btn == "Create")
            {
                if (client.Picture != null)
                {
                    string ext = Path.GetExtension(client.Picture.FileName);
                    if (ext == ".jpg" || ext == ".png")
                    {
                        client.Total_Experience = client.Experiences.Sum(m => m.Year_Of_Experience);

                        string rootPath = Server.MapPath("~/");
                        string fileToSave = Path.Combine(rootPath, "Pictures", client.Picture.FileName);
                        client.Picture.SaveAs(fileToSave);
                        client.PicPath = "~/Pictures/" + client.Picture.FileName;
                        db.Clients.Add(client);
                        if (db.SaveChanges() > 0)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please Provide A Valid Image, Such As JPG Or PNG");
                        return View(client);
                    }
                }
            }
            return View(client);
        }
    
        
        public ActionResult Edit(int id)
        {
            Client client = db.Clients.Find(id);
            return View(client);
        }
 
        [HttpPost]
        public ActionResult Edit(Client client, string btn)
        {
            if (btn == "Add")
            {
                client.Experiences.Add(new Experience());
            }
            if (btn == "Update")
            {
                if (client.Picture != null)
                {
                    string ext = Path.GetExtension(client.Picture.FileName);
                    if (ext == ".jpg" || ext == ".png")
                    {
                        client.Total_Experience = client.Experiences.Sum(m => m.Year_Of_Experience);

                        string rootPath = Server.MapPath("~/");
                        string fileToSave = Path.Combine(rootPath, "Pictures", client.Picture.FileName);
                        client.Picture.SaveAs(fileToSave);
                        client.PicPath = "~/Pictures/" + client.Picture.FileName;
                        
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please Provide A Valid Image, Such As JPG Or PNG");
                        return View(client);
                    }
                }
                else
                {
                    client.PicPath = client.PicPath;
                }

                db.Clients.AddOrUpdate(client);
                if (db.SaveChanges() > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(client);
        }

        public ActionResult Delete(int id)
        {
            var applicant = db.Clients.Find(id);
            db.Clients.Remove(applicant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            List<Client> details = db.Clients.Where(m =>m.ClientId==id).ToList();
            
            //var Applica = db.Applicants.Include(applicant => applicant.Applicant_Exprience).ToList();
            return View(details);
        }
    }
}