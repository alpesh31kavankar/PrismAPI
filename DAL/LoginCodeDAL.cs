using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.Http;
using PrismAPI.Models;
using PrismAPI.DAL;
using System.Data.Common;

namespace PrismAPI.DAL
{
    public class LoginCodeDAL
    {
        DbConnection conn = null;
        public LoginCodeDAL()
        {
            conn = new DbConnection();
        }

        public List<LoginCode> GetAllLoginCode()
        {
            List<LoginCode> loginCodeList = new List<LoginCode>();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetAllUserLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                LoginCode loginCode = new LoginCode();

                loginCode.Id = Convert.ToInt32(dr["Id"]);

                loginCode.Name = Convert.ToString(dr["Name"]);
                loginCode.Email = Convert.ToString(dr["Email"]);
                loginCode.Mobile = Convert.ToString(dr["Mobile"]);
                loginCode.Password = Convert.ToString(dr["Password"]);

                loginCode.Address = Convert.ToString(dr["Address"]);

                loginCode.BirthDate = Convert.ToString(dr["BirthDate"]);

                loginCode.Photo = Convert.ToString(dr["Photo"]);
                loginCode.EmailStatus = Convert.ToString(dr["EmailStatus"]);
                loginCode.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                loginCode.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                loginCode.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                loginCode.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                loginCodeList.Add(loginCode);
            }
            con.Close();
            return loginCodeList;
        }


