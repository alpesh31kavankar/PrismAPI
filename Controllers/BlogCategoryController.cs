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
    public class BlogCategoryController : ApiController
    {
        public Logger Log = null;
        public BlogCategoryController()
        {
            Log = Logger.GetLogger();
        }

        BlogCategoryDAL blogCategoryDAL = new BlogCategoryDAL();

        [HttpGet]
        [ActionName("GetAllBlogCategory")]
        public List<BlogCategory> GetAllBlogCategory()
        {
            Log.writeMessage("BlogCategoryController GetAllBlogCategory Start");
            List<BlogCategory> list = null;
            try
            {
                list = blogCategoryDAL.GetAllBlogCategory();
            }
            catch (Exception ex)
            {
                Log.writeMessage("BlogCategoryController GetAllBlogCategory Error " + ex.Message);
            }
            Log.writeMessage("BlogCategoryController GetAllBlogCategory End");
            return list;
        }
        [HttpGet]
        [ActionName("GetBlogCategoryById")]
        public BlogCategory GetBlogCategoryById(int Id)
        {
            Log.writeMessage("BlogCategoryController GetBlogCategoryById Start");
            BlogCategory blogCategory = null;
            try
            {
                blogCategory = blogCategoryDAL.GetBlogCategoryById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("BlogCategoryController GetBlogCategoryById Error " + ex.Message);
            }
            Log.writeMessage("BlogCategoryController GetBlogCategoryById End");
            return blogCategory;
        }

        [HttpPost]
        [ActionName("AddBlogCategory")]
        public IHttpActionResult AddBlogCategory(BlogCategory blogCategory)
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

                blogCategory.CreatedBy = "Admin";
                blogCategory.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                blogCategory.UpdatedBy = "Admin";
                //contact.Status = "Success";
                blogCategory.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = blogCategoryDAL.AddBlogCategory(blogCategory);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("BlogCategoryController AddBlogCategory Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateBlogCategory")]
        public IHttpActionResult UpdateBlogCategory(BlogCategory blogCategory)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                blogCategory.CreatedBy = "Admin";
                blogCategory.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                blogCategory.UpdatedBy = "Admin";
                blogCategory.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = blogCategoryDAL.UpdateBlogCategory(blogCategory);


                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("BlogCategoryController AddBlogCategory Error " + ex.Message);
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
        public IHttpActionResult DeleteBlogCategory(int Id)
        {
            try
            {
                var result = blogCategoryDAL.DeleteBlogCategory(Id);

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
                Log.writeMessage("BlogCategoryController DeleteBlogCategory Error " + ex.Message);
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
        public async Task<IHttpActionResult>SaveBlogCategoryImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/BlogCategory" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var BlogCategory = blogCategoryDAL.GetBlogCategoryById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (BlogCategory.Image.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/BlogCategory" + "/" + BlogCategory.Image);
                        BlogCategory.Image = Id + "_" + filename;
                        var result = blogCategoryDAL.UpdateBlogCategory(BlogCategory);

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
        public async Task<IHttpActionResult> SaveBlogCategoryImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/BlogCategory" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var BlogCategory = blogCategoryDAL.GetBlogCategoryById(Id);
                    var filenamenew = Id + "_" + newFilename;
                    if (BlogCategory.Image.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/BlogCategory" + "/" + BlogCategory.Image);
                        BlogCategory.Image = filenamenew;
                        var result = blogCategoryDAL.UpdateBlogCategory(BlogCategory);

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