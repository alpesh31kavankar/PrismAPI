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
    public class ServiceMainTypeController :ApiController
    {
        public Logger Log = null;
        public ServiceMainTypeController()
        {
            Log = Logger.GetLogger();
        }

        ServiceMainTypeDAL ServiceMainTypeDAL = new ServiceMainTypeDAL();

        [HttpGet]
        [ActionName("GetAllServiceMainType")]
        public List<ServiceMainType> GetAllServiceMainType()
        {
            Log.writeMessage("ServiceMainTypeController GetAllServiceMainType Start");
            List<ServiceMainType> list = null;
            try
            {
                list = ServiceMainTypeDAL.GetAllServiceMainType();
            }
            catch (Exception ex)
            {
                Log.writeMessage("ServiceMainTypeController GetAllServiceMainTypeError " + ex.Message);
            }
            Log.writeMessage("ServiceMainTypeController GetAllServiceMainType End");
            return list;
        }
        [HttpGet]
        [ActionName("GetServiceMainTypeById")]
        public ServiceMainType GetServiceMainTypeById(int Id)
        {
            Log.writeMessage("ServiceMainTypeController GetServiceMainTypeById Start");
            ServiceMainType servicemaintype = null;
            try
            {
                servicemaintype = ServiceMainTypeDAL.GetServiceMainTypeById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("ServiceMainTypeController GetServiceMainTypeById Error " + ex.Message);
            }
            Log.writeMessage("ServiceMainTypeController GetServiceMainTypeById End");
            return servicemaintype;
        }
        [HttpPost]
        [ActionName("AddServiceMainType")]
        public IHttpActionResult AddServiceMainType(ServiceMainType servicemaintype)
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

                servicemaintype.CreatedBy = "Admin";
                servicemaintype.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                servicemaintype.UpdatedBy = "Admin";
                //contact.Status = "Success";
                servicemaintype.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = ServiceMainTypeDAL.AddServiceMainType(servicemaintype);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ServiceMainTypeController AddServiceMainType Error " + ex.Message);
            }
            return Ok(result);
        }
        [HttpPost]
        [ActionName("UpdateServiceMainType")]
        public IHttpActionResult UpdateServiceMainType(ServiceMainType servicemaintype)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                servicemaintype.CreatedBy = "Admin";
                servicemaintype.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                servicemaintype.UpdatedBy = "Admin";
                servicemaintype.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = ServiceMainTypeDAL.UpdateServiceMainType(servicemaintype);


                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ServiceMainTypeController AddServiceMainType Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpDelete]
        public IHttpActionResult DeleteServiceMainType(int Id)
        {
            try
            {
                var result = ServiceMainTypeDAL.DeleteServiceMainType(Id);

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
                Log.writeMessage("ServiceMainTypeController DeleteServiceMainType Error " + ex.Message);
            }
            return Ok("Failed");
        }

      /*  [HttpPost]
        public async Task<IHttpActionResult> SaveServiceMainTypeImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/ServiceMainType" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    //            // get existing rocrd
                    var ServiceMainType = ServiceMainTypeDAL.GetServiceMainTypeById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (ServiceMainType.Image.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/ServiceMainType" + "/" + ServiceMainType.Image);
                        ServiceMainType.Image = Id + "_" + filename;
                        var result = ServiceMainTypeDAL.UpdateServiceMainType(ServiceMainType);

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
        public async Task<IHttpActionResult> SaveServiceMainTypeImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/ServiceMainType" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var ServiceMainType = ServiceMainTypeDAL.GetServiceMainTypeById(Id);
                    var filenamenew = Id + "_" + newFilename;
                    if (ServiceMainType.Image.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/ServiceMainType" + "/" + ServiceMainType.Image);
                        ServiceMainType.Image = filenamenew;
                        var result = ServiceMainTypeDAL.UpdateServiceMainType(ServiceMainType);

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