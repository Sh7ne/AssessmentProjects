using System;
using BillSplitApp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BillSplitApp.UnitTest
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void GetAmountOwedPerPerson()
        {
            //act
            var testTrip = new Trip(3);
            var charge0 = new Charge(0);
            charge0.Price.Add(10m);
            charge0.Price.Add(20m);
            var charge1 = new Charge(1);
            charge1.Price.Add(15m);
            charge1.Price.Add(15.01m);
            charge1.Price.Add(3m);
            charge1.Price.Add(3.01m);
            var charge2 = new Charge(2);
            charge2.Price.Add(5m);
            charge2.Price.Add(9m);
            charge2.Price.Add(4m);

            testTrip.Charges.Add(charge0);
            testTrip.Charges.Add(charge1);
            testTrip.Charges.Add(charge2);

            //assert
            Assert.AreEqual(testTrip.NumberOfParticipants, 3);
            Assert.AreEqual(testTrip.GetAmountOwedPerPerson(0), -1.99m);
            Assert.AreEqual(testTrip.GetAmountOwedPerPerson(1), -8.01m);
            Assert.AreEqual(testTrip.GetAmountOwedPerPerson(2), 10.01m);
        }
    }
}
