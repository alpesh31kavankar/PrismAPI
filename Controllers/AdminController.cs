using PrismAPI.DAL;
using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;

namespace PrismAPI.Controllers
{
    public class AdminController : ApiController
    {
        public Logger Log = null;
        public AdminController()
        {
            Log = Logger.GetLogger();
        }

        AdminDAL adminDAL = new AdminDAL();

        [HttpGet]
        [ActionName("GetAllAdmin")]
        public List<Admin> GetAllAdmin()
        {
            Log.writeMessage("AdminController GetAllAdmin Start");
            List<Admin> list = null;
            try
            {
                list = adminDAL.GetAllAdmin();
            }
            catch (Exception ex)
            {
                Log.writeMessage("AdminController GetAllAdmin Error " + ex.Message);
            }
            Log.writeMessage("AdminController GetAllAdmin End");
            return list;
        }
        [HttpGet]
        [ActionName("GetAdminById")]
        public Admin GetAdminById(int Id)
        {
            Log.writeMessage("AdminController GetAdminById Start");
            Admin admin = null;
            try
            {
                admin = adminDAL.GetAdminById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("AdminController GetAdminById Error " + ex.Message);
            }
            Log.writeMessage("AdminController GetAdminById End");
            return admin;
        }

        [HttpPost]
        [ActionName("AddAdmin")]
        public IHttpActionResult AddAdmin(Admin admin)
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

                admin.CreatedBy = "Admin";
                admin.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                admin.UpdatedBy = "Admin";
                //contact.Status = "Success";
                admin.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = adminDAL.AddAdmin(admin);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("AdminController AddAdmin Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [ActionName("Logins")]
        public Logins Logins(string Email, string Password)
        {
            Log.writeMessage("AdminController GetAdminById Start");
            Logins user = null;
            try
            {
                user = adminDAL.Logins(Email,Password);
            }
            catch (Exception ex)
            {
                Log.writeMessage("AdminController GetAdminById Error " + ex.Message);
            }
            Log.writeMessage("AdminController GetAdminById End");
            return user;
        }

        [HttpPost]
        [ActionName("UpdateAdmin")]
        public IHttpActionResult UpdateAdmin(Admin admin)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                admin.CreatedBy = "Admin";
                admin.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                admin.UpdatedBy = "Admin";
                admin.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = adminDAL.AddAdmin(admin);


                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("AdminController Addadmin Error " + ex.Message);
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
        public IHttpActionResult DeleteAdmin(int Id)
        {
            try
            {
                var result = adminDAL.DeleteAdmin(Id);

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
                Log.writeMessage("AdminController DeleteAdmin Error " + ex.Message);
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


      /*  [HttpPost]
        public async Task<IHttpActionResult>SaveAdminImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/Admin" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var admin = adminDAL.GetAdminById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (admin.Photo.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/Admin" + "/" + admin.Photo);
                        admin.Photo = Id + "_" + filename;
                        var result = adminDAL.UpdateAdmin(admin);

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
        public async Task<IHttpActionResult> SaveAdminImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/Admin" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var admin = adminDAL.GetAdminById(Id);
                    var filenamenew = Id + "_" + newFilename;
                        if (admin.Photo.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Admin" + "/" + admin.Photo);
                            admin.Photo = filenamenew;
                            var result = adminDAL.UpdateAdmin(admin);

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