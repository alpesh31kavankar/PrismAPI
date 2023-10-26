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
    public class TechnologiesTypeController : ApiController
    {
        public Logger Log = null;
        public TechnologiesTypeController()
        {
            Log = Logger.GetLogger();
        }

        TechnologiesTypeDAL technologiesTypeDAL = new TechnologiesTypeDAL();

        [HttpGet]
        [ActionName("GetAllTechnologiesType")]
        public List<TechnologiesType> GetAllTechnologiesType()
        {
            Log.writeMessage("TechnologiesTypeController GetAllTechnologiesType Start");
            List<TechnologiesType> list = null;
            try
            {
                list = technologiesTypeDAL.GetAllTechnologiesType();
            }
            catch (Exception ex)
            {
                Log.writeMessage("TechnologiesTypeController GetAllTechnologiesType Error " + ex.Message);
            }
            Log.writeMessage("TechnologiesTypeController GetAllTechnologiesType End");
            return list;
        }
        [HttpGet]
        [ActionName("GetTechnologiesTypeById")]
        public TechnologiesType GetTechnologiesTypeById(int Id)
        {
            Log.writeMessage("TechnologiesTypeController GetTechnologiesTypeById Start");
            TechnologiesType technologiesType = null;
            try
            {
                technologiesType = technologiesTypeDAL.GetTechnologiesTypeById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("TechnologiesTypeController GetTechnologiesTypeById Error " + ex.Message);
            }
            Log.writeMessage("TechnologiesTypeController GetTechnologiesTypeById End");
            return technologiesType;
        }

        [HttpPost]
        [ActionName("AddTechnologiesType")]
        public IHttpActionResult AddTechnologiesType(TechnologiesType technologiesType)
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

                technologiesType.CreatedBy = "Admin";
                technologiesType.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                technologiesType.UpdatedBy = "Admin";
                //contact.Status = "Success";
                technologiesType.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = technologiesTypeDAL.AddTechnologiesType(technologiesType);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("TechnologiesTypeController AddTechnologiesType Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateTechnologiesType")]
        public IHttpActionResult UpdateTechnologiesType(TechnologiesType technologiesType)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                technologiesType.CreatedBy = "Admin";
                technologiesType.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                technologiesType.UpdatedBy = "Admin";
                technologiesType.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = technologiesTypeDAL.UpdateTechnologiesType(technologiesType);


                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("TechnologiesTypeController AddTechnologiesType Error " + ex.Message);
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
        public IHttpActionResult DeleteTechnologiesType(int Id)
        {
            try
            {
                var result = technologiesTypeDAL.DeleteTechnologiesType(Id);

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
                Log.writeMessage("TechnologiesTypeController DeleteTechnologiesType Error " + ex.Message);
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


        /*[HttpPost]
        public async Task<IHttpActionResult> SaveTechnologiesTypeImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/TechnologiesType" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var technologiesType = technologiesTypeDAL.GetTechnologiesTypeById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (technologiesType.Image.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/TechnologiesType" + "/" + technologiesType.Image);
                        technologiesType.Image = Id + "_" + filename;
                        var result = technologiesTypeDAL.UpdateTechnologiesType(technologiesType);

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
        public async Task<IHttpActionResult> SaveTechnologiesTypeImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/TechnologiesType" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var technologiesType = technologiesTypeDAL.GetTechnologiesTypeById(Id);
                    var filenamenew = Id + "_" + newFilename;
                    if (technologiesType.Image.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/TechnologiesType" + "/" + technologiesType.Image);
                        technologiesType.Image = filenamenew;
                        var result = technologiesTypeDAL.UpdateTechnologiesType(technologiesType);

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