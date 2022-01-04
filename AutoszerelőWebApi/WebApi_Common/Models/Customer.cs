using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Common.Models
{
    public class Customer
    {
        
        public long Id { get; set; }
        public string Name { get; set; }
        public string CarType { get; set; }
        public string LicensePlate { get; set; }
        public string Problem { get; set; }
        public DateTime DateOfRecording { get; set; }
        public string Status { get; set; }

        public override string ToString()
        {
            return $"{Name} {CarType} {LicensePlate} - {Problem} {DateOfRecording} {Status}";
        }
    }
}
