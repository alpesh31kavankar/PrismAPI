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
    public class TaskAssignmentController : ApiController
    {
        public Logger Log = null;
        public TaskAssignmentController()
        {
            Log = Logger.GetLogger();
        }

        TaskAssignmentDAL taskAssignmentDAL = new TaskAssignmentDAL();

        [HttpGet]
        [ActionName("GetAllTaskAssignment")]
        public List<TaskAssignment> GetAllTaskAssignment()
        {
            Log.writeMessage("TaskAssignmentController GetAllTaskAssignment Start");
            List<TaskAssignment> list = null;
            try
            {
                list = taskAssignmentDAL.GetAllTaskAssignment();
            }
            catch (Exception ex)
            {
                Log.writeMessage("TaskAssignmentController GetAllTaskAssignment Error " + ex.Message);
            }
            Log.writeMessage("TaskAssignmentController GetAllTaskAssignment End");
            return list;
        }
        [HttpGet]
        [ActionName("GetTaskAssignmentById")]
        public TaskAssignment GetTaskAssignmentById(int Id)
        {
            Log.writeMessage("TaskAssignmentController GetTaskAssignmentById Start");
            TaskAssignment taskAssignment = null;
            try
            {
                taskAssignment = taskAssignmentDAL.GetTaskAssignmentById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("TaskAssignmentController GetTaskAssignmentById Error " + ex.Message);
            }
            Log.writeMessage("TaskAssignmentController GetTaskAssignmentById End");
            return taskAssignment;
        }

        [HttpPost]
        [ActionName("AddTaskAssignment")]
        public IHttpActionResult AddTaskAssignment(TaskAssignment taskAssignment)
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

                taskAssignment.CreatedBy = "Admin";
                taskAssignment.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                taskAssignment.UpdatedBy = "Admin";
                //contact.Status = "Success";
                taskAssignment.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = taskAssignmentDAL.AddTaskAssignment(taskAssignment);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("TaskAssignmentController AddTaskAssignment Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateTaskAssignment")]
        public IHttpActionResult UpdateTaskAssignment(TaskAssignment taskAssignment)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                taskAssignment.CreatedBy = "Admin";
                taskAssignment.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                taskAssignment.UpdatedBy = "Admin";
                taskAssignment.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = taskAssignmentDAL.UpdateTaskAssignment(taskAssignment);


                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }
            }
            catch (Exception ex)
            {
                Log.writeMessage("TaskAssignmentController AddTaskAssignment Error " + ex.Message);
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
        public IHttpActionResult DeleteTaskAssignment(int Id)
        {
            try
            {
                var result = taskAssignmentDAL.DeleteTaskAssignment(Id);

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
                Log.writeMessage("TaskAssignmentController DeleteTaskAssignment Error " + ex.Message);
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
        
