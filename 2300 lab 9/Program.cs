using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4_1
{
    //Written By Lauren Sisson Dales
    //Written on Dec 5th, 2021
    //Assignment 4
    class Program
    {
        public static void Main()
        {
            //required vairables
            string[] SeatAssign;
            SeatAssign = new string[10];
            string cName = "";
            char choice;



            //do while loop with switch for user input
            do
            {
                //using switch and validating user input
                Console.WriteLine("Please enter 'B' to Book, 'C'to cancel, 'P' to print seats or 'Q' to quit");
                if (!char.TryParse(Console.ReadLine().ToUpper(), out choice))

                    Console.WriteLine("This is not valid input, please enter 'B','C','P' or 'Q'");

                switch (char.ToUpper(choice))
                {
                    //using switch to call correct methods
                    case 'B':
                        Console.WriteLine("Book");
                        Booking(SeatAssign, cName);
                        break;
                    case 'C':
                        Console.WriteLine("Cancel");
                        Cancel(SeatAssign, cName);
                        break;
                    case 'P':
                        Console.WriteLine("Print");
                        PrintSeat(SeatAssign);
                        break;
                    case 'Q':
                        Console.WriteLine("Goodbye");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("This is not valid input");
                        break;

                }
                //until user chooses to quit
            }
            while (char.ToUpper(choice) != 'Q' || (choice != 'B') || (choice != 'C') || (choice != 'P'));
        }
        //method to find empty seat
        public static int FindEmptySeat(string[] SeatAssign)
        {
            //creating an int to return and hold value of seat, has to be negative because array starts at 0.
            int locationFound = -1;
            //for loop to go through array
            for (int i = 0; i < SeatAssign.Length; i++)
            {
                //if to find an empty seat
                if (SeatAssign[i] == null)
                {

                    Console.WriteLine("{0}", i);

                    locationFound = i;
                    //returning location and leaving function
                    return locationFound;

                }
                else
                {
                    //if there are no empty seats
                    locationFound = -1;
                    Console.WriteLine("{0}", locationFound);

                }


            }
            //varaible to hold empty seat number
            return locationFound;
        }


        //method to find their seat after it has been booked
        public static int FindCustomerSeat(string[] SeatAssign, string cName)
        {
            //same as above, creating a varaible to return seat location if costumer is already booked on flight
            int location = -1;

            //asking for user input, validating, assigning to variable cName
            Console.WriteLine("Please enter your first and last name");
            cName = Console.ReadLine();
            if (string.IsNullOrEmpty(cName))
            {
                Console.WriteLine("This is invalid input");
                cName = Console.ReadLine();
            }
            //searching through array to find cName that user has put in
            else
            {
                for (int i = 0; i < SeatAssign.Length; ++i)
                    if (cName == SeatAssign[i])
                    {
                        //finding location in array and returning to end function
                        location = i;
                        Console.WriteLine("You are booked on this flight in seat number {0}", location);
                        return location;

                    }

            }
            //varaible to hold found costumer seat
            return location;

        }
        public static void Booking(string[] SeatAssign, string cName)
        {
            //assigning variables form above methods
            int location = FindEmptySeat(SeatAssign);
            int seat = FindCustomerSeat(SeatAssign, cName);
            //making sure the seat int is within the array
            if (seat != -1)
                return;
            Console.WriteLine("Seat {0} is avaliable, please enter your first and last name to book this seat", location);
            cName = Console.ReadLine();
            if (string.IsNullOrEmpty(cName))
            {
                Console.WriteLine("This is invalid input");
                cName = Console.ReadLine();
            }
            else
            //putting in array 
            {

                SeatAssign[location] = cName;
            }

            //so custumer knows seat number. 
            Console.WriteLine("You {0} are now confirmed", cName);




        }
        public static void Cancel(string[] SeatAssign, string cName)
        {
            //passing found seat from method so it can be removed
            int seat = FindCustomerSeat(SeatAssign, cName);
            try
            {
                //changing the found seat to null in the array 
                SeatAssign[seat] = null;
                Console.WriteLine("Your seat on this flight is canceled.");

            }
            //an exception if the array is empty
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("There are no seats booked");
            }



        }
        static void PrintSeat(string[] SeatAssign)
        {
            //printing entire array.
            Array.ForEach(SeatAssign, Console.WriteLine);

        }
    }


}