        public LoginCode GetLoginCodeByEmail(string Email)
        {
            LoginCode loginCode = new LoginCode();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetUserLoginByEmail", con);
            cmd.Parameters.Add("p_Email", MySqlDbType.VarChar).Value = Email;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                loginCode.Id = Convert.ToInt32(dr["Id"]);

                loginCode.Name = Convert.ToString(dr["Name"]);
                loginCode.Email = Convert.ToString(dr["Email"]);
                loginCode.Mobile = Convert.ToString(dr["Mobile"]);
                loginCode.Password = Convert.ToString(dr["Password"]);
                loginCode.Address = Convert.ToString(dr["Address"]);

                loginCode.BirthDate = Convert.ToString(dr["BirthDate"]);

                loginCode.Photo = Convert.ToString(dr["Photo"]);
                loginCode.EmailStatus = Convert.ToString(dr["EmailStatus"]);

                loginCode.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                loginCode.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                loginCode.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                loginCode.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
            }
            con.Close();
            return loginCode;
        }



        public LoginCode GetLoginCodeById(int Id)
        {
            LoginCode loginCode = new LoginCode();

            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetUserLoginById", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                loginCode.Id = Convert.ToInt32(dr["Id"]);

                loginCode.Name = Convert.ToString(dr["Name"]);
                loginCode.Email = Convert.ToString(dr["Email"]);
                loginCode.Mobile = Convert.ToString(dr["Mobile"]);
                loginCode.Password = Convert.ToString(dr["Password"]);
                loginCode.Address = Convert.ToString(dr["Address"]);

                loginCode.BirthDate = Convert.ToString(dr["BirthDate"]);

                loginCode.Photo = Convert.ToString(dr["Photo"]);
                loginCode.EmailStatus = Convert.ToString(dr["EmailStatus"]);

                loginCode.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                loginCode.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                loginCode.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                loginCode.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return loginCode;
        }


        public string AddLoginCode(LoginCode loginCode)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("AddUserLogin", con);
            //cmd.Parameters.Add("Id", MySqlDbType.Int).Value = instructor.Id;
            cmd.Parameters.Add("p_Name", MySqlDbType.VarChar).Value = loginCode.Name;
            cmd.Parameters.Add("p_Email", MySqlDbType.VarChar).Value = loginCode.Email;
            cmd.Parameters.Add("p_Mobile", MySqlDbType.VarChar).Value = loginCode.Mobile;
            cmd.Parameters.Add("p_Password", MySqlDbType.VarChar).Value = loginCode.Password;
            cmd.Parameters.Add("p_Address", MySqlDbType.VarChar).Value = loginCode.Address;

            cmd.Parameters.Add("p_BirthDate", MySqlDbType.VarChar).Value = loginCode.BirthDate;
            cmd.Parameters.Add("p_Photo", MySqlDbType.VarChar).Value = loginCode.Photo;
            cmd.Parameters.Add("p_EmailStatus", MySqlDbType.VarChar).Value = loginCode.EmailStatus;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = loginCode.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = loginCode.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = loginCode.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = loginCode.UpdatedDate;


            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return Id.ToString();

        }

        [HttpPost]
        public string UpdateLoginCode(LoginCode loginCode)
        {
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("UpdateUserLogin", con);
            cmd.Parameters.Add("p_Id", MySqlDbType.Int32).Value = loginCode.Id;

            cmd.Parameters.Add("p_Name", MySqlDbType.VarChar).Value = loginCode.Name;
            cmd.Parameters.Add("p_Email", MySqlDbType.VarChar).Value = loginCode.Email;
            cmd.Parameters.Add("p_Mobile", MySqlDbType.VarChar).Value = loginCode.Mobile;
            cmd.Parameters.Add("p_Password", MySqlDbType.VarChar).Value = loginCode.Password;
            cmd.Parameters.Add("p_Address", MySqlDbType.VarChar).Value = loginCode.Address;

            cmd.Parameters.Add("p_BirthDate", MySqlDbType.VarChar).Value = loginCode.BirthDate;
            cmd.Parameters.Add("p_Photo", MySqlDbType.VarChar).Value = loginCode.Photo;
            cmd.Parameters.Add("p_EmailStatus", MySqlDbType.VarChar).Value = loginCode.EmailStatus;
            cmd.Parameters.Add("p_CreatedBy", MySqlDbType.VarChar).Value = loginCode.CreatedBy;
            cmd.Parameters.Add("p_CreatedDate", MySqlDbType.VarChar).Value = loginCode.CreatedDate;
            cmd.Parameters.Add("p_UpdatedBy", MySqlDbType.VarChar).Value = loginCode.UpdatedBy;
            cmd.Parameters.Add("p_UpdatedDate", MySqlDbType.VarChar).Value = loginCode.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return loginCode.Id.ToString();

        }

        public Loginc Loginc(string Email, string Password)
        {
            Loginc user = new Loginc();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetUserEmailAndPassword", con);
            cmd.Parameters.Add("p_Email", MySqlDbType.VarChar).Value = Email;
            cmd.Parameters.Add("p_Password", MySqlDbType.VarChar).Value = Password;
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                user.Id = Convert.ToInt32(dr["Id"]);
                //user.Role = Convert.ToString(dr["Role"]);
            }
            return user;
        }


        public OtpNo OtpNo(string Mobile)
        {
            OtpNo OtpNo = new OtpNo();
            MySqlConnection con = conn.OpenDbConnection();
            MySqlCommand cmd = new MySqlCommand("GetUserOtp", con);
            cmd.Parameters.Add("Mobile", MySqlDbType.VarChar).Value = Mobile;

            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                OtpNo.Id = Convert.ToInt32(dr["Id"]);
                //user.Role = Convert.ToString(dr["Role"]);
            }
            return OtpNo;
        }
        //public string UpdateFirstModel(FirstModel firstModel)
        //{
        //    MySqlConnection con = conn.OpenDbConnection();
        //    MySqlCommand cmd = new MySqlCommand("UpdateFirstModel", con);
        //    cmd.Parameters.Add("Id", MySqlDbType.Int).Value = firstModel.Id;
        //    cmd.Parameters.Add("FirstName", MySqlDbType.VarChar).Value = firstModel.FirstName;
        //    cmd.Parameters.Add("LastName", MySqlDbType.VarChar).Value = firstModel.LastName;
        //    cmd.Parameters.Add("DOB", MySqlDbType.VarChar).Value = firstModel.DOB;





        //    //cmd.Parameters.Add("CreatedBy", MySqlDbType.VarChar).Value = firstModel.CreatedBy;
        //    //cmd.Parameters.Add("CreatedDate", MySqlDbType.VarChar).Value = firstModel.CreatedDate;
        //    //cmd.Parameters.Add("UpdatedBy", MySqlDbType.VarChar).Value = firstModel.UpdatedBy;
        //    //cmd.Parameters.Add("UpdatedDate", MySqlDbType.VarChar).Value = firstModel.UpdatedDate;

        //    cmd.CommandType = CommandType.StoredProcedure;
        //    object result = cmd.ExecuteScalar();

        //    con.Close();
        //    if (result.ToString() == "0")
        //    {
        //        return "Failed";
        //    }
        //    return "Success";
        //}


        //public string DeleteFirstModel(int Id)
        //{
        //    MySqlConnection con = conn.OpenDbConnection();
        //    MySqlCommand cmd = new MySqlCommand("DeleteFirstModel", con);
        //    cmd.Parameters.Add("Id", MySqlDbType.Int).Value = Id;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    object result = cmd.ExecuteScalar();

        //    con.Close();
        //    if (result.ToString() == "0")
        //    {
        //        return "Failed";
        //    }
        //    return "Success";
        //}
    }
}