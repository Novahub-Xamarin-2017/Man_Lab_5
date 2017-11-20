using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    class RootObject
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public override string ToString() => $"UserID: {UserId}\tId: {Id}\tTitle: {Title}\tBody: {Body}";
    }
}
