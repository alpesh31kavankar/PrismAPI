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
    public class ProdFeaturesController : ApiController
    {
        public Logger Log = null;
        public ProdFeaturesController()
        {
            Log = Logger.GetLogger();
        }

        ProdFeaturesDAL prodFeaturesDAL = new ProdFeaturesDAL();

        [HttpGet]
        [ActionName("GetAllProdFeatures")]
        public List<ProdFeatures> GetAllProdFeatures()
        {
            Log.writeMessage("GetAllProdFeaturesController GetAllProdFeatures Start");
            List<ProdFeatures> list = null;
            try
            {
                list = prodFeaturesDAL.GetAllProdFeatures();
            }
            catch (Exception ex)
            {
                Log.writeMessage("GetAllProdFeaturesController GetAllProdFeatures Error " + ex.Message);
            }
            Log.writeMessage("GetAllProdFeaturesController GetAllProdFeatures End");
            return list;
        }
        [HttpGet]
        [ActionName("GetProdFeaturesById")]
        public ProdFeatures GetProdFeaturesById(int Id)
        {
            Log.writeMessage("ProdFeaturesController  GetProdFeaturesById Start");
            ProdFeatures prodFeatures = null;
            try
            {
                prodFeatures = prodFeaturesDAL.GetProdFeaturesById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("ProdFeaturesController  GetProdFeaturesById  " + ex.Message);
            }
            Log.writeMessage("ProdFeaturesController  GetProdFeaturesById  End");
            return prodFeatures;

        }

        [HttpPost]
        [ActionName("AddProdFeatures")]
        public IHttpActionResult AddProdFeatures(ProdFeatures prodFeatures)
        {
            var result = " ";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                //mainCategory.MainCategoryName = "MainCategoryName";
                //mainCategory.MainCategoryDescription = "MainCategoryDescription";

                prodFeatures.CreatedBy = "Admin";
                prodFeatures.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                prodFeatures.UpdatedBy = "Admin";
                prodFeatures.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                result = prodFeaturesDAL.AddProdFeatures(prodFeatures);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ProdFeaturesController AddProdFeatures Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateProdFeatures")]
        public IHttpActionResult UpdateProdFeatures(ProdFeatures prodFeatures)
        {
            var result = " ";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                prodFeatures.CreatedBy = "Admin";
                prodFeatures.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                prodFeatures.UpdatedBy = "Admin";
                //contact.Status = "Success";
                prodFeatures.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = prodFeaturesDAL.UpdateProdFeatures(prodFeatures);




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
        public IHttpActionResult DeleteProdFeatures(int Id)
        {
            try
            {
                var result = prodFeaturesDAL.DeleteProdFeatures(Id);

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
        public async Task<IHttpActionResult> SaveProdFeaturesImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/ProdFeatures" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var prodFeatures = prodFeaturesDAL.GetProdFeaturesById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (prodFeatures.Image.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/ProdFeatures" + "/" + prodFeatures.Image);
                        prodFeatures.Image = Id + "_" + filename;
                        var result = prodFeaturesDAL.UpdateProdFeatures(prodFeatures);

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
        public async Task<IHttpActionResult> SaveProdFeaturesImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/ProdFeatures" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var prodFeatures = prodFeaturesDAL.GetProdFeaturesById(Id);
                    var filenamenew = Id + "_" + newFilename;
                    if (prodFeatures.Image.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/ProdFeatures" + "/" + prodFeatures.Image);
                        prodFeatures.Image = filenamenew;
                        var result = prodFeaturesDAL.UpdateProdFeatures(prodFeatures);
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