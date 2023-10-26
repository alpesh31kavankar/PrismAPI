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
    public class ServiceSubTypeController : ApiController
    {
        public Logger Log = null;
        public ServiceSubTypeController()
        {
            Log = Logger.GetLogger();
        }

        ServiceSubTypeDAL ServiceSubTypeDAL = new ServiceSubTypeDAL();

        [HttpGet]
        [ActionName("GetAllServiceSubType")]
        public List<ServiceSubType> GetAllServiceSubType()
        {
            Log.writeMessage("ServiceSubTypeController GetAllServiceSubType Start");
            List<ServiceSubType> list = null;
            try
            {
                list = ServiceSubTypeDAL.GetAllServiceSubType();
            }
            catch (Exception ex)
            {
                Log.writeMessage("ServiceSubTypeController GetAllServiceSubTypeError " + ex.Message);
            }
            Log.writeMessage("ServiceSubTypeController GetAllServiceSubType End");
            return list;
        }
        [HttpGet]
        [ActionName("GetServiceSubTypeById")]
        public ServiceSubType GetServiceSubTypeById(int Id)
        {
            Log.writeMessage("ServiceSubTypeController GetServiceSubTypeById Start");
            ServiceSubType servicesubtype = null;
            try
            {
                servicesubtype = ServiceSubTypeDAL.GetServiceSubTypeById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("ServiceSubTypeController GetServiceSubTypeById Error " + ex.Message);
            }
            Log.writeMessage("ServiceSubTypeController GetServiceSubTypeById End");
            return servicesubtype;
        }
        [HttpPost]
        [ActionName("AddServiceSubType")]
        public IHttpActionResult AddServiceSubType(ServiceSubType servicesubtype)
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

                servicesubtype.CreatedBy = "Admin";
                servicesubtype.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                servicesubtype.UpdatedBy = "Admin";
                //contact.Status = "Success";
                servicesubtype.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = ServiceSubTypeDAL.AddServiceSubType(servicesubtype);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ServiceSubTypeController AddServiceSubType Error " + ex.Message);
            }
            return Ok(result);
        }
        [HttpPost]
        [ActionName("UpdateServiceSubType")]
        public IHttpActionResult UpdateServiceSubType(ServiceSubType servicesubtype)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                servicesubtype.CreatedBy = "Admin";
                servicesubtype.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                servicesubtype.UpdatedBy = "Admin";
                servicesubtype.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = ServiceSubTypeDAL.UpdateServiceSubType(servicesubtype);


                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ServiceSubTypeController AddServiceSubType Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpDelete]
        public IHttpActionResult DeleteServiceSubType(int Id)
        {
            try
            {
                var result = ServiceSubTypeDAL.DeleteServiceSubType(Id);

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
                Log.writeMessage("ServiceSubTypeController DeleteServiceSubType Error " + ex.Message);
            }
            return Ok("Failed");
        }
/*
        [HttpPost]
        public async Task<IHttpActionResult> SaveServiceSubTypeImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/ServiceSubType" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    //            // get existing rocrd
                    var ServiceSubType = ServiceSubTypeDAL.GetServiceSubTypeById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (ServiceSubType.Image.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/ServiceSubType" + "/" + ServiceSubType.Image);
                        ServiceSubType.Image = Id + "_" + filename;
                        var result = ServiceSubTypeDAL.UpdateServiceSubType(ServiceSubType);

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
        public async Task<IHttpActionResult> SaveServiceSubTypeImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/ServiceSubType" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var ServiceSubType = ServiceSubTypeDAL.GetServiceSubTypeById(Id);
                    var filenamenew = Id + "_" + newFilename;
                    if (ServiceSubType.Image.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/ServiceSubType" + "/" + ServiceSubType.Image);
                        ServiceSubType.Image = filenamenew;
                        var result = ServiceSubTypeDAL.UpdateServiceSubType(ServiceSubType);

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