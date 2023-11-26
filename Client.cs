using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLib
{
    public class Client
    {
        public string Id { get; set; }
        public string Service { get; set; }

        public Client(string id, string service)
        {
            Id = id;
            Service = service;
        }
    }
}