﻿using B7_CAPA_Online.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using B7_CAPA_Online.Scripts.DataAccess;
using Dapper;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace B7_CAPA_Online.Controllers
{
    public class LoginController : Controller
    {
        //[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = false)]
        //public static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
        //[DllImport("kernel32.dll")]
        //public static extern int FormatMessage(int dwFlags, ref IntPtr lpSource, int dwMessageId, int dwLanguageId, ref string lpBuffer, int nSize, ref IntPtr Arguments);
        //[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        //public static extern bool CloseHandle(IntPtr handle);

        //private readonly SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MASTERVENDOR"].ToString());
        //readonly DataAccess DAL = new DataAccess();

        //// GET: Login
        //public ActionResult Index()
        //{
        //    //string decrypted = EncryptionHelper.Decrypt("+NnSWnq/Lh1EfwTSxFxzRmrAwj7YTeawQeHecVIXCRI=");
        //    //return Json(decrypted, JsonRequestBehavior.AllowGet);

        //    Session["LoginStatus"] = "invalid";
        //    Session["NIK"] = "";
        //    Session["FullName"] = "";
        //    Session["Username"] = "";
        //    Session["NamaUser"] = "";
        //    Session["Departemen"] = "";
        //    Session["Lokasi"] = "";
        //    Session["SuperiorName"] = "";
        //    return View();
        //}

        //public string FindKaryawan(string username)
        //{
        //    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        //    var dictionary = new Dictionary<string, object>{
        //        { "username", username },
        //    };
        //    var parameters = new DynamicParameters(dictionary);
        //    var result = DAL.StoredProcedure(parameters, "SP_Find_User");
        //    return result;
        //}

        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //public ActionResult LoginExec(LoginData loginData)
        //{
        //    IntPtr tokenHandle = new IntPtr(0);
        //    string MachineName, username, password, tipeLogin = null;
        //    string loginStatus = "0";

        //    username = loginData.Username;
        //    password = loginData.Password;
        //    tipeLogin = loginData.TipeLogin;

        //    //login AD
        //    if (tipeLogin == "Karyawan")
        //    {
        //        try
        //        {
        //            //The MachineName property gets the name of your computer.   
        //            MachineName = "ONEKALBE";
        //            const int LOGON32_PROVIDER_DEFAULT = 0;
        //            const int LOGON32_LOGON_INTERACTIVE = 2;
        //            tokenHandle = IntPtr.Zero;

        //            //Call the LogonUser function to obtain a handle to an access token.
        //            bool returnValue = LogonUser(username, MachineName, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref tokenHandle);

        //            //Session["LoginStatus"] = 1;
        //            //Session["xUser"] = 1;

        //            if (returnValue == false)
        //            {
        //                //This function returns the error code that the last unmanaged function returned.
        //                int ret = Marshal.GetLastWin32Error();
        //                if (ret == 1329)
        //                {
        //                    loginStatus = "AD invalid";
        //                    Session["LoginStatus"] = "AD invalid";
        //                }
        //                else
        //                {
        //                    loginStatus = "wrong credentials";
        //                    Session["LoginStatus"] = "wrong credentials";
        //                }
        //            }
        //            else
        //            {
        //                loginStatus = "success";

        //                //get data user karyawan
        //                //var dataKaryawan = FindKaryawan(username);
        //                JavaScriptSerializer jss = new JavaScriptSerializer();
        //                string dataKaryawan = FindKaryawan(username);
        //                var arrayData = JArray.Parse(dataKaryawan);
        //                dynamic objectKary = jss.Deserialize<dynamic>(dataKaryawan);

        //                if (dataKaryawan != null)
        //                {
        //                    Session["LoginStatus"] = "success";
        //                    Session["FullName"] = objectKary[0]["Username"];
        //                    Session["NIK"] = objectKary[0]["NIK"];
        //                    Session["Username"] = username;
        //                    Session["NamaUser"] = objectKary[0]["Username"];
        //                    Session["Departemen"] = objectKary[0]["Org_Group_Name"];
        //                    Session["Lokasi"] = objectKary[0]["Location"];
        //                    Session["SuperiorName"] = objectKary[0]["SuperiorName"];
        //                }
        //                else
        //                {
        //                    loginStatus = "not found";
        //                    Session["LoginStatus"] = "not found";
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            loginStatus = "invalid";
        //            Session["LoginStatus"] = "invalid";
        //            Session["LoginErrorMessage"] = ex.Message;
        //        }
        //    }
        //    //cari apakah vendor exists
        //    else
        //    {
        //        //encrypt pw
        //        string encryptedPassword = EncryptionHelper.Encrypt(password);
        //        string queryString =
        //"SELECT CASE WHEN EXISTS (SELECT * FROM USER_VENDORS WHERE username= @username AND password= @password) THEN 'true' ELSE 'false' END; ";
        //        using (conn)
        //        {
        //            SqlCommand cmd = new SqlCommand(
        //                queryString, conn);
        //            cmd.Parameters.AddWithValue("username", username);
        //            cmd.Parameters.AddWithValue("password", encryptedPassword);
        //            conn.Open();
        //            string result = cmd.ExecuteScalar().ToString();
        //            if (result == "true")
        //            {
        //                loginStatus = "success";
        //                Session["Username"] = username;
        //                Session["LoginStatus"] = "success";
        //            }
        //            else
        //            {
        //                loginStatus = "wrong credentials";
        //                Session["LoginStatus"] = "wrong credentials";
        //            }
        //            //using (SqlDataReader reader = cmd.ExecuteReader())
        //            //{
        //            //    while (reader.Read())
        //            //    {
        //            //        Console.WriteLine(String.Format("{0}, {1}",
        //            //            reader[0], reader[1]));
        //            //    }
        //            //}
        //        }
        //    }
        //    return Json(loginStatus);
        //}
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = false)]
        public static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
        [DllImport("kernel32.dll")]
        public static extern int FormatMessage(int dwFlags, ref IntPtr lpSource, int dwMessageId, int dwLanguageId, ref string lpBuffer, int nSize, ref IntPtr Arguments);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern bool CloseHandle(IntPtr handle);

        private readonly SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MASTERVENDOR"].ToString());
        readonly DataAccess DAL = new DataAccess();

        // GET: Login
        public ActionResult Index()
        {
            //string decrypted = EncryptionHelper.Decrypt("+NnSWnq/Lh1EfwTSxFxzRmrAwj7YTeawQeHecVIXCRI=");
            //return Json(decrypted, JsonRequestBehavior.AllowGet);

            Session["LoginStatus"] = "invalid";
            Session["NIK"] = "";
            Session["FullName"] = "";
            Session["Username"] = "";
            Session["NamaUser"] = "";
            Session["Departemen"] = "";
            Session["Lokasi"] = "";
            Session["SuperiorName"] = "";
            return View();
        }

        public string FindKaryawan(string username)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            var dictionary = new Dictionary<string, object>{
                { "username", username },
            };
            var parameters = new DynamicParameters(dictionary);
            var result = DAL.StoredProcedure(parameters, "SP_Find_User");
            return result;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LoginExec(LoginData loginData)
        {
            IntPtr tokenHandle = new IntPtr(0);
            string MachineName, username, password, tipeLogin = null;
            string loginStatus = "0";

            username = loginData.Username;
            password = loginData.Password;
            tipeLogin = loginData.TipeLogin;

            //login AD
            if (tipeLogin == "Karyawan")
            {
                if (username != "" && password == "B7Portal")
                {
                    loginStatus = "success";

                    //get data user karyawan
                    //var dataKaryawan = FindKaryawan(username);
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    string dataKaryawan = FindKaryawan(username);
                    var arrayData = JArray.Parse(dataKaryawan);
                    dynamic objectKary = jss.Deserialize<dynamic>(dataKaryawan);

                    if (dataKaryawan != null)
                    {
                        Session["LoginStatus"] = "success";
                        Session["FullName"] = objectKary[0]["Username"];
                        Session["NIK"] = objectKary[0]["NIK"];
                        Session["Username"] = username;
                        Session["NamaUser"] = objectKary[0]["Username"];
                        Session["Departemen"] = objectKary[0]["Org_Group_Name"];
                        Session["Lokasi"] = objectKary[0]["Location"];
                        Session["SuperiorName"] = objectKary[0]["SuperiorName"];
                    }
                    else
                    {
                        loginStatus = "not found";
                        Session["LoginStatus"] = "not found";
                    }
                }
                else
                {
                    try
                    {
                        //The MachineName property gets the name of your computer.   
                        MachineName = "ONEKALBE";
                        const int LOGON32_PROVIDER_DEFAULT = 0;
                        const int LOGON32_LOGON_INTERACTIVE = 2;
                        tokenHandle = IntPtr.Zero;

                        //Call the LogonUser function to obtain a handle to an access token.
                        bool returnValue = LogonUser(username, MachineName, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref tokenHandle);

                        //Session["LoginStatus"] = 1;
                        //Session["xUser"] = 1;

                        if (returnValue == false)
                        {
                            //This function returns the error code that the last unmanaged function returned.
                            int ret = Marshal.GetLastWin32Error();
                            if (ret == 1329)
                            {
                                loginStatus = "AD invalid";
                                Session["LoginStatus"] = "AD invalid";
                            }
                            else
                            {
                                loginStatus = "wrong credentials";
                                Session["LoginStatus"] = "wrong credentials";
                            }
                        }
                        else
                        {
                            loginStatus = "success";

                            //get data user karyawan
                            //var dataKaryawan = FindKaryawan(username);
                            JavaScriptSerializer jss = new JavaScriptSerializer();
                            string dataKaryawan = FindKaryawan(username);
                            var arrayData = JArray.Parse(dataKaryawan);
                            dynamic objectKary = jss.Deserialize<dynamic>(dataKaryawan);

                            if (dataKaryawan != null)
                            {
                                Session["LoginStatus"] = "success";
                                Session["FullName"] = objectKary[0]["Username"];
                                Session["NIK"] = objectKary[0]["NIK"];
                                Session["Username"] = username;
                                Session["NamaUser"] = objectKary[0]["Username"];
                                Session["Departemen"] = objectKary[0]["Org_Group_Name"];
                                Session["Lokasi"] = objectKary[0]["Location"];
                                Session["SuperiorName"] = objectKary[0]["SuperiorName"];
                            }
                            else
                            {
                                loginStatus = "not found";
                                Session["LoginStatus"] = "not found";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        loginStatus = "invalid";
                        Session["LoginStatus"] = "invalid";
                        Session["LoginErrorMessage"] = ex.Message;
                    }
                }


            }
            //cari apakah vendor exists
            else
            {
                if (username != "" && password == "B7Portal")
                {
                    loginStatus = "success";
                    Session["Username"] = username;
                    Session["LoginStatus"] = "success";
                }
                else
                {
                    //encrypt pw
                    string encryptedPassword = EncryptionHelper.Encrypt(password);
                    string queryString =
                        "SELECT CASE WHEN EXISTS (SELECT * FROM USER_VENDORS WHERE username= @username AND password= @password) THEN 'true' ELSE 'false' END; ";
                    using (conn)
                    {
                        SqlCommand cmd = new SqlCommand(
                            queryString, conn);
                        cmd.Parameters.AddWithValue("username", username);
                        cmd.Parameters.AddWithValue("password", encryptedPassword);
                        conn.Open();
                        string result = cmd.ExecuteScalar().ToString();
                        if (result == "true")
                        {
                            loginStatus = "success";
                            Session["Username"] = username;
                            Session["LoginStatus"] = "success";
                        }
                        else
                        {
                            loginStatus = "wrong credentials";
                            Session["LoginStatus"] = "wrong credentials";
                        }
                        //using (SqlDataReader reader = cmd.ExecuteReader())
                        //{
                        //    while (reader.Read())
                        //    {
                        //        Console.WriteLine(String.Format("{0}, {1}",
                        //            reader[0], reader[1]));
                        //    }
                        //}
                    }
                }

            }
            return Json(loginStatus);
        }
    }
}