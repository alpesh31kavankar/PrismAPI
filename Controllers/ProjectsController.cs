using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using PrismAPI.DAL;
using PrismAPI.Models;
//using System.Web.Mvc;

namespace PrismAPI.Controllers
{
    public class ProjectsController : ApiController
    {
        public Logger Log = null;
        public ProjectsController()
        {
            Log = Logger.GetLogger();
        }

        ProjectsDAL projectsDAL = new ProjectsDAL();

        [HttpGet]
        [ActionName("GetAllProjects")]
        public List<Projects> GetAllProjects()
        {
            Log.writeMessage("ProjectsController GetAllProjects Start");
            List<Projects> list = null;
            try
            {
                list = projectsDAL.GetAllProjects();
            }
            catch (Exception ex)
            {
                Log.writeMessage("ProjectsController GetAllProjects  Error " + ex.Message);
            }
            Log.writeMessage("ProjectsController GetAllProjects  End");
            return list;
        }
        [HttpGet]
        [ActionName("GetProjectsById")]
        public Projects GetProjectsById(int Id)
        {
            Log.writeMessage("ProjectsController GetProjectsById Start");
            Projects projects = null;
            try
            {
                projects = projectsDAL.GetProjectsById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("ProjectsController GetProjectsById Error " + ex.Message);
            }
            Log.writeMessage("ProjectsController GetProjectsById End");
            return projects;
        }
        [HttpPost]
        [ActionName("AddProjects")]
        public IHttpActionResult AddProjects(Projects projects)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                //mainCategory.MainCategoryName = "MainCategoryName";
                //mainCategory.MainCategoryDescription = "MainCategoryDescription";

                projects.CreatedBy = "Admin";
                projects.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                projects.UpdatedBy = "Admin";
                //contact.Status = "Success";
                projects.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = projectsDAL.AddProjects(projects);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ProjectsController AddProjects  Error " + ex.Message);
            }
            return Ok(result);
        }
        [HttpPost]
        [ActionName("UpdateProjects")]
        public IHttpActionResult UpdateProjects(Projects projects)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                projects.CreatedBy = "Admin";
                projects.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                projects.UpdatedBy = "Admin";
                projects.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = projectsDAL.UpdateProjects(projects);


                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ProjectsController AddProjects Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpDelete]
        public IHttpActionResult DeleteProjects(int Id)
        {
            try
            {
                var result = projectsDAL.DeleteProjects(Id);

                if (result == "Success")
                {
                    return Ok("Success");
                }
                else
                {
                    return Ok("Failed");
                }
            }
            catch (Exception ex)
            {
                Log.writeMessage("projectsController DeleteProjects Error " + ex.Message);
            }
            return Ok("Failed");
        }


       /* [HttpPost]
        public async Task<IHttpActionResult>SaveProjectsImage(int Id)
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);
                foreach (var file in provider.Contents)
                {
                    var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                    //var filename1 = file.Headers.ContentDisposition.FileName.Trim('\"');
                    var buffer = await file.ReadAsByteArrayAsync();
                    string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
                    //get the folder that's in
                    string theDirectory = Path.GetDirectoryName(fullPath);
                    theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));
                    File.WriteAllBytes(theDirectory + "/Content/Projects" + "/" + Id + "_" + filename, buffer);
                    // Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    //var chat = new Chat();
                    var projects = projectsDAL.GetProjectsById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (filename.StartsWith("ProjectLogo"))
                    {
                        if (projects.ProjectLogo.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Projects" + "/" + projects.ProjectLogo);
                            projects.ProjectLogo = Id + "_" + filename;
                            var result = projectsDAL.UpdateProjects(projects);
                        }

                    }
                    if (filename.StartsWith("ProImage"))
                    {
                        if (projects.ProImage.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Projects" + "/" + projects.ProImage);
                            projects.ProImage = Id + "_" + filename;
                            var result = projectsDAL.UpdateProjects(projects);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Log.writeMessage(ex.Message);
            }

            return Ok();

        }*/


        [HttpPost]
        public async Task<IHttpActionResult> SaveProjectsImage(int Id)
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);
                foreach (var file in provider.Contents)
                {
                    var filename = file.Headers.ContentDisposition.FileName.Trim('\"');   // image name

                    var buffer = await file.ReadAsByteArrayAsync();
                    string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
                    //get the folder that's in
                    string theDirectory = Path.GetDirectoryName(fullPath);
                    theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));
                    string newFilename = filename.StartsWith("ProjectLogo") ? "ProjectLogo.jpg" :
                                         filename.StartsWith("ProImage") ? "ProImage.jpg" : filename;
                    File.WriteAllBytes(theDirectory + "/Content/Projects" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var projects = projectsDAL.GetProjectsById(Id);
                    var filenamenew = Id + "_" + newFilename;

                    if (filename.StartsWith("ProjectLogo"))   // condition
                    {
                        if (projects.ProjectLogo.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Projects" + "/" + projects.ProjectLogo);
                            projects.ProjectLogo = filenamenew;
                            var result = projectsDAL.UpdateProjects(projects);
                        }
                    }
                    if (filename.StartsWith("ProImage"))
                    {
                        if (projects.ProImage.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Projects" + "/" + projects.ProImage);
                            projects.ProImage = filenamenew;
                            var result = projectsDAL.UpdateProjects(projects);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.writeMessage(ex.Message);
            }

            return Ok();
        }
    }
}