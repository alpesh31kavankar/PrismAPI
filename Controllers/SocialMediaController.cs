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
using static Aether.Optics;

//using System.Web.Mvc;

namespace PrismAPI.Controllers
{
    public class SocialMediaController :ApiController
    {
        public Logger Log = null;
        public SocialMediaController()
        {
            Log = Logger.GetLogger();
        }

        SocialMediaDAL socialMediaDAL = new SocialMediaDAL();

        [HttpGet]
        [ActionName("GetAllSocialMedia")]
        public List<SocialMedia> GetAllSocialMedia()
        {
            Log.writeMessage("GetAllSocialMediaController GetAllSocialMedia Start");
            List<SocialMedia> list = null;
            try
            {
                list = socialMediaDAL.GetAllSocialMedia();
            }
            catch (Exception ex)
            {
                Log.writeMessage("SocialMediaController GetAllSocialMedia Error " + ex.Message);
            }
            Log.writeMessage("SocialMediaController GetAllSocialMedia End");
            return list;
        }
        [HttpGet]
        [ActionName("GetSocialMediaById")]
        public SocialMedia GetSocialMediaById(int Id)
        {
            Log.writeMessage("SocialMediaController  GetSocialMediaById Start");
            SocialMedia socialMedia = null;
            try
            {
                socialMedia = socialMediaDAL.GetSocialMediaById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("SocialMediaController  GetSocialMediaById " + ex.Message);
            }
            Log.writeMessage("SocialMediaController  GetSocialMediaById End");
            return socialMedia;

        }

        [HttpPost]
        [ActionName("AddSocialMedia")]
        public IHttpActionResult AddSocialMedia(SocialMedia socialMedia)
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

                socialMedia.CreatedBy = "Admin";
                socialMedia.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                socialMedia.UpdatedBy = "Admin";
                socialMedia.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = socialMediaDAL.AddSocialMedia(socialMedia);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("SocialMediaController AddSocialMedia Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateSocialMedia")]
        public IHttpActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {

            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                socialMedia.CreatedBy = "Admin";
                socialMedia.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                socialMedia.UpdatedBy = "Admin";
                socialMedia.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = socialMediaDAL.UpdateSocialMedia(socialMedia);




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
        public IHttpActionResult DeleteSocialMedia(int Id)
        {
            try
            {
                var result = socialMediaDAL.DeleteSocialMedia(Id);

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




      /*  [HttpPost]
        public async Task<IHttpActionResult> SaveSocialMediaImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/SocialMedia" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var socialMedia = socialMediaDAL.GetSocialMediaById(Id);
                    var filenamenew = Id + "_" + filename;
                   
                    if (filename.StartsWith("SocialLink"))
                    {
                        if (socialMedia.SocialLink.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/SocialMedia" + "/" + socialMedia.SocialLink);
                            socialMedia.SocialLink = Id + "_" + filename;
                            var result = socialMediaDAL.UpdateSocialMedia(socialMedia);

                        }

                    }
                    if (filename.StartsWith("Imgicon"))
                    {
                        if (socialMedia.Imgicon.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/SocialMedia" + "/" + socialMedia.Imgicon);
                            socialMedia.Imgicon = Id + "_" + filename;
                            var result = socialMediaDAL.UpdateSocialMedia(socialMedia);

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
*/
        [HttpPost]
        public async Task<IHttpActionResult> SaveSocialMediaImage(int Id)
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
                    string newFilename = filename.StartsWith("Imgicon") ? "Imgicon.jpg" : filename;
                    File.WriteAllBytes(theDirectory + "/Content/SocialMedia" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var socialMedia = socialMediaDAL.GetSocialMediaById(Id);
                    var filenamenew = Id + "_" + newFilename;
                    if (socialMedia.Imgicon.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/SocialMedia" + "/" + socialMedia.Imgicon);
                        socialMedia.Imgicon = filenamenew;
                        var result = socialMediaDAL.UpdateSocialMedia(socialMedia);

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