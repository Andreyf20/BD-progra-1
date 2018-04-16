using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;

namespace BDD1
{
    public class Post
    {
        public int PostBy;
        public string PostIn;
        public DateTime PostDate;
        
        public Post()
        {
            PostBy = ProfesorWindow.ProfesorID;
            PostIn = GetLocalIPAddress();
            PostDate = DateTime.Now;
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}