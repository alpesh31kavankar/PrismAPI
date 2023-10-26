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
    public class ProductController : ApiController
    {
        public Logger Log = null;
        public ProductController()
        {
            Log = Logger.GetLogger();
        }

        ProductDAL productDAL = new ProductDAL();

        [HttpGet]
        [ActionName("GetAllProduct")]
        public List<Product> GetAllProduct()
        {
            Log.writeMessage("ProductController GetAllProduct Start");
            List<Product> list = null;
            try
            {
                list = productDAL.GetAllProduct();
            }
            catch (Exception ex)
            {
                Log.writeMessage("ProductController GetAllProduct Error " + ex.Message);
            }
            Log.writeMessage("ProductController GetAllProduct End");
            return list;
        }
        [HttpGet]
        [ActionName("GetProductById")]
        public Product GetProductById(int Id)
        {
            Log.writeMessage("ProductController  GetProductById Start");
            Product product = null;
            try
            {
                product = productDAL.GetProductById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("SocialMediaController  GetSocialMediaById " + ex.Message);
            }
            Log.writeMessage("SocialMediaController  GetSocialMediaById End");
            return product;

        }

        [HttpPost]
        [ActionName("AddProduct")]
        public IHttpActionResult AddProduct(Product product)
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

                product.CreatedBy = "Admin";
                product.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                product.UpdatedBy = "Admin";
                product.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                result = productDAL.AddProduct(product);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ProductController AddProduct Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateProduct")]
        public IHttpActionResult UpdateProduct(Product product)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                product.CreatedBy = "Admin";
                product.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                product.UpdatedBy = "Admin";
                //contact.Status = "Success";
                product.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = productDAL.UpdateProduct(product);





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
        public IHttpActionResult DeleteProduct(int Id)
        {
            try
            {
                var result = productDAL.DeleteProduct(Id);

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
        public async Task<IHttpActionResult> SaveProductImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/Product" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var product = productDAL.GetProductById(Id);
                    var filenamenew = Id + "_" + filename;

                    if (filename.StartsWith("MainImage"))
                    {
                        if (product.MainImage.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Product" + "/" + product.MainImage);
                            product.MainImage = Id + "_" + filename;
                            var result = productDAL.UpdateProduct(product);

                        }

                    }
                    if (filename.StartsWith("ProdIcon"))
                    {

                        if (product.ProdIcon.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Product" + "/" + product.ProdIcon);
                            product.ProdIcon = Id + "_" + filename;
                            var result = productDAL.UpdateProduct(product);

                        }
                    }

                    if (filename.StartsWith("Imageone"))
                    {

                        if (product.Imageone.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Product" + "/" + product.Imageone);
                            product.Imageone = Id + "_" + filename;
                            var result = productDAL.UpdateProduct(product);

                        }
                    }

                    if (filename.StartsWith("Imagetwo"))
                    {

                        if (product.Imagetwo.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Product" + "/" + product.Imagetwo);
                            product.Imagetwo = Id + "_" + filename;
                            var result = productDAL.UpdateProduct(product);

                        }
                    }

                    if (filename.StartsWith("Imagethree"))
                    {

                        if (product.Imagethree.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Product" + "/" + product.Imagethree);
                            product.Imagethree = Id + "_" + filename;
                            var result = productDAL.UpdateProduct(product);

                        }
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
        public async Task<IHttpActionResult> SaveProductImage(int Id)
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
                    string newFilename = filename.StartsWith("MainImage") ? "MainImage.jpg" :
                                         filename.StartsWith("ProdIcon") ? "ProdIcon.jpg" :
                                         filename.StartsWith("Imageone") ? "Imageone.jpg" :
                                         filename.StartsWith("Imagetwo") ? "Imagetwo.jpg" :
                                         filename.StartsWith("Imagethree") ? "Imagethree.jpg" : filename;
                    File.WriteAllBytes(theDirectory + "/Content/Product" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var product = productDAL.GetProductById(Id);
                    var filenamenew = Id + "_" + newFilename;

                    if (filename.StartsWith("MainImage"))   // condition
                    {
                        if (product.MainImage.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Product" + "/" + product.MainImage);
                            product.MainImage = filenamenew;
                            var result = productDAL.UpdateProduct(product);
                        }
                    }
                    if (filename.StartsWith("ProdIcon"))
                    {
                        if (product.ProdIcon.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Product" + "/" + product.ProdIcon);
                            product.ProdIcon = filenamenew;
                            var result = productDAL.UpdateProduct(product);
                        }
                    }
                    if (filename.StartsWith("Imageone"))
                    {
                        if (product.Imageone.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Product" + "/" + product.Imageone);
                            product.Imageone = filenamenew;
                            var result = productDAL.UpdateProduct(product);
                        }
                    }

                    if (filename.StartsWith("Imagetwo"))
                    {
                        if (product.Imagetwo.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Product" + "/" + product.Imagetwo);
                            product.Imagetwo = filenamenew;
                            var result = productDAL.UpdateProduct(product);
                        }
                    }

                    if (filename.StartsWith("Imagethree"))
                    {
                        if (product.Imagethree.ToLower() != filenamenew.ToLower())
                        {
                            File.Delete(theDirectory + "/Content/Product" + "/" + product.Imagethree);
                            product.Imagethree = filenamenew;
                            var result = productDAL.UpdateProduct(product);
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