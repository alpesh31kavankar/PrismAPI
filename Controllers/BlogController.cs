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
    public class BlogController : ApiController
    {
        public Logger Log = null;
        public BlogController()
        {
            Log = Logger.GetLogger();
        }

        BlogDAL blogDAL = new BlogDAL();

        [HttpGet]
        [ActionName("GetAllBlog")]
        public List<Blog> GetAllBlog()
        {
            Log.writeMessage("BlogController GetAllBlog Start");
            List<Blog> list = null;
            try
            {
                list = blogDAL.GetAllBlog();
            }
            catch (Exception ex)
            {
                Log.writeMessage("BlogController GetAllBlog Error " + ex.Message);
            }
            Log.writeMessage("BlogController GetAllBlog End");
            return list;
        }
        [HttpGet]
        [ActionName("GetBlogById")]
        public Blog GetBlogById(int Id)
        {
            Log.writeMessage("BlogController  GetBlogById Start");
            Blog blog = null;
            try
            {
                blog = blogDAL.GetBlogById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("BlogController  GetBlogById " + ex.Message);
            }
            Log.writeMessage("BlogController  GetBlogById End");
            return blog;

        }

        [HttpPost]
        [ActionName("AddBlog")]
        public IHttpActionResult AddBlog(Blog blog)
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

                blog.CreatedBy = "Admin";
                blog.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                blog.UpdatedBy = "Admin";
                blog.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                result = blogDAL.AddBlog(blog);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("BlogController AdBlog Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateBlog")]
        public IHttpActionResult UpdateBlog(Blog blog)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                blog.CreatedBy = "Admin";
                blog.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                blog.UpdatedBy = "Admin";
                blog.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = blogDAL.UpdateBlog(blog);


                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }
            }
            catch (Exception ex)
            {
                Log.writeMessage("Result1Controller AddResult1 Error " + ex.Message);
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
        public IHttpActionResult DeleteBlog(int Id)
        {
            try
            {
                var result = blogDAL.DeleteBlog(Id);

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
                Log.writeMessage("Result1Controller DeleteResult1 Error " + ex.Message);
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
        public async Task<IHttpActionResult> SaveBlogImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/Blog" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var blog = blogDAL.GetBlogById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (blog.BlogImg.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/BLog" + "/" + blog.BlogImg);
                        blog.BlogImg = Id + "_" + filename;
                        var result = blogDAL.UpdateBlog(blog);

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
        public async Task<IHttpActionResult> SaveBlogImage(int Id)
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
                    string newFilename = filename.StartsWith("BlogImg") ? "BlogImg.jpg" : filename;
                    File.WriteAllBytes(theDirectory + "/Content/Blog" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var blog = blogDAL.GetBlogById(Id);
                    var filenamenew = Id + "_" + newFilename;
                    if (blog.BlogImg.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/Blog" + "/" + blog.BlogImg);
                        blog.BlogImg = filenamenew;
                        var result = blogDAL.UpdateBlog(blog);

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