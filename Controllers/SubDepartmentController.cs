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
    public class SubDepartmentController : ApiController
    {
        public Logger Log = null;
        public SubDepartmentController()
        {
            Log = Logger.GetLogger();
        }

        SubDepartmentDAL subDepartmentDAL = new SubDepartmentDAL();

        [HttpGet]
        [ActionName("GetAllSubDepartment")]
        public List<SubDepartment> GetAllSubDepartment()
        {
            Log.writeMessage("SubDepartmentController GetAllSubDepartment Start");
            List<SubDepartment> list = null;
            try
            {
                list = subDepartmentDAL.GetAllSubDepartment();
            }
            catch (Exception ex)
            {
                Log.writeMessage("SubDepartmentController GetAllSubDepartmentError " + ex.Message);
            }
            Log.writeMessage("SubDepartmentController GetAllSubDepartment End");
            return list;
        }
        [HttpGet]
        [ActionName("GetSubDepartmentById")]
        public SubDepartment GetSubDepartmentById(int Id)
        {
            Log.writeMessage("BlogController  GetBlogById Start");
            SubDepartment subDepartment = null;
            try
            {
                subDepartment = subDepartmentDAL.GetSubDepartmentById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("BlogController  GetBlogById " + ex.Message);
            }
            Log.writeMessage("BlogController  GetBlogById End");
            return subDepartment;

        }

        [HttpPost]
        [ActionName("AddSubDepartment")]
        public IHttpActionResult AddSubDepartment(SubDepartment SubDepartment)
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

                SubDepartment.CreatedBy = "Admin";
                SubDepartment.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                SubDepartment.UpdatedBy = "Admin";
                SubDepartment.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                result = subDepartmentDAL.AddSubDepartment(SubDepartment);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("SubDepartmentController AddSubDepartment Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateSubDepartment")]
        public IHttpActionResult UpdateSubDepartment(SubDepartment subDepartment)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                subDepartment.CreatedBy = "Admin";
                subDepartment.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                subDepartment.UpdatedBy = "Admin";
                //contact.Status = "Success";
                subDepartment.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                 result = subDepartmentDAL.UpdateSubDepartment(subDepartment);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }
            }
            catch (Exception ex)
            {
                Log.writeMessage("Result1Controller AddResult1 Error " + ex.Message);
            }
            return Ok(result);
        }


        [HttpDelete]
        public IHttpActionResult DeleteSubDepartment(int Id)
        {
            try
            {
                var result = subDepartmentDAL.DeleteSubDepartment(Id);

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
                Log.writeMessage("Result1Controller DeleteResult1 Error " + ex.Message);
            }
            return Ok("Failed");
        }


       
        /*[HttpPost]
        public async Task<IHttpActionResult>SaveSubDepartmentImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/SubDepartment" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var subDepartment = subDepartmentDAL.GetSubDepartmentById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (subDepartment.SubDeptImage.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/SubDepartment" + "/" + subDepartment.SubDeptImage);
                        subDepartment.SubDeptImage = Id + "_" + filename;
                        var result = subDepartmentDAL.UpdateSubDepartment(subDepartment);

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
        public async Task<IHttpActionResult> SaveSubDepartmentImage(int Id)
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
                    string newFilename = filename.StartsWith("SubDeptImage") ? "SubDeptImage.jpg" : filename;
                    File.WriteAllBytes(theDirectory + "/Content/SubDepartment" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var subDepartment = subDepartmentDAL.GetSubDepartmentById(Id);
                    var filenamenew = Id + "_" + newFilename;
                    if (subDepartment.SubDeptImage.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/SubDepartment" + "/" + subDepartment.SubDeptImage);
                        subDepartment.SubDeptImage = filenamenew;
                        var result = subDepartmentDAL.UpdateSubDepartment(subDepartment);

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