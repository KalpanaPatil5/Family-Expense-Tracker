using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class FamilyMember
    {
        public int? FamilyMemberId { get; set; }
        public string Name { get; set; }
        public long Cell { get; set; }
        public string Work { get; set; }
        public int? Income { get; set; }
    }
}
