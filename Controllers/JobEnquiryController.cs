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
    public class JobEnquiryController : ApiController

    {
        public Logger Log = null;
        public JobEnquiryController()
        {
            Log = Logger.GetLogger();
        }

        JobEnquiryDAL jobEnquiryDAL = new JobEnquiryDAL();

        [HttpGet]
        [ActionName("GetAllJobEnquiry")]
        public List<JobEnquiry> GetAllJobEnquiry()
        {
            Log.writeMessage("JobEnquiryController GetAllJobEnquiry Start");
            List<JobEnquiry> list = null;
            try
            {
                list = jobEnquiryDAL.GetAllJobEnquiry();
            }
            catch (Exception ex)
            {
                Log.writeMessage("JobEnquiryController GetAllJobEnquiry Error " + ex.Message);
            }
            Log.writeMessage("JobEnquiryController GetAllJobEnquiry End");
            return list;
        }
        [HttpGet]
        [ActionName("GetJobEnquiryById")]
        public JobEnquiry GetJobEnquiryById(int Id)
        {
            Log.writeMessage("JobEnquiryController GetJobEnquiryById Start");
            JobEnquiry jobEnquiry = null;
            try
            {
                jobEnquiry = jobEnquiryDAL.GetJobEnquiryById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("JobEnquiryController GetJobEnquiryById Error " + ex.Message);
            }
            Log.writeMessage("JobEnquiryController GetJobEnquiryById End");
            return jobEnquiry;
        }

        [HttpPost]
        [ActionName("AddJobEnquiry")]
        public IHttpActionResult AddJobEnquiry(JobEnquiry jobEnquiry)
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

                jobEnquiry.CreatedBy = "Admin";
                jobEnquiry.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                jobEnquiry.UpdatedBy = "Admin";
                //contact.Status = "Success";
                jobEnquiry.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = jobEnquiryDAL.AddJobEnquiry(jobEnquiry);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("JobEnquiryController AddJobEnquiry Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateJobEnquiry")]
        public IHttpActionResult UpdateJobEnquiry(JobEnquiry jobEnquiry)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                jobEnquiry.CreatedBy = "Admin";
                jobEnquiry.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                jobEnquiry.UpdatedBy = "Admin";
                jobEnquiry.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = jobEnquiryDAL.UpdateJobEnquiry(jobEnquiry);


                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }
            }
            catch (Exception ex)
            {
                Log.writeMessage("JobEnquiryController AddJobEnquiry Error " + ex.Message);
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

        public IHttpActionResult DeleteJobEnquiry(int Id)
        {
            try
            {
                var result = jobEnquiryDAL.DeleteJobEnquiry(Id);

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
                Log.writeMessage("JobEnquiryController DeleteJobEnquiryError " + ex.Message);
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


        [HttpPost]
        public async Task<IHttpActionResult> SaveCv(int Id)
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
                    string newFilename = filename.StartsWith("CV") ? "CV.pdf" : filename;
                    File.WriteAllBytes(theDirectory + "/Content/Cv" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var jobEnquiry = jobEnquiryDAL.GetJobEnquiryById(Id);
                    var filenamenew = Id + "_" + newFilename;
                    if (jobEnquiry.CV.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/Cv" + "/" + jobEnquiry.CV);
                        jobEnquiry.CV = filenamenew;
                        var result = jobEnquiryDAL.UpdateJobEnquiry(jobEnquiry);

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