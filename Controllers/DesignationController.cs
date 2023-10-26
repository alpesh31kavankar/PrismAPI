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
    public class DesignationController : ApiController
    {
        public Logger Log = null;
        public DesignationController()
        {
            Log = Logger.GetLogger();
        }
        DesignationDAL DesignationDAL = new DesignationDAL();

        [HttpGet]
        [ActionName("GetAllDesignation")]
        public List<Designation> GetAllDesignation()
        {
            Log.writeMessage("AboutController GetAllClient Start");
            List<Designation> list = null;
            try
            {
                list = DesignationDAL.GetAllDesignation();
            }
            catch (Exception ex)
            {
                Log.writeMessage("DesignationController GetAllDesignationError " + ex.Message);
            }
            Log.writeMessage("DesignationController GetAllDesignation End");
            return list;
        }
        [HttpGet]
        [ActionName("GetDesignationById")]
        public Designation GetDesignationById(int Id)
        {
            Log.writeMessage("DesignationController GetDesignationById Start");
            Designation designation = null;
            try
            {
                designation = DesignationDAL.GetDesignationById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("DesignationController GetDesignationById Error " + ex.Message);
            }
            Log.writeMessage("DesignationController GetDesignationById End");
            return designation;
        }
        [HttpPost]
        [ActionName("AddDesignation")]
        public IHttpActionResult AddDesignation(Designation designation)
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

                designation.CreatedBy = "Admin";
                designation.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                designation.UpdatedBy = "Admin";
                //contact.Status = "Success";
                designation.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = DesignationDAL.AddDesignation(designation);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("DesignationController AddDesignation Error " + ex.Message);
            }
            return Ok(result);
        }
        [HttpPost]
        [ActionName("UpdateDesignation")]
        public IHttpActionResult UpdateDesignation(Designation designation)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                designation.CreatedBy = "Admin";
                designation.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                designation.UpdatedBy = "Admin";
                designation.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = DesignationDAL.UpdateDesignation(designation);


                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("DesignationController AddDesignation Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpDelete]
        public IHttpActionResult DeleteDesignation(int Id)
        {
        
            try
            {
                var result = DesignationDAL.DeleteDesignation(Id);

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
                Log.writeMessage("DesignationController DeleteDesignation Error " + ex.Message);
            }
            return Ok("Failed");
        }

       /* [HttpPost]
        public async Task<IHttpActionResult>SaveDesignationImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/Designation" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                             // get existing rocrd
                    var designation = DesignationDAL.GetDesignationById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (designation.Image.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/Designation" + "/" + designation.Image);
                        designation.Image = Id + "_" + filename;
                        var result = DesignationDAL.UpdateDesignation(designation);

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
        public async Task<IHttpActionResult> SaveDesignationImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/Designation" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var designation = DesignationDAL.GetDesignationById(Id);
                    var filenamenew = Id + "_" + newFilename;
                    if (designation.Image.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/Designation" + "/" + designation.Image);
                        designation.Image = filenamenew;
                        var result = DesignationDAL.UpdateDesignation(designation);

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