using System.Collections.Generic;

namespace Template.Domain.Models
{
    public class Host
    {
        public string Name { get; set; }
        public List<string> IpAddress { get; set; }
    }
}
