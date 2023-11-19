using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    internal class BookingHelper_OverlappingBookingsExistTests
    {
        [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
            //// Arrange
            //var booking = new Booking
            //{
            //    Id = 2,
            //    ArrivalDate = ArriveOn(2017, 1, 15),
            //    DepartureDate = DepartOn(2017, 1, 20),
            //    Reference = "a"
            //};
            //var unitOfWork = new FakeUnitOfWork();
            //unitOfWork.Bookings = new List<Booking>
            //{
            //    new Booking
            //    {
            //        Id = 1,
            //        ArrivalDate = ArriveOn(2017, 1, 10),
            //        DepartureDate = DepartOn(2017, 1, 14),
            //        Reference = "b"
            //    }
            //};
            //var bookingHelper = new BookingHelper(unitOfWork);

            //// Act
            //var result = bookingHelper.OverlappingBookingsExist(booking);

            //// Assert
            //Assert.That(result, Is.Empty);
        }

    }
}
