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
    public class OnBoardMemberController :ApiController
    {
        public Logger Log = null;
        public OnBoardMemberController()
        {
            Log = Logger.GetLogger();
        }

        OnBoardMemberDAL onBoardMemberDAL = new OnBoardMemberDAL();

        [HttpGet]
        [ActionName("GetAllOnBoardMember")]
        public List<OnBoardMember> GetAllOnBoardMember()
        {
            Log.writeMessage("OnBoardMemberController GetAllOnBoardMember Start");
            List<OnBoardMember> list = null;
            try
            {
                list = onBoardMemberDAL.GetAllOnBoardMember();
            }
            catch (Exception ex)
            {
                Log.writeMessage("OnBoardMemberController GetAllOnBoardMember Error " + ex.Message);
            }
            Log.writeMessage("OnBoardMemberController GetAllOnBoardMember End");
            return list;
        }
        [HttpGet]
        [ActionName("GetOnBoardMemberById")]
        public OnBoardMember GetOnBoardMemberById(int Id)
        {
            Log.writeMessage("OnBoardMemberController GetOnBoardMemberById Start");
            OnBoardMember onBoardMember = null;
            try
            {
                onBoardMember = onBoardMemberDAL.GetOnBoardMemberById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("OnBoardMemberController GetOnBoardMemberById Error " + ex.Message);
            }
            Log.writeMessage("OnBoardMemberController GetOnBoardMemberById End");
            return onBoardMember;
        }

        [HttpPost]
        [ActionName("AddOnBoardMember")]
        public IHttpActionResult AddOnBoardMember(OnBoardMember onBoardMember)
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

                onBoardMember.CreatedBy = "Admin";
                onBoardMember.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                onBoardMember.UpdatedBy = "Admin";
                //contact.Status = "Success";
                onBoardMember.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = onBoardMemberDAL.AddOnBoardMember(onBoardMember);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("OnBoardMemberController AddOnBoardMember Error " + ex.Message);
            }
            return Ok(result);
        }


        [HttpPost]
        [ActionName("UpdateOnBoardMember")]
        public IHttpActionResult UpdateOnBoardMember(OnBoardMember onBoardMember)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                onBoardMember.CreatedBy = "Admin";
                onBoardMember.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                onBoardMember.UpdatedBy = "Admin";
                onBoardMember.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = onBoardMemberDAL.UpdateOnBoardMember(onBoardMember);


                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("OnBoardMemberController AddOnBoardMember Error " + ex.Message);
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
        public IHttpActionResult DeleteOnBoardMember(int Id)
        {
            try
            {
                var result = onBoardMemberDAL.DeleteOnBoardMember(Id);

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
                Log.writeMessage("OnBoardMemberController DeleteOnBoardMember Error " + ex.Message);
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
        public async Task<IHttpActionResult>SaveOnBoardMemberImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/OnBoardMember" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var onBoardMember = onBoardMemberDAL.GetOnBoardMemberById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (onBoardMember.Photo.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/OnBoardMember" + "/" + onBoardMember.Photo);
                        onBoardMember.Photo = Id + "_" + filename;
                        var result = onBoardMemberDAL.UpdateOnBoardMember(onBoardMember);

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
        public async Task<IHttpActionResult> SaveOnBoardMemberImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/OnBoardMember" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var onBoardMember = onBoardMemberDAL.GetOnBoardMemberById(Id);
                    var filenamenew = Id + "_" + newFilename;
                    if (onBoardMember.Photo.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/OnBoardMember" + "/" + onBoardMember.Photo);
                        onBoardMember.Photo = filenamenew;
                        var result = onBoardMemberDAL.UpdateOnBoardMember(onBoardMember);
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