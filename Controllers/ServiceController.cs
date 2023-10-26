using PrismAPI.DAL;
using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
//using System.Web.Http;
using System.Net.Http;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
//using System.Web.Mvc;

namespace PrismAPI.Controllers
{
    public class ServiceController :ApiController
    {
        public Logger Log = null;
        public ServiceController()
        {
            Log = Logger.GetLogger();
        }

        ServiceDAL ServiceDAL = new ServiceDAL();

        [HttpGet]
        [ActionName("GetAllService")]
        public List<Service> GetAllService()
        {
            Log.writeMessage("ServiceController GetAllService Start");
            List<Service> list = null;
            try
            {
                list = ServiceDAL.GetAllService();
            }
            catch (Exception ex)
            {
                Log.writeMessage("ServiceController GetAllServiceError " + ex.Message);
            }
            Log.writeMessage("ServiceController GetAllService End");
            return list;
        }
        [HttpGet]
        [ActionName("GetServiceById")]
        public Service GetServiceById(int Id)
        {
            Log.writeMessage("ServiceController GetServiceById Start");
            Service service = null;
            try
            {
                service = ServiceDAL.GetServiceById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("ServiceController GetServiceById Error " + ex.Message);
            }
            Log.writeMessage("ServiceController GetServiceById End");
            return service;
        }
        [HttpPost]
        [ActionName("AddService")]
        public IHttpActionResult AddService(Service service)
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

                service.CreatedBy = "Admin";
                service.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                service.UpdatedBy = "Admin";
                //contact.Status = "Success";
                service.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = ServiceDAL.AddService(service);



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
        [ActionName("UpdateService")]
        public IHttpActionResult UpdateService(Service service)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                service.CreatedBy = "Admin";
                service.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                service.UpdatedBy = "Admin";
                service.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = ServiceDAL.UpdateService(service);


                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("serviceController Addservice Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpDelete]
        public IHttpActionResult DeleteService(int Id)
        {
            try
            {
                var result = ServiceDAL.DeleteService(Id);

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
                Log.writeMessage("ServiceController DeleteService Error " + ex.Message);
            }
            return Ok("Failed");
        }

       /* [HttpPost]
        public async Task<IHttpActionResult> SaveServiceImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/Service" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    //            // get existing rocrd
                    var Service = ServiceDAL.GetServiceById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (Service.Image.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/Service" + "/" + Service.Image);
                        Service.Image = Id + "_" + filename;
                        var result = ServiceDAL.UpdateService(Service);

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
        public async Task<IHttpActionResult> SaveServiceImage(int Id)
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
                    string newFilename = filename.StartsWith("Image") ? "Image.jpg" : filename;
                    File.WriteAllBytes(theDirectory + "/Content/Service" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var Service = ServiceDAL.GetServiceById(Id);
                    var filenamenew = Id + "_" + newFilename;
                    if (Service.Image.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/Service" + "/" + Service.Image);
                        Service.Image = filenamenew;
                        var result = ServiceDAL.UpdateService(Service);

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