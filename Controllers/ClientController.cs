using PrismAPI.DAL;
using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Net;
//using System.Web.Mvc;

namespace PrismAPI.Controllers
{
    public class ClientController : ApiController
    {
        public Logger Log = null;
        public ClientController()
        {
            Log = Logger.GetLogger();
        }

        ClientDAL clientDAL = new ClientDAL();

        [HttpGet]
        [ActionName("GetAllClient")]
        public List<Client> GetAllClient()
        {
            Log.writeMessage("ClientController GetAllClient Start");
            List<Client> list = null;
            try
            {
                list = clientDAL.GetAllClient();
            }
            catch (Exception ex)
            {
                Log.writeMessage("ClientController GetAllClient Error " + ex.Message);
            }
            Log.writeMessage("ClientController GetAllClient End");
            return list;
        }
        [HttpGet]
        [ActionName("GetClientById")]
        public Client GetClientById(int Id)
        {
            Log.writeMessage("ClientController GetClientById Start");
            Client client = null;
            try
            {
                client = clientDAL.GetClientById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("ClientController GetClientById Error " + ex.Message);
            }
            Log.writeMessage("ClientController GetClientById End");
            return client;
        }

        [HttpPost]
        [ActionName("AddClient")]
        public IHttpActionResult AddClient(Client client)
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

                client.CreatedBy = "Admin";
                client.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                client.UpdatedBy = "Admin";
                //contact.Status = "Success";
                client.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = clientDAL.AddClient(client);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ClientController AddClient Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateClient")]
        public IHttpActionResult UpdateClient(Client client)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                client.CreatedBy = "Admin";
                client.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                client.UpdatedBy = "Admin";
                client.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = clientDAL.UpdateClient(client);


                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ClientController AddClient Error " + ex.Message);
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
        public IHttpActionResult DeleteClient(int Id)
        {
            try
            {
                var result = clientDAL.DeleteClient(Id);

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
                Log.writeMessage("ClientController DeleteClient Error " + ex.Message);
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
        public async Task<IHttpActionResult> SaveClientImage(int Id)
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
                    //var filename1 = file.Headers.ContentDisposition.FileName.Trim('\"');
                    var buffer = await file.ReadAsByteArrayAsync();
                    string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
                    //get the folder that's in
                    string theDirectory = Path.GetDirectoryName(fullPath);
                    theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));
                    File.WriteAllBytes(theDirectory + "/Content/Client" + "/" + Id + "_" + filename, buffer);
                    // Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    //var chat = new Chat();
                   
                    var client = clientDAL.GetClientById(Id);
                    var filenamenew = Id + "_" + filename;

                    //documents.PANcard = filenamenew.Substring(0,3);
                    //  var Substring = filename.Substring(0, 9);
                    if (filename.StartsWith("Logo"))
                    {
                        if (client.Logo.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Company" + "/" + client.Logo);
                            client.Logo = Id + "_" + filename;
                            var result = clientDAL.UpdateClient(client);
                        }

                    }
                    if (filename.StartsWith("OwnerPhoto"))
                    {
                        if (client.OwnerPhoto.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Client" + "/" + client.OwnerPhoto);
                            client.OwnerPhoto = Id + "_" + filename;
                            var result = clientDAL.UpdateClient(client);
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
        public async Task<IHttpActionResult> SaveClientImage(int Id)
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
                    string newFilename = filename.StartsWith("Logo") ? "Logo.jpg" :
                                         filename.StartsWith("OwnerPhoto") ? "OwnerPhoto.jpg" : filename;
                    File.WriteAllBytes(theDirectory + "/Content/Client" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var client = clientDAL.GetClientById(Id);
                    var filenamenew = Id + "_" + newFilename;

                    if (filename.StartsWith("Logo"))   // condition
                    {
                        if (client.Logo.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Client" + "/" + client.Logo);
                            client.Logo = filenamenew;
                            var result = clientDAL.UpdateClient(client);
                        }
                    }
                    if (filename.StartsWith("OwnerPhoto"))
                    {
                        if (client.OwnerPhoto.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Client" + "/" + client.OwnerPhoto);
                            client.OwnerPhoto = filenamenew;
                            var result = clientDAL.UpdateClient(client);
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