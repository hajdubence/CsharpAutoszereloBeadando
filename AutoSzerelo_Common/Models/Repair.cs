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
        UnderRepair,
        Finished
    }
    public class Repair
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CarType { get; set; }
        [Required]
        public string CarLicensePlate { get; set; }
        [Required]
        public string Problem { get; set; }
        public DateTime DateOfRecording { get; set; }
        public Status Status { get; set; }

        public override string ToString()
        {
            switch (Status)
            {
                case Status.RecordedWork: return $"{CustomerName} {CarType} {CarLicensePlate} - {Problem} {DateOfRecording} Felvett munka";

                case Status.UnderRepair: return $"{CustomerName} {CarType} {CarLicensePlate} - {Problem} {DateOfRecording} Elvégzés alatt";

                case Status.Finished: return $"{CustomerName} {CarType} {CarLicensePlate} - {Problem} {DateOfRecording} Befejezett";

                default: return $"{CustomerName} {CarType} {CarLicensePlate} - {Problem} {DateOfRecording} {Status}";
            }
        }
    }
}
