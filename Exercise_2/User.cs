using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public Company Company { get; set; }

        public override string ToString() => $"Id: {Id}" +
                                             $"\nName: {Name}" +
                                             $"\nUserName: {Username}" +
                                             $"\nEmail: {Email}" +
                                             $"\nAddress: {Address}" +
                                             $"\nPhone: {Phone}" +
                                             $"\nWebsite: {Website}" +
                                             $"\nCompany: {Company}";
    }
}
