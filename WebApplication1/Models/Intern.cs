using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http2.HPack;

namespace WebApplication1.Models
{
    public class Intern
    {
        public Intern(int Id, string Firstname, string Lastname)
        {
            this.Id = Id;
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Position = "Intern";
            this.Email = String.Format("{0}.{1}@centric.eu", this.Firstname, this.Lastname);
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
    }
}
