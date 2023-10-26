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
    public class EmployeesController : ApiController
    {
        public Logger Log = null;
        public EmployeesController()
        {
            Log = Logger.GetLogger();
        }

        EmployeesDAL EmployeesDAL = new EmployeesDAL();

        [HttpGet]
        [ActionName("GetAllEmployees")]
        public List<Employees> GetAllEmployees()
        {
            Log.writeMessage("EmployeesController GetAllClient Start");
            List<Employees> list = null;
            try
            {
                list = EmployeesDAL.GetAllEmployees();
            }
            catch (Exception ex)
            {
                Log.writeMessage("EmployeesController GetAllEmployeesError " + ex.Message);
            }
            Log.writeMessage("EmployeesController GetAllEmployees End");
            return list;
        }
        [HttpGet]
        [ActionName("GetEmployeesById")]
        public Employees GetEmployeesById(int Id)
        {
            Log.writeMessage("EmployeesController GetEmployeesById Start");
            Employees employees = null;
            try
            {
                employees = EmployeesDAL.GetEmployeesById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("EmployeesController GetEmployeesById Error " + ex.Message);
            }
            Log.writeMessage("EmployeesController GetEmployeesById End");
            return employees;
        }
        [HttpPost]
        [ActionName("AddEmployees")]
        public IHttpActionResult AddEmployees(Employees employees)
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

                employees.CreatedBy = "Admin";
                employees.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                employees.UpdatedBy = "Admin";
                //contact.Status = "Success";
                employees.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = EmployeesDAL.AddEmployees(employees);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("EmployeesController AddEmployees Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [ActionName("Login")]
        public Login Login(string Email, string Password)
        {
            Log.writeMessage("EmployeesController GetEmployeesById Start");
            Login user = null;
            try
            {
                user = EmployeesDAL.Login(Email, Password);
            }
            catch (Exception ex)
            {
                Log.writeMessage("EmployeesController GetEmployeesById Error " + ex.Message);
            }
            Log.writeMessage("EmployeesController GetEmployeesById End");
            return user;
        }
        [HttpPost]
        [ActionName("UpdateEmployees")]
        public IHttpActionResult UpdateEmployees(Employees employees)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                employees.CreatedBy = "Admin";
                employees.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                employees.UpdatedBy = "Admin";
                employees.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = EmployeesDAL.UpdateEmployees(employees);


                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("EmployeesController AddEmployees Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployees(int Id)
        {
            try
            {
                var result = EmployeesDAL.DeleteEmployees(Id);

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
                Log.writeMessage("EmployeesController DeleteAbout Error " + ex.Message);
            }
            return Ok("Failed");
        }

       /* [HttpPost]
        public async Task<IHttpActionResult> SaveEmployeesImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/Employees" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    //            // get existing rocrd
                    var employees = EmployeesDAL.GetEmployeesById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (employees.Photo.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/Employees" + "/" + employees.Photo);
                        employees.Photo = Id + "_" + filename;
                        var result = EmployeesDAL.UpdateEmployees(employees);

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
        public async Task<IHttpActionResult> SaveEmployeesImage(int Id)
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
                    string newFilename = filename.StartsWith("Photo") ? "Photo.jpg" : filename;
                    File.WriteAllBytes(theDirectory + "/Content/Employees" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var employees = EmployeesDAL.GetEmployeesById(Id);
                    var filenamenew = Id + "_" + newFilename;
                    if (employees.Photo.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/Employees" + "/" + employees.Photo);
                        employees.Photo = filenamenew;
                        var result = EmployeesDAL.UpdateEmployees(employees);

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