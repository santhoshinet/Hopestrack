using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hopestrack.Models;
using HopestrackDL;

namespace Hopestrack.Controllers
{
    public class ControlpanelController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult Menus()
        {
            if (User.Identity.IsAuthenticated)
            {
                var scope = ObjectScopeProvider1.GetNewObjectScope();
                ViewData["menus"] = (from c in scope.GetOqlQuery<Menu>().ExecuteEnumerable()
                                     where c.ParentId.Equals(string.Empty)
                                     select c).ToList();
                return View(new MenuModel());
            }
            return RedirectToAction("LogOn", "Account");
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddMenu()
        {
            if (User.Identity.IsAuthenticated)
            {
                var scope = ObjectScopeProvider1.GetNewObjectScope();
                ViewData["ContentPages"] = (from c in scope.GetOqlQuery<ContentPage>().ExecuteEnumerable()
                                            select c).ToList();
                return View(new MenuModel());
            }
            return RedirectToAction("LogOn", "Account");
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddMenu(MenuModel menuModel)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    var scope = ObjectScopeProvider1.GetNewObjectScope();
                    ViewData["ContentPages"] = (from c in scope.GetOqlQuery<ContentPage>().ExecuteEnumerable()
                                                select c).ToList();
                    List<Menu> menus = (from c in scope.GetOqlQuery<Menu>().ExecuteEnumerable()
                                        where c.Name.ToLower().Equals(menuModel.MenuName.ToLower().Trim())
                                        select c).ToList();
                    if (menus.Count == 0)
                    {
                        var contentPages = (from c in scope.GetOqlQuery<ContentPage>().ExecuteEnumerable()
                                            where c.Id.Equals(Request.Form["CmbPages"])
                                            select c).ToList();
                        if (contentPages.Count > 0)
                        {
                            scope.Transaction.Begin();
                            var menu = new Menu
                            {
                                Name = menuModel.MenuName,
                                Page = contentPages[0]
                            };
                            scope.Add(menu);
                            scope.Transaction.Commit();
                            return RedirectToAction("Menus");
                        }
                        ModelState.AddModelError("", "The Link page is not selected.");
                    }
                    else
                        ModelState.AddModelError("Menu name", "The given menu is already exists");
                }
                return View(menuModel);
            }
            return RedirectToAction("LogOn", "Account");
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditMenu(string mid)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");
            if (!string.IsNullOrEmpty(mid))
            {
                var scope = ObjectScopeProvider1.GetNewObjectScope();
                var contentPages = (from c in scope.GetOqlQuery<ContentPage>().ExecuteEnumerable()
                                    select c).ToList();
                ViewData["ContentPages"] = contentPages;
                ViewData["Pagename"] = string.Empty;
                var menus = (from c in scope.GetOqlQuery<Menu>().ExecuteEnumerable()
                             where c.Id != null && c.Id.Equals(mid)
                             select c).ToList();
                if (menus.Count > 0)
                {
                    var menuModel = new MenuModel
                                        {
                                            MenuName = menus[0].Name,
                                            Id = menus[0].Id
                                        };
                    foreach (ContentPage contentPage in contentPages)
                    {
                        if (contentPage.Name.ToLower().Equals(menus[0].Page.Name.ToLower()))
                        {
                            ViewData["Pagename"] = contentPage.Name;
                            break;
                        }
                    }
                    return View(menuModel);
                }
            }
            return RedirectToAction("Menus");
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditMenu(MenuModel menuModel)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");
            if (ModelState.IsValid)
            {
                var scope = ObjectScopeProvider1.GetNewObjectScope();
                var menus = (from c in scope.GetOqlQuery<Menu>().ExecuteEnumerable()
                             where c.Id != null && c.Id.Equals(menuModel.Id)
                             select c).ToList();
                if (menus.Count > 0)
                {
                    var contentPages = (from c in scope.GetOqlQuery<ContentPage>().ExecuteEnumerable()
                                        where c.Id.Equals(Request.Form["CmbPages"])
                                        select c).ToList();
                    if (contentPages.Count > 0)
                    {
                        foreach (Menu menu in menus)
                        {
                            scope.Transaction.Begin();
                            menu.Name = menuModel.MenuName;
                            menu.Page = contentPages[0];
                            scope.Add(menu);
                            scope.Transaction.Commit();
                        }
                    }
                }
            }
            return RedirectToAction("Menus");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Pages()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");
            var scope = ObjectScopeProvider1.GetNewObjectScope();
            var pages = (from c in scope.GetOqlQuery<ContentPage>().ExecuteEnumerable()
                         select c).ToList();
            ViewData["webpageList"] = pages;
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Images()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");
            LoadImages();
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult InsertImage()
        {
            LoadImages();
            return View(new ImageModel());
        }

        private void LoadImages()
        {
            var scope = ObjectScopeProvider1.GetNewObjectScope();
            var files = (from c in scope.GetOqlQuery<HopestrackDL.File>().ExecuteEnumerable()
                         select c).ToList();
            ViewData["fileList"] = files;
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditPage(string pid)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");
            if (pid != null)
            {
                var scope = ObjectScopeProvider1.GetNewObjectScope();
                var pages = (from c in scope.GetOqlQuery<ContentPage>().ExecuteEnumerable()
                             where c.Id != null && c.Id.Equals(pid)
                             select c).ToList();
                var contentPage = new PageModel();
                foreach (ContentPage page in pages)
                {
                    contentPage.PageTitle = page.Name;
                    contentPage.Content = page.Content;
                    contentPage.ID = page.Id;
                    break;
                }
                return View(contentPage);
            }
            return RedirectToAction("Pages");
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddPage()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");
            return View(new PageModel());
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddImage()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");
            return View(new ImageModel());
        }

