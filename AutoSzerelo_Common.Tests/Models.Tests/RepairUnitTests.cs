using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoSzerelo_Common.Models;

namespace AutoSzerelo_Common.Tests
{
    [TestClass]
    public class RepairUnitTests
    {
        [DataRow(null, false)]
        [DataRow("", false)]
        [DataRow("    ", false)]
        [DataRow("pl !?_-:;#", false)]
        [DataRow("1234", false)]
        [DataRow("Jani", true)]
        [DataRow("árvíztûrõ tükörfúrógép", true)]
        [DataRow("ÁRVÍZTÛRÕ TÜKÖRFÚRÓGÉP", true)]
        [DataTestMethod]
        public void ValidateCustomerName_IfNameIsValid_ReturnsTrue(string toValidate, bool expected)
        {
            Repair reparir = new Repair();
            reparir.CustomerName = toValidate;

            bool actual = reparir.ValidateCustomerName();

            Assert.AreEqual(expected, actual);
        }

        [DataRow(null, false)]
        [DataRow("", false)]
        [DataRow("    ", false)]
        [DataRow("pl !?_-:;#", false)]
        [DataRow("1234", true)]
        [DataRow("Porsche 911", true)]
        [DataRow("árvíztûrõ tükörfúrógép", true)]
        [DataRow("ÁRVÍZTÛRÕ TÜKÖRFÚRÓGÉP", true)]
        [DataTestMethod]
        public void ValidateCarType_IfCarTypeIsValid_ReturnsTrue(string toValidate, bool expected)
        {
            Repair reparir = new Repair();
            reparir.CarType = toValidate;

            bool actual = reparir.ValidateCarType();

            Assert.AreEqual(expected, actual);
        }

        [DataRow(null, false)]
        [DataRow("", false)]
        [DataRow("    ", false)]
        [DataRow("pl !?_-:;#", false)]
        [DataRow("123", false)]
        [DataRow("ABC", false)]
        [DataRow("123-ABC", false)]
        [DataRow("ÁÉÍ-123", false)]
        [DataRow("abc-123", false)]
        [DataRow("ABC-123", true)]
        [DataTestMethod]
        public void ValidateCarLicensePlate_IfCarLicensePlateIsValid_ReturnsTrue(string toValidate, bool expected)
        {
            Repair reparir = new Repair();
            reparir.CarLicensePlate = toValidate;

            bool actual = reparir.ValidateCarLicensePlate();

            Assert.AreEqual(expected, actual);
        }

        [DataRow(null, false)]
        [DataRow("", false)]
        [DataRow("    ", false)]
        [DataRow("pl !?_-:;#", true)]
        [DataRow("1234", true)]
        [DataRow("No problem", true)]
        [DataRow("árvíztûrõ tükörfúrógép", true)]
        [DataRow("ÁRVÍZTÛRÕ TÜKÖRFÚRÓGÉP", true)]
        [DataTestMethod]
        public void ValidateProblem_IfProblemIsValid_ReturnsTrue(string toValidate, bool expected)
        {
            Repair reparir = new Repair();
            reparir.Problem = toValidate;

            bool actual = reparir.ValidateProblem();

            Assert.AreEqual(expected, actual);
        }

    }
}