using Cap11.Exercise01.Entities.Exceptions;
using System;
using System.Text;

namespace Cap11.Exercise01.Entities
{
    class Reservation
    {
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reservation() { }

        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            if (CheckOut <= CheckIn)
                throw new ReservationDomainException("Check-out date must not be earlier than Check-in date.");

            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public int Duration()
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return (int)duration.TotalDays;
        }

        public void UpdateReservation(DateTime newCheckIn, DateTime newCheckOut)
        {
            DateTime now = DateTime.Now;
            if (newCheckIn < now || newCheckOut < now)
                throw new ReservationDomainException("Reservations must be made for future dates.");
            else if (CheckOut <= CheckIn)
                throw new ReservationDomainException("Check-out date must not be earlier than Check-in date.");

            CheckIn = newCheckIn;
            CheckOut = newCheckOut;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Room ");
            stringBuilder.Append(RoomNumber);
            stringBuilder.Append(", Check-in: ");
            stringBuilder.Append(CheckIn.ToString("dd/MM/yyyy"));
            stringBuilder.Append(", Check-out: ");
            stringBuilder.Append(CheckOut.ToString("dd/MM/yyyy"));
            stringBuilder.Append(", ");
            stringBuilder.Append(Duration());
            stringBuilder.Append(" nights booked.");

            return stringBuilder.ToString();
        }
    }
}
