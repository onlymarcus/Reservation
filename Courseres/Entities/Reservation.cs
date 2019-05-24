using System;
using Courseres.Entities.Exceptions;

namespace Courseres.Entities
{
    class Reservation
    {
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        
        public Reservation()
        {

        }

        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            if (checkOut <= checkIn)
            {
                throw new DomainExcepcion("Error in reservation: Check-Out date must be after Check-In");
            }
            
            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public int Duration()
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return (int)duration.TotalDays;
        }

        public void UpdateDates(DateTime checkIn, DateTime checkOut)
        {
            DateTime now = DateTime.Now;
            if (checkIn < now || checkOut < now)
            {
                throw new DomainExcepcion("Error in reservation: Reservation dates for update must be future dates.");
            }
            if (checkOut <= checkIn)
            {
                throw new DomainExcepcion("Error in reservation: Check-Out date must be after Check-In");
            }

            CheckIn = checkIn;
            CheckOut = checkOut;
            
        }

        public override string ToString()
        {
            return "Room "
                + RoomNumber
                + ", Chek-in: "
                + CheckIn.ToString("dd/MM/yyyy")
                + ", Chek-Out: "
                + CheckOut.ToString("dd/MM/yyy")
                + ", "
                + Duration()
                + " nights.";
        }
    }
}
