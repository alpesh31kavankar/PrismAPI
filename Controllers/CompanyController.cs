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
    public class CompanyController :ApiController
    {
        public Logger Log = null;
        public CompanyController()
        {
            Log = Logger.GetLogger();
        }

        CompanyDAL CompanyDAL = new CompanyDAL();

        [HttpGet]
        [ActionName("GetAllCompany")]
        public List<Company> GetAllCompany()
        {
            Log.writeMessage("CompanyController GetAllCompany Start");
            List<Company> list = null;
            try
            {
                list = CompanyDAL.GetAllCompany();
            }
            catch (Exception ex)
            {
                Log.writeMessage("CompanyController GetAllCompanyError " + ex.Message);
            }
            Log.writeMessage("CompanyController GetAllCompany End");
            return list;
        }
        [HttpGet]
        [ActionName("GetCompanyById")]
        public Company GetCompanyById(int Id)
        {
            Log.writeMessage("CompanyController GetCompanyById Start");
            Company company = null;
            try
            {
                company = CompanyDAL.GetCompanyById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("CompanyController GetCompanyById Error " + ex.Message);
            }
            Log.writeMessage("CompanyController GetCompanyById End");
            return company;
        }
        [HttpPost]
        [ActionName("AddCompany")]
        public IHttpActionResult AddCompany(Company company)
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

                company.CreatedBy = "Admin";
                company.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                company.UpdatedBy = "Admin";
                //contact.Status = "Success";
                company.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = CompanyDAL.AddCompany(company);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("CompanyController AddCompany Error " + ex.Message);
            }
            return Ok(result);
        }
        [HttpPost]
        [ActionName("UpdateCompany")]
        public IHttpActionResult UpdateCompany(Company company)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                company.CreatedBy = "Admin";
                company.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                company.UpdatedBy = "Admin";
                company.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = CompanyDAL.UpdateCompany(company);


                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("CompanyController AddCompany Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCompany(int Id)
        {
            try
            {
                var result = CompanyDAL.DeleteCompany(Id);

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
                Log.writeMessage("CompanyController DeleteCompany Error " + ex.Message);
            }
            return Ok("Failed");
        }


       /* [HttpPost]
        public async Task<IHttpActionResult>SaveCompanyImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/Company" + "/" + Id + "_" + filename, buffer);


                    // Do whatever you want with filename and its binary data.

                    var Company = CompanyDAL.GetCompanyById(Id);
                    var filenamenew = Id + "_" + filename;

                    //documents.PANcard = filenamenew.Substring(0,3);
                    //  var Substring = filename.Substring(0, 9);
                    if (filename.StartsWith("LogoImage"))
                    {
                        if (Company.LogoImage.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Company" + "/" + Company.LogoImage);
                            Company.LogoImage = Id + "_" + filename;
                            var result = CompanyDAL.UpdateCompany(Company);
                        }

                    }
                    if (filename.StartsWith("bgImage"))
                    {
                        if (Company.bgImage.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Company" + "/" + Company.bgImage);
                            Company.bgImage = Id + "_" + filename;
                            var result = CompanyDAL.UpdateCompany(Company);
                        }
                    }


                    *//*   string extension = Path.GetExtension(filenamenew);
                       if (extension != ".png")
                       {

                           if (Company.LogoImage.ToLower() != filenamenew.ToLower())
                           {
                               File.Delete(theDirectory + "/Content/Company" + "/" + Company.LogoImage);
                               Company.LogoImage = Id + "_" + filename;
                               var result = CompanyDAL.UpdateCompany(Company);

                           }


                       }
                       else
                       {
                           if (Company.bgImage.ToLower() != filenamenew.ToLower())
                           {
                               File.Delete(theDirectory + "/Content/Company" + "/" + Company.bgImage);
                               Company.bgImage = Id + "_" + filename;
                               var result = CompanyDAL.UpdateCompany(Company);

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

        [HttpPost]
        public async Task<IHttpActionResult> SaveCompanyImage(int Id)
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
                    string newFilename = filename.StartsWith("LogoImage") ? "Logoimage.jpg" :
                                         filename.StartsWith("bgImage") ? "bgimage.jpg" : filename;
                    File.WriteAllBytes(theDirectory + "/Content/Company" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var Company = CompanyDAL.GetCompanyById(Id);
                    var filenamenew = Id + "_" + newFilename;

                    if (filename.StartsWith("LogoImage"))   // condition
                    {
                        if (Company.LogoImage.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Company" + "/" + Company.LogoImage);
                            Company.LogoImage = filenamenew;
                            var result = CompanyDAL.UpdateCompany(Company);
                        }
                    }
                    if (filename.StartsWith("bgImage"))
                    {
                        if (Company.bgImage.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Company" + "/" + Company.bgImage);
                            Company.bgImage = filenamenew;
                            var result = CompanyDAL.UpdateCompany(Company);
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
