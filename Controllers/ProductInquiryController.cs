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
    public class ProductInquiryController :ApiController
    {
        public Logger Log = null;
        public ProductInquiryController()
        {
            Log = Logger.GetLogger();
        }

        ProductInquiryDAL productInquiryDAL = new ProductInquiryDAL();

        [HttpGet]
        [ActionName("GetAllProductInquiry")]
        public List<ProductInquiry> GetAllProductInquiry()
        {
            Log.writeMessage("ProductInquiryController GetAllProductInquiry Start");
            List<ProductInquiry> list = null;
            try
            {
                list = productInquiryDAL.GetAllProductInquiry();
            }
            catch (Exception ex)
            {
                Log.writeMessage("ProductInquiryController GetAllProductInquiry Error " + ex.Message);
            }
            Log.writeMessage("ProductInquiryController GetAllProductInquiry End");
            return list;
        }
        [HttpGet]
        [ActionName("GetProductInquiryById")]
        public ProductInquiry GetProductInquiryById(int Id)
        {
            Log.writeMessage("ProductInquiryController GetProductInquiryById Start");
            ProductInquiry productInquiry = null;
            try
            {
                productInquiry = productInquiryDAL.GetProductInquiryById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("ProductInquiryController GetProductInquiryById Error " + ex.Message);
            }
            Log.writeMessage("ProductInquiryController GetProductInquiryById End");
            return productInquiry;
        }

        [HttpPost]
        [ActionName("AddProductInquiry")]
        public IHttpActionResult AddProductInquiry(ProductInquiry productInquiry)
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

                productInquiry.CreatedBy = "Admin";
                productInquiry.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                productInquiry.UpdatedBy = "Admin";
                //contact.Status = "Success";
                productInquiry.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = productInquiryDAL.AddProductInquiry(productInquiry);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ProductInquiryController AddProductInquiry Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateProductInquiry")]
        public IHttpActionResult UpdateProductInquiry(ProductInquiry productInquiry)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                productInquiry.CreatedBy = "Admin";
                productInquiry.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                productInquiry.UpdatedBy = "Admin";
                productInquiry.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                var result = productInquiryDAL.UpdateProductInquiry(productInquiry);




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
                Log.writeMessage("ProductInquiryController UpdateProductInquiry Error " + ex.Message);
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
        public IHttpActionResult DeleteProductInquiry(int Id)
        {
            try
            {
                var result = productInquiryDAL.DeleteProductInquiry(Id);

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
                Log.writeMessage("ProductInquiryController DeleteProductInquiry Error " + ex.Message);
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