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
    public class DashboardDetailsController : ApiController
    {
        // GET: DashboardDetails
        // GET: DashboardDetails
        public Logger Log = null;
        public DashboardDetailsController()
        {
            Log = Logger.GetLogger();
        }

        DashboardDetailsDAL dashboarddetailsDAL = new DashboardDetailsDAL();

        [HttpGet]
        [ActionName("GetAllDashboardDetails")]
        public DashboardDetails GetAllDashboardDetails()
        {
            DashboardDetails result = null;
            Log.writeMessage("DashboardDetailsController GetAllDashboardDetails Start");
            try
            {
                result = dashboarddetailsDAL.GetAllDashboardDetails();
            }
            catch (Exception ex)
            {
                Log.writeMessage("DashboardDetailsController GetAllDashboardDetails Error " + ex.Message);
            }
            Log.writeMessage("DashboardDetailsController GetAllDashboardDetails End");
            return result;
        }


        [HttpDelete]
        public IHttpActionResult TruncateAllTable()
        {
            try
            {
                var result = dashboarddetailsDAL.TruncateAllTable();

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
                Log.writeMessage("TruncateAllTable  Error " + ex.Message);
            }
            return Ok("Failed");
        }
    }
}