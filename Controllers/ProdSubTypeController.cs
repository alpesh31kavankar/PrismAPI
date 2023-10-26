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
    public class ProdSubTypeController : ApiController
    {

        public Logger Log = null;
        public ProdSubTypeController()
        {
            Log = Logger.GetLogger();
        }

        ProdSubTypeDAL prodSubTypeDAL = new ProdSubTypeDAL();

        [HttpGet]
        [ActionName("GetAllProdSubType")]
        public List<ProdSubType> GetAllProdSubType()
        {
            Log.writeMessage("ProdSubTypeController GetAllProdSubType Start");
            List<ProdSubType> list = null;
            try
            {
                list = prodSubTypeDAL.GetAllProdSubType();
            }
            catch (Exception ex)
            {
                Log.writeMessage("ProdSubTypeController GetAllProdSubType Error " + ex.Message);
            }
            Log.writeMessage("ProdSubTypeController GetAllProdSubType End");
            return list;
        }
        [HttpGet]
        [ActionName("GetProdSubTypeById")]
        public ProdSubType GetProdSubTypeById(int Id)
        {
            Log.writeMessage("ProdSubTypeController GetProdSubTypeById Start");
            ProdSubType prodSubType = null;
            try
            {
                prodSubType = prodSubTypeDAL.GetProdSubTypeById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("ProdSubTypeController GetProdSubTypeById Error " + ex.Message);
            }
            Log.writeMessage("ProdSubTypeController GetProdSubTypeById End");
            return prodSubType;
        }

        [HttpPost]
        [ActionName("AddProdSubType")]
        public IHttpActionResult AddProdSubType(ProdSubType prodSubType)
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

                prodSubType.CreatedBy = "Admin";
                prodSubType.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                prodSubType.UpdatedBy = "Admin";
                //contact.Status = "Success";
                prodSubType.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = prodSubTypeDAL.AddProdSubType(prodSubType);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ProdSubTypeController AddProdSubType Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateProdSubType")]
        public IHttpActionResult UpdateProdSubType(ProdSubType prodSubType)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                prodSubType.CreatedBy = "Admin";
                prodSubType.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                prodSubType.UpdatedBy = "Admin";
                prodSubType.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = prodSubTypeDAL.UpdateProdSubType(prodSubType);


                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ProdSubTypeController AddProdSubType Error " + ex.Message);
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
        public IHttpActionResult DeleteProdSubType(int Id)
        {
            try
            {
                var result = prodSubTypeDAL.DeleteProdSubType(Id);

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
                Log.writeMessage("ProdSubTypeController DeleteProdSubType Error " + ex.Message);
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


       /* [HttpPost]
        public async Task<IHttpActionResult> SaveProdSubTypeImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/ProdSubType" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var prodSubType = prodSubTypeDAL.GetProdSubTypeById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (prodSubType.Image.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/ProdSubType" + "/" + prodSubType.Image);
                        prodSubType.Image = Id + "_" + filename;
                        var result = prodSubTypeDAL.UpdateProdSubType(prodSubType);

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
        public async Task<IHttpActionResult> SaveProdSubTypeImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/ProdSubType" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var prodSubType = prodSubTypeDAL.GetProdSubTypeById(Id);
                    var filenamenew = Id + "_" + newFilename;
                    if (prodSubType.Image.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/ProdSubType" + "/" + prodSubType.Image);
                        prodSubType.Image = filenamenew;
                        var result = prodSubTypeDAL.UpdateProdSubType(prodSubType);
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