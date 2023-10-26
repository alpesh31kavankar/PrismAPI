using PrismAPI.DAL;
using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;

using System.Net.Http;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
//using System.Web.Mvc;

namespace PrismAPI.Controllers
{
    public class AboutController : ApiController
    {
        public Logger Log = null;
        public AboutController()
        {
            Log = Logger.GetLogger();
        }

        AboutDAL AboutDAL = new AboutDAL();

        [HttpGet]
        [ActionName("GetAllAbout")]
        public List<About> GetAllAbout()
        {
            Log.writeMessage("AboutController GetAllClient Start");
            List<About> list = null;
            try
            {
                list = AboutDAL.GetAllAbout();
            }
            catch (Exception ex)
            {
                Log.writeMessage("AboutController GetAllAboutError " + ex.Message);
            }
            Log.writeMessage("AboutController GetAllAbout End");
            return list;
        }
        [HttpGet]
        [ActionName("GetAboutById")]
        public About GetAboutById(int Id)
        {
            Log.writeMessage("AboutController GetAboutById Start");
            About about = null;
            try
            {
                about = AboutDAL.GetAboutById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("AboutController GetAboutById Error " + ex.Message);
            }
            Log.writeMessage("AboutController GetAboutById End");
            return about;
        }
        [HttpPost]
        [ActionName("AddAbout")]
        public IHttpActionResult AddAbout(About about)
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

                about.CreatedBy = "Admin";
                about.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                about.UpdatedBy = "Admin";
                //contact.Status = "Success";
                about.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = AboutDAL.AddAbout(about);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("AboutController AddAbout Error " + ex.Message);
            }
            return Ok(result);
        }
        [HttpPost]
        [ActionName("UpdateAbout")]
        public IHttpActionResult UpdateAbout(About about)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                about.CreatedBy = "Admin";
                about.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                about.UpdatedBy = "Admin";
                about.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = AboutDAL.UpdateAbout(about);


                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("AboutController AddAbout Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpDelete]
        public IHttpActionResult DeleteAbout(int Id)
        {
            try
            {
                var result = AboutDAL.DeleteAbout(Id);

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
                Log.writeMessage("AboutController DeleteAbout Error " + ex.Message);
            }
            return Ok("Failed");
        }


        [HttpPost]
        public async Task<IHttpActionResult> SaveAboutImage(int Id)
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
                    string newFilename = filename.StartsWith("AboutImage") ? "AboutImage.jpg" :
                                         filename.StartsWith("VisionImage") ? "VisionImage.jpg" :
                                         filename.StartsWith("VisionImage") ? "MissionImage.jpg" :
                                         filename.StartsWith("VisionImage") ? "ValuesImage.jpg" : filename;
                    File.WriteAllBytes(theDirectory + "/Content/About" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var about = AboutDAL.GetAboutById(Id);
                    var filenamenew = Id + "_" + newFilename;

                    if (filename.StartsWith("AboutImage"))   // condition
                    {
                        if (about.AboutImage.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/About" + "/" + about.AboutImage);
                            about.AboutImage = filenamenew;
                            var result = AboutDAL.UpdateAbout(about);
                        }
                    }
                    if (filename.StartsWith("VisionImage"))
                    {
                        if (about.VisionImage.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/About" + "/" + about.VisionImage);
                            about.VisionImage = filenamenew;
                            var result = AboutDAL.UpdateAbout(about);
                        }
                    }
                    if (filename.StartsWith("MissionImage"))
                    {
                        if (about.MissionImage.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/About" + "/" + about.MissionImage);
                            about.MissionImage = filenamenew;
                            var result = AboutDAL.UpdateAbout(about);
                        }
                    }

                    if (filename.StartsWith("ValuesImage"))
                    {
                        if (about.ValuesImage.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/About" + "/" + about.ValuesImage);
                            about.ValuesImage = filenamenew;
                            var result = AboutDAL.UpdateAbout(about);
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

       /* [HttpPost]
        public async Task<IHttpActionResult>SaveAboutImage(int Id)
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
                    var buffer = await file.ReadAsByteArrayAsync();
                    string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
                    //get the folder that's in
                    string theDirectory = Path.GetDirectoryName(fullPath);
                    theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));
                    File.WriteAllBytes(theDirectory + "/Content/About" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    //            // get existing rocrd
                    var about = AboutDAL.GetAboutById(Id);
                    var filenamenew = Id + "_" + filename;

                    if (filename.StartsWith("AboutImage"))
                    {
                        if (about.AboutImage.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/About" + "/" + about.AboutImage);
                            about.AboutImage = Id + "_" + filename;
                            var result = AboutDAL.UpdateAbout(about);
                        }

                    }
                    if (filename.StartsWith("VisionImage"))
                    {
                        if (about.VisionImage.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/About" + "/" + about.VisionImage);
                            about.VisionImage = Id + "_" + filename;
                            var result = AboutDAL.UpdateAbout(about);
                        }
                    }
                    if (filename.StartsWith("MissionImage"))
                    {
                        if (about.MissionImage.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/About" + "/" + about.MissionImage);
                            about.MissionImage = Id + "_" + filename;
                            var result = AboutDAL.UpdateAbout(about);
                        }
                    }
                    if (filename.StartsWith("ValuesImage"))
                    {
                        if (about.ValuesImage.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/About" + "/" + about.ValuesImage);
                            about.ValuesImage = Id + "_" + filename;
                            var result = AboutDAL.UpdateAbout(about);
                        }
                    }

                    *//*   string extension = Path.GetExtension(filenamenew);
                       if (extension != ".jpg")
                       {

                           if (about.AboutImage.ToLower() != filenamenew.ToLower())
                           {
                               File.Delete(theDirectory + "/Content/About" + "/" + about.AboutImage);
                               about.AboutImage = Id + "_" + filename;
                               var result = AboutDAL.UpdateAbout(about);

                           }


                       }
                       else
                       {
                           if (about.VisionImage.ToLower() != filenamenew.ToLower())
                           {
                               File.Delete(theDirectory + "/Content/About" + "/" + about.VisionImage);
                               about.VisionImage = Id + "_" + filename;
                               var result = AboutDAL.UpdateAbout(about);

                           }


                       }
                       if (extension != ".jpg")
                       {

                           if (about.MissionImage.ToLower() != filenamenew.ToLower())
                           {
                               File.Delete(theDirectory + "/Content/About" + "/" + about.MissionImage);
                               about.MissionImage = Id + "_" + filename;
                               var result = AboutDAL.UpdateAbout(about);

                           }


                       }
                       else
                       {
                           if (about.ValuesImage.ToLower() != filenamenew.ToLower())
                           {
                               File.Delete(theDirectory + "/Content/About" + "/" + about.ValuesImage);
                               about.ValuesImage = Id + "_" + filename;
                               var result = AboutDAL.UpdateAbout(about);

                           }


                       }*//*
                }
            }
            catch (Exception ex)
            {
                Log.writeMessage(ex.Message);
            }

            return Ok();

        }*/
    }
}