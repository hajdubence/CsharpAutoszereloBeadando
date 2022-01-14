using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoSzerelo_Common.Models
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
        public string StatusToString
        {
            get
            {
                switch (Status)
                {
                    case Status.RecordedWork:
                        return "Felvett munka";
                    case Status.UnderRepair:
                        return "Elvégzés alatt";
                    case Status.Finished:
                        return "Befejezett";
                    default:
                        return "";
                }
            }
        }
        public string DateOfRecordingToString
        {
            get
            {
                return DateOfRecording.ToString();
            }
        }

        public bool ValidateCustomerName() {
            if (String.IsNullOrWhiteSpace(CustomerName))
                return false;
            return Regex.IsMatch(CustomerName, "^[\\p{L} ]+$");
        }

        public bool ValidateCarType()
        {
            if (String.IsNullOrWhiteSpace(CarType))
                return false;
            return Regex.IsMatch(CarType, "^[\\p{L}0-9 ]+$");
        }

        public bool ValidateCarLicensePlate()
        {
            if (String.IsNullOrWhiteSpace(CarLicensePlate))
                return false;
            if (Regex.IsMatch(CarLicensePlate, "^[A-Z]{3}-[0-9]{3}$"))
                return true;
            return false;
        }
        public bool ValidateProblem()
        {
            return !String.IsNullOrWhiteSpace(Problem);
        }
    }
}
