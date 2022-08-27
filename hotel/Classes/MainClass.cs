using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace hotel.Classes
{
    public class MainClass
    {

        public static string GetSha256(string strData)
        {
            var message = Encoding.ASCII.GetBytes(strData);
            SHA256Managed hashString = new SHA256Managed();
            string hex = "";

            var hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
    }
}