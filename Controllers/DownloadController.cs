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
    public class DownloadController : ApiController
    {
        public Logger Log = null;
        public DownloadController()
        {
            Log = Logger.GetLogger();
        }

        DownloadDAL downloadDAL = new DownloadDAL();

        [HttpGet]
        [ActionName("GetAllDownload")]
        public List<Download> GetAllDownload()
        {
            Log.writeMessage("DownloadController GetAllDownload Start");
            List<Download> list = null;
            try
            {
                list = downloadDAL.GetAllDownload();
            }
            catch (Exception ex)
            {
                Log.writeMessage("DownloadController GetAllDownload Error " + ex.Message);
            }
            Log.writeMessage("DownloadController GetAllDownload End");
            return list;
        }
        [HttpGet]
        [ActionName("GetDownloadById")]
        public Download GetDownloadById(int Id)
        {
            Log.writeMessage("DownloadController GetDownloadById Start");
            Download download = null;
            try
            {
                download = downloadDAL.GetDownloadById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("DownloadController GetDownloadById Error " + ex.Message);
            }
            Log.writeMessage("DownloadController GetDownloadById End");
            return download;
        }

        [HttpPost]
        [ActionName("AddDownload")]
        public IHttpActionResult AddDownload(Download download)
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

                download.CreatedBy = "Admin";
                download.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                download.UpdatedBy = "Admin";
                //contact.Status = "Success";
                download.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = downloadDAL.AddDownload(download);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("DownloadController AddDownload Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateDownload")]
        public IHttpActionResult UpdateDownload(Download download)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                download.CreatedBy = "Admin";
                download.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                download.UpdatedBy = "Admin";
                download.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = downloadDAL.UpdateDownload(download);


                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("DownloadController AddDownload Error " + ex.Message);
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
        public IHttpActionResult DeleteDownload(int Id)
        {
            try
            {
                var result = downloadDAL.DeleteDownload(Id);

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
                Log.writeMessage("DownloadController DeleteDownload Error " + ex.Message);
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
        public async Task<IHttpActionResult>SaveDownloadImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/Download" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var download = downloadDAL.GetDownloadById(Id);
                    var filenamenew = Id + "_" + filename;
                    //  string extension = Path.GetExtension(filenamenew);
                    if (filename.StartsWith("FileLink"))
                    {
                        if (download.FileLink.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Download" + "/" + download.FileLink);
                            download.FileLink = Id + "_" + filename;
                            var result = downloadDAL.UpdateDownload(download);
                        }
                    }

                    if (filename.StartsWith("Image"))
                    {
                        if (download.Image.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Download" + "/" + download.Image);
                            download.Image = Id + "_" + filename;
                            var result = downloadDAL.UpdateDownload(download);
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
        public async Task<IHttpActionResult> SaveDownloadImage(int Id)
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
                    string newFilename = filename.StartsWith("FileLink") ? "FileLink.pdf" :
                                         filename.StartsWith("Image") ? "Image.jpg" : filename;
                    File.WriteAllBytes(theDirectory + "/Content/Download" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var download = downloadDAL.GetDownloadById(Id);
                    var filenamenew = Id + "_" + newFilename;

                    if (filename.StartsWith("FileLink"))   // condition
                    {
                        if (download.FileLink.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Download" + "/" + download.FileLink);
                            download.FileLink = filenamenew;
                            var result = downloadDAL.UpdateDownload(download);
                        }
                    }
                    if (filename.StartsWith("Image"))
                    {
                        if (download.Image.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Download" + "/" + download.Image);
                            download.Image = filenamenew;
                            var result = downloadDAL.UpdateDownload(download);
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