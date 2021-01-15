using Cap11.Exercise01.Entities;
using Cap11.Exercise01.Entities.Exceptions;
using Cap11.Exercise02.Entities;
using Cap11.Exercise02.Entities.Exceptions;
using System;
using System.Globalization;

namespace Cap11
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise02();
        }

        private static void Exercise01()
        {
            try
            {
                Console.Write("Enter Room Number: ");
                int roomNumber = int.Parse(Console.ReadLine());
                Console.Write("Enter Check-in Date (DD/MM/YYYY): ");
                DateTime checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter Check-out Date (DD/MM/YYYY): ");
                DateTime checkOut = DateTime.Parse(Console.ReadLine());

                Reservation reservation = new Reservation(roomNumber, checkIn, checkOut);

                Console.WriteLine();
                Console.WriteLine("Reservation" + reservation);

                Console.WriteLine();
                Console.WriteLine("Enter dates to update the reservation:");
                Console.Write("Check-in: ");
                checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out: ");
                checkOut = DateTime.Parse(Console.ReadLine());
                reservation.UpdateReservation(checkIn, checkOut);

                Console.WriteLine();
                Console.WriteLine("Updated Reservation" + reservation);
            }
            catch (FormatException error)
            {
                Console.WriteLine("Error in Format: " + error.Message);
            }
            catch (ReservationDomainException error)
            {
                Console.WriteLine("Error in Reservation: " + error.Message);
            }
            catch (Exception error)
            {
                Console.WriteLine("Unexpected Error: " + error.Message);
            }
        }

        private static void Exercise02()
        {
            Console.WriteLine("Enter Account Data:");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Holder: ");
            string holder = Console.ReadLine();
            Console.Write("Initial Balance: ");
            double initialBalance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Withdraw Limit: ");
            double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Account account = new Account(number, holder, initialBalance, withdrawLimit);

            Console.Write("Enter amount for withdraw: ");
            double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            try
            {
                account.Withdraw(amount);
                Console.WriteLine("Balance Updated: " + account.Balance.ToString("f2", CultureInfo.InvariantCulture));
            }
            catch (AccountDomainException error)
            {
                Console.WriteLine("Withdraw Error: " + error.Message);
            }
        }
    }
}