        [Authorize]
        [HttpGet]
        public ActionResult Ajaxaddimage()
        {
            ViewData["Status"] = "";
            return View(new ImageModel());
        }

        [Authorize]
        [HttpPost]
        public ActionResult Ajaxaddimage(ImageModel file, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                var scope = ObjectScopeProvider1.GetNewObjectScope();
                scope.Transaction.Begin();
                var productFile = new HopestrackDL.File { Filename = image.FileName };
                Stream fileStream = image.InputStream;
                int fileLength = image.ContentLength;
                productFile.Filedata = new byte[fileLength];
                fileStream.Read(productFile.Filedata, 0, fileLength);
                productFile.MimeType = image.ContentType;
                productFile.Id = DateTime.Now.Ticks.ToString();
                scope.Add((productFile));
                scope.Transaction.Commit();
                ViewData["Status"] = "Image added successfully.";
                return View(new ImageModel());
            }
            return View(file);
        }

        [Authorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult EditPage(PageModel pageModel)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");
            if (ModelState.IsValid)
            {
                var scope = ObjectScopeProvider1.GetNewObjectScope();
                var pages = (from c in scope.GetOqlQuery<ContentPage>().ExecuteEnumerable()
                             where c.Id != null && c.Id.Equals(pageModel.ID)
                             select c).ToList();
                foreach (ContentPage page in pages)
                {
                    scope.Transaction.Begin();
                    page.Name = pageModel.PageTitle;
                    page.Content = pageModel.Content;
                    scope.Add(page);
                    scope.Transaction.Commit();
                    try
                    {
                        using (var connection = new SqlConnection("Data Source=208.91.198.196;Initial Catalog=admin_hopestrack;Persist Security Info=True;User ID=hopestrack;Password=password@123"))
                        {
                            connection.Open();
                            string qry = "update content_page set [<_content>k___backing_field] = '" + pageModel.Content + "' where [<_id>k___backing_field]='" + page.Id + "'";
                            var command = new SqlCommand(qry, connection);
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    break;
                }
                return RedirectToAction("Pages");
            }
            return View(pageModel);
        }

        [Authorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult AddPage(PageModel adPageModel)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");
            if (ModelState.IsValid)
            {
                var scope = ObjectScopeProvider1.GetNewObjectScope();
                var contentPage = new ContentPage { Name = adPageModel.PageTitle, Content = adPageModel.Content, Id = DateTime.Now.Ticks.ToString() };
                scope.Transaction.Begin();
                scope.Add(contentPage);
                scope.Transaction.Commit();
                try
                {
                    using (var connection = new SqlConnection("Data Source=208.91.198.196;Initial Catalog=admin_hopestrack;Persist Security Info=True;User ID=hopestrack;Password=password@123"))
                    {
                        connection.Open();
                        string qry = "update content_page set [<_content>k___backing_field] = '" + adPageModel.Content + "' where [<_id>k___backing_field]='" + contentPage.Id + "'";
                        var command = new SqlCommand(qry, connection);
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("Pages");
                }
                return RedirectToAction("Pages");
            }
            return View(adPageModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddImage(ImageModel file, HttpPostedFileBase image)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");
            if (ModelState.IsValid)
            {
                var scope = ObjectScopeProvider1.GetNewObjectScope();
                scope.Transaction.Begin();
                var productFile = new HopestrackDL.File { Filename = image.FileName };
                Stream fileStream = image.InputStream;
                int fileLength = image.ContentLength;
                productFile.Filedata = new byte[fileLength];
                fileStream.Read(productFile.Filedata, 0, fileLength);
                productFile.MimeType = image.ContentType;
                productFile.Id = DateTime.Now.Ticks.ToString();
                scope.Add((productFile));
                scope.Transaction.Commit();
                return RedirectToAction("Images");
            }
            return View(file);
        }

        [Authorize]
        public ActionResult DeletePage(string pid)
        {
            var scope = ObjectScopeProvider1.GetNewObjectScope();
            var pages = (from c in scope.GetOqlQuery<ContentPage>().ExecuteEnumerable()
                         where c.Id != null && c.Id.Equals(pid)
                         select c).ToList();
            foreach (var contentPage in pages)
            {
                scope.Transaction.Begin();
                scope.Remove(contentPage);
                scope.Transaction.Commit();
            }
            return RedirectToAction("Pages");
        }

        [Authorize]
        public ActionResult DeleteImage(string id)
        {
            var scope = ObjectScopeProvider1.GetNewObjectScope();
            var images = (from c in scope.GetOqlQuery<HopestrackDL.File>().ExecuteEnumerable()
                          where c.Id.Equals(id)
                          select c).ToList();
            foreach (var image in images)
            {
                scope.Transaction.Begin();
                scope.Remove(image);
                scope.Transaction.Commit();
            }
            return RedirectToAction("Images");
        }

        [Authorize]
        [HttpGet]
        public ActionResult DeleteMenu(string mid)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");
            if (ModelState.IsValid)
            {
                var scope = ObjectScopeProvider1.GetNewObjectScope();
                var menus = (from c in scope.GetOqlQuery<Menu>().ExecuteEnumerable()
                             where c.Id != null && c.Id.Equals(mid)
                             select c).ToList();
                if (menus.Count > 0)
                {
                    foreach (Menu menu in menus)
                    {
                        scope.Transaction.Begin();
                        scope.Remove(menu);
                        scope.Transaction.Commit();
                    }
                }
            }
            return RedirectToAction("Menus");
        }
    }
}