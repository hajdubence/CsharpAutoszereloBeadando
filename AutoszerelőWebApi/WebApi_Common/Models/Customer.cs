using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Common.Models
{
    public enum Status 
    {
        RecordedWork,
        UnderConstruction,
        Finished
    }
    public class Customer
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CarType { get; set; }
        [Required]
        public string LicensePlate { get; set; }
        [Required]
        public string Problem { get; set; }
        public DateTime DateOfRecording { get; set; }
        public Status Status { get; set; }

        public override string ToString()
        {
            switch (Status)
            {
                case Status.RecordedWork: return $"{Name} {CarType} {LicensePlate} - {Problem} {DateOfRecording} Felvett munka";

                case Status.UnderConstruction: return $"{Name} {CarType} {LicensePlate} - {Problem} {DateOfRecording} Elvégzés alatt";

                case Status.Finished: return $"{Name} {CarType} {LicensePlate} - {Problem} {DateOfRecording} Befejezett";

                default: return $"{Name} {CarType} {LicensePlate} - {Problem} {DateOfRecording} {Status}";
            }
        }
    }
}
