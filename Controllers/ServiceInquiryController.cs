using PrismAPI.DAL;
using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;

namespace PrismAPI.Controllers
{
    public class ServiceInquiryController :ApiController
    {
        public Logger Log = null;
        public ServiceInquiryController()
        {
            Log = Logger.GetLogger();
        }

        ServiceInquiryDAL serviceInquiryDAL = new ServiceInquiryDAL();

        [HttpGet]
        [ActionName("GetAllServiceInquiry")]
        public List<ServiceInquiry> GetAllServiceInquiry()
        {
            Log.writeMessage("ServiceInquiryController GetAllServiceInquiry Start");
            List<ServiceInquiry> list = null;
            try
            {
                list = serviceInquiryDAL.GetAllServiceInquiry();
            }
            catch (Exception ex)
            {
                Log.writeMessage("ServiceInquiryController GetAllServiceInquiry Error " + ex.Message);
            }
            Log.writeMessage("ServiceInquiryController GetAllServiceInquiry End");
            return list;
        }
        [HttpGet]
        [ActionName("GetServiceInquiryById")]
        public ServiceInquiry GetServiceInquiryById(int Id)
        {
            Log.writeMessage("ServiceInquiryController GetServiceInquiryById Start");
            ServiceInquiry serviceInquiry = null;
            try
            {
                serviceInquiry = serviceInquiryDAL.GetServiceInquiryById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("ServiceInquiryController GetServiceInquiryById Error " + ex.Message);
            }
            Log.writeMessage("ServiceInquiryController GetServiceInquiryById End");
            return serviceInquiry;
        }

        [HttpPost]
        [ActionName("AddServiceInquiry")]
        public IHttpActionResult AddServiceInquiry(ServiceInquiry serviceInquiry)
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

                serviceInquiry.CreatedBy = "Admin";
                serviceInquiry.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                serviceInquiry.UpdatedBy = "Admin";
                //contact.Status = "Success";
                serviceInquiry.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = serviceInquiryDAL.AddServiceInquiry(serviceInquiry);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ServiceInquiryController AddServiceInquiry Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateServiceInquiry")]
        public IHttpActionResult UpdateServiceInquiry(ServiceInquiry serviceInquiry)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                serviceInquiry.CreatedBy = "Admin";
                serviceInquiry.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                serviceInquiry.UpdatedBy = "Admin";
                serviceInquiry.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                var result = serviceInquiryDAL.UpdateServiceInquiry(serviceInquiry);




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
                Log.writeMessage("ServiceInquiryController UpdateServiceInquiry Error " + ex.Message);
            }
            return Ok("Failed");
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
        public IHttpActionResult DeleteServiceInquiry(int Id)
        {
            try
            {
                var result = serviceInquiryDAL.DeleteServiceInquiry(Id);

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
                Log.writeMessage("ServiceInquiryController DeleteServiceInquiry Error " + ex.Message);
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
        //public async Task<IHttpActionResult> SaveTeacherImage(int Id)
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
        //            File.WriteAllBytes(theDirectory + "/Content/Teacher" + "/" + Id + "_" + filename, buffer);
        //            //Do whatever you want with filename and its binary data.

        //            // get existing rocrd
        //            var teacher = TeacherDAL.GetTeacherById(Id);
        //            var filenamenew = Id + "_" + filename;
        //            if (teacher.Photo.ToLower() != filenamenew.ToLower())
        //            {
        //                File.Delete(theDirectory + "/Content/Teacher" + "/" + teacher.Photo);
        //                teacher.Photo = Id + "_" + filename;
        //                var result = TeacherDAL.UpdateTeacher(teacher);

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage(ex.Message);
        //    }

        //    return Ok();
        //}
    }
}