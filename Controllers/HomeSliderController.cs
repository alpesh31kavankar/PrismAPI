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
    public class HomeSliderController : ApiController
    {
        public Logger Log = null;
        public HomeSliderController()
        {
            Log = Logger.GetLogger();
        }

        HomeSliderDAL homeSliderDAL = new HomeSliderDAL();

        [HttpGet]
        [ActionName("GetAllHomeSlider")]
        public List<HomeSlider> GetAllHomeSlider()
        {
            Log.writeMessage("HomeSliderController GetAllHomeSlider Start");
            List<HomeSlider> list = null;
            try
            {
                list = homeSliderDAL.GetAllHomeSlider();
            }
            catch (Exception ex)
            {
                Log.writeMessage("HomeSliderController GetAllHomeSlider Error " + ex.Message);
            }
            Log.writeMessage("HomeSliderController GetAllHomeSlider End");
            return list;
        } 
        [HttpGet]
        public HomeSlider GetHomeSliderById(int Id)
        {
            Log.writeMessage("HomeSliderController  GetHomeSliderById Start");
            HomeSlider homeSlider = null;
            try
            {
                homeSlider = homeSliderDAL.GetHomeSliderById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("HomeSliderController  GetHomeSliderById  " + ex.Message);
            }
            Log.writeMessage("HomeSliderController  GetHomeSliderById  End");
            return homeSlider;

        }

        [HttpPost]
        [ActionName("AddHomeSlider")]
        public IHttpActionResult AddHomeSlider(HomeSlider homeSlider)
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

                homeSlider.CreatedBy = "Admin";
                homeSlider.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                homeSlider.UpdatedBy = "Admin";
                homeSlider.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                result = homeSliderDAL.AddHomeSlider(homeSlider);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("HomeSliderController AddHomeSlider Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateHomeSlider")]
        public IHttpActionResult UpdateHomeSlider(HomeSlider homeSlider)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                homeSlider.CreatedBy = "Admin";
                homeSlider.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                homeSlider.UpdatedBy = "Admin";
                homeSlider.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = homeSliderDAL.UpdateHomeSlider(homeSlider);


                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("HomeSliderController AddHomeSlider Error " + ex.Message);
            }
            return Ok(result);
        }

        // PUT: api/Address/5
        //[HttpPut]
        //[ActionName("UpdateFirstModel")]
        //public IHttpActionResult UpdateFirstModel(FirstModel firstModel)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        var result = firstDAL.UpdateFirstModel(firstModel);




        //        if (result == "Success")
        //        {
        //            return Ok("Success");
        //        }
        //        else
        //        {
        //            return Ok("Failed");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage("FirstController UpdateFirstModel Error " + ex.Message);
        //    }
        //    return Ok("Failed");
        //}

        // DELETE: api/Address/5

        [HttpDelete]
        public IHttpActionResult DeleteHomeSlider(int Id)
        {
            try
            {
                var result = homeSliderDAL.DeleteHomeSlider(Id);

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


        //[HttpPost]
        //public async Task<IActionResult> SendMail([FromBody] Email email)
        //{
        //    Console.WriteLine("Sending email");
        //    var client = new System.Net.Mail.SmtpClient("smtp.example.com", 111);
        //    client.UseDefaultCredentials = false;
        //    client.EnableSsl = true;
        //    client.Credentials = new System.Net.NetworkCredential(emailid, password);
        //    var mailMessage = new System.Net.Mail.MailMessage();
        //    mailMessage.From = new System.Net.Mail.MailAddress(senderemail);
        //    mailMessage.To.Add(email.To);
        //    mailMessage.Body = email.Text;
        //    await client.SendMailAsync(mailMessage);
        //    return Ok();
        //}


        //[HttpPost]
        //public async Task<IHttpActionResult> SaveProfilePhoto(int Id)
        //{                  
        //    try
        //    {              
        //        if (!Request.Content.IsMimeMultipartContent())
        //            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

        //        var provider = new MultipartMemoryStreamProvider();
        //        await Request.Content.ReadAsMultipartAsync(provider);
        //        foreach (var file in provider.Contents)
        //        {
        //            var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
        //            var buffer = await file.ReadAsByteArrayAsync();
        //            string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
        //            //get the folder that's in
        //            string theDirectory = Path.GetDirectoryName(fullPath);
        //            theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));

        //            File.WriteAllBytes(theDirectory + "/ProfilePhoto/" + "/" + Id + "_" + filename, buffer);
        //            //Do whatever you want with filename and its binary data.
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage(ex.Message);
        //    }

        //    return Ok();
        //}

        //[HttpPost]
        //public void SaveProfilePhoto(UserProfilePhoto profile)
        //{
        //    try
        //    {
        //        byte[] imageBytes = Convert.FromBase64String(profile.Photo);
        //        string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
        //        string theDirectory = Path.GetDirectoryName(fullPath);
        //        theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));
        //        //string filePath = "http://localhost:62842/ProfilePhoto/";
        //        File.WriteAllBytes(theDirectory + "/ProfilePhoto/" + "ProfilePicture_" + profile.Id + ".jpeg", imageBytes);
        //        //File.WriteAllBytes(theDirectory + "/ProfilePhoto/" + "/" + Id + "_" + filename, buffer);

        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage(ex.Message);
        //    }
        //}


        //[HttpPost]
  /*      [HttpPost]
        public async Task<IHttpActionResult> SaveHomeSliderImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/HomeSlider" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var homeSlider = homeSliderDAL.GetHomeSliderById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (homeSlider.Image.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/HomeSlider" + "/" + homeSlider.Image);
                        homeSlider.Image = Id + "_" + filename;
                        var result = homeSliderDAL.UpdateHomeSlider(homeSlider);

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
        public async Task<IHttpActionResult> SaveHomeSliderImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/HomeSlider" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var homeSlider = homeSliderDAL.GetHomeSliderById(Id);
                    var filenamenew = Id + "_" + newFilename;
                    if (homeSlider.Image.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/HomeSlider" + "/" + homeSlider.Image);
                        homeSlider.Image = filenamenew;
                        var result = homeSliderDAL.UpdateHomeSlider(homeSlider);

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

