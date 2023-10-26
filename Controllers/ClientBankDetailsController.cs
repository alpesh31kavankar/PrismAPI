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
    public class ClientBankDetailsController : ApiController
    {
        public Logger Log = null;
        public ClientBankDetailsController()
        {
            Log = Logger.GetLogger();
        }

        ClientBankDetailsDAL clientBankDetailsDAL = new ClientBankDetailsDAL();

        [HttpGet]
        [ActionName("GetAllClientBankDetails")]
        public List<ClientBankDetails> GetAllGetAllClientBankDetailsChat()
        {
            Log.writeMessage("ClientBankDetailsController GetAllClientBankDetails Start");
            List<ClientBankDetails> list = null;
            try
            {
                list = clientBankDetailsDAL.GetAllClientBankDetails();
            }
            catch (Exception ex)
            {
                Log.writeMessage("ClientBankDetailsController GetAllClientBankDetails  Error " + ex.Message);
            }
            Log.writeMessage("ClientBankDetailsController GetAllClientBankDetails  End");
            return list;
        }
        [HttpGet]
        [ActionName("GetClientBankDetailsById")]
        public ClientBankDetails GetClientBankDetailsById(int Id)
        {
            Log.writeMessage("ClientBankDetailsController GetClientBankDetailsById Start");
            ClientBankDetails clientBankDetails = null;
            try
            {
                clientBankDetails = clientBankDetailsDAL.GetClientBankDetailsById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("ClientBankDetailsController GetClientBankDetailsById Error " + ex.Message);
            }
            Log.writeMessage("ClientBankDetailsController GetClientBankDetailsById End");
            return clientBankDetails;
        }
        [HttpPost]
        [ActionName("AddClientBankDetails")]
        public IHttpActionResult AddClientBankDetails(ClientBankDetails clientBankDetails)
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

                clientBankDetails.CreatedBy = "Admin";
                clientBankDetails.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                clientBankDetails.UpdatedBy = "Admin";
                //contact.Status = "Success";
                clientBankDetails.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = clientBankDetailsDAL.AddClientBankDetails(clientBankDetails);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ClientBankDetailsController AddClientBankDetails  Error " + ex.Message);
            }
            return Ok(result);
        }
        [HttpPost]
        [ActionName("UpdateClientBankDetails")]
        public IHttpActionResult UpdateClientBankDetails(ClientBankDetails clientBankDetails)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                clientBankDetails.CreatedBy = "Admin";
                clientBankDetails.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                clientBankDetails.UpdatedBy = "Admin";
                clientBankDetails.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = clientBankDetailsDAL.UpdateClientBankDetails(clientBankDetails);


                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ClientBankDetailsController AddClientBankDetails Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpDelete]
        public IHttpActionResult DeleteClientBankDetails(int Id)
        {
            try
            {
                var result = clientBankDetailsDAL.DeleteClientBankDetails(Id);

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
                Log.writeMessage("ChatController DeleteClientBankDetails Error " + ex.Message);
            }
            return Ok("Failed");
        }

        /*
                [HttpPost]
                public async Task<IHttpActionResult> SaveChatImage(int Id)
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
                            File.WriteAllBytes(theDirectory + "/Content/image" + "/" + Id + "_" + filename, buffer);
                            // Do whatever you want with filename and its binary data.

                            // get existing rocrd
                            //var chat = new Chat();
                            var chat = chatDAL.GetChatById(Id);
                            var filenamenew = Id + "_" + filename;




                            var subString = filename.Substring(0, 3);
                            if (subString == "Aad")
                            {

                                if (chat.Adharcard.ToLower() != filenamenew.ToLower())
                                {
                                    chat.Adharcard = filenamenew;
                                    File.Delete(theDirectory + "/Content/image" + "/" + chat.Adharcard);
                                    chat.Adharcard = filename + "_" + Id;
                                    // documents.PANcard = (Id+"_"+documents.PANcard);
                                    var result = chatDAL.UpdateChat(chat);


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
       /* [HttpPost]
        public async Task<IHttpActionResult> SaveClientBankDetailsImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/ClientBankDetails" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                  
                    var ClientBankDetails = clientBankDetailsDAL.GetClientBankDetailsById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (ClientBankDetails.QRCode.ToLower() != filenamenew.ToLower())
                    {

                        File.Delete(theDirectory + "/Content/ClientBankDetails" + "/" + ClientBankDetails.QRCode);
                        ClientBankDetails.QRCode = Id + "_" + filename;
                        var result = clientBankDetailsDAL.UpdateClientBankDetails(ClientBankDetails);
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
        public async Task<IHttpActionResult> SaveClientBankDetailsImage(int Id)
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
                    string newFilename = filename.StartsWith("QRCode") ? "QRCode.jpg" : filename;
                    File.WriteAllBytes(theDirectory + "/Content/ClientBankDetails" + "/" + Id + "_" + newFilename, buffer);   // content folder

                    // Do whatever you want with newFilename and its binary data.

                    // get existing record
                    var ClientBankDetails = clientBankDetailsDAL.GetClientBankDetailsById(Id);
                    var filenamenew = Id + "_" + newFilename;
                    if (ClientBankDetails.QRCode.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/Blog" + "/" + ClientBankDetails.QRCode);
                        ClientBankDetails.QRCode = filenamenew;
                        var result = clientBankDetailsDAL.UpdateClientBankDetails(ClientBankDetails);

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