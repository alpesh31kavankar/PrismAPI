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
    public class TestimonialController : ApiController
    {
        public Logger Log = null;
        public TestimonialController()
        {
            Log = Logger.GetLogger();
        }

        TestimonialDAL testimonialDAL = new TestimonialDAL();

        [HttpGet]
        [ActionName("GetAllTestimonial")]
        public List<Testimonial> GetAllTestimonial()
        {
            Log.writeMessage("TestimonialController GetAllTestimonial Start");
            List<Testimonial> list = null;
            try
            {
                list = testimonialDAL.GetAllTestimonial();
            }
            catch (Exception ex)
            {
                Log.writeMessage("TestimonialController GetAllTestimonial Error " + ex.Message);
            }
            Log.writeMessage("TestimonialController GetAllTestimonial End");
            return list;
        }
        [HttpGet]
        [ActionName("GetTestimonialById")]
        public Testimonial GetTestimonialById(int Id)
        {
            Log.writeMessage("TestimonialController GetTestimonialById Start");
            Testimonial testimonial = null;
            try
            {
                testimonial = testimonialDAL.GetTestimonialById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("TestimonialController GetTestimonialById Error " + ex.Message);
            }
            Log.writeMessage("TestimonialController GetTestimonialById End");
            return testimonial;
        }

        [HttpPost]
        [ActionName("AddTestimonial")]
        public IHttpActionResult AddTestimonial(Testimonial testimonial)
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

                testimonial.CreatedBy = "Admin";
                testimonial.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                testimonial.UpdatedBy = "Admin";
                //contact.Status = "Success";
                testimonial.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = testimonialDAL.AddTestimonial(testimonial);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("TestimonialController AddTestimonial Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateTestimonial")]
        public IHttpActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                testimonial.CreatedBy = "Admin";
                testimonial.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                testimonial.UpdatedBy = "Admin";
                testimonial.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = testimonialDAL.UpdateTestimonial(testimonial);


                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("TestimonialController AddTestimonial Error " + ex.Message);
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
        public IHttpActionResult DeleteTestimonial(int Id)
        {
            try
            {
                var result = testimonialDAL.DeleteTestimonial(Id);

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
                Log.writeMessage("TestimonialController DeleteTestimonial Error " + ex.Message);
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
        public async Task<IHttpActionResult> SaveTestimonialImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/Testimonial" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var testimonial = testimonialDAL.GetTestimonialById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (testimonial.Photo.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/Testimonial" + "/" + testimonial.Photo);
                        testimonial.Photo = Id + "_" + filename;
                        var result = testimonialDAL.UpdateTestimonial(testimonial);

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
        public async Task<IHttpActionResult> SaveTestimonialImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/Testimonial" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var testimonial = testimonialDAL.GetTestimonialById(Id);
                    var filenamenew = Id + "_" + newFilename;
                    if (testimonial.Photo.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/Testimonial" + "/" + testimonial.Photo);
                        testimonial.Photo = filenamenew;
                        var result = testimonialDAL.UpdateTestimonial(testimonial);

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