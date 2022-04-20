using System;
using System.Collections.Generic;

namespace LuckyTicketProgram
{
    class LuckyTicket
    {
        private int numberOfEnteredNumbers;
        private int numberOfLuckyTickets;
        private int numberOfUnluckyTickets;
        private DateTime gameStartTime;
        private DateTime gameEndTime;
        private int durationGame;
        private List<string> allNumberTicket = new List<string>();
        readonly IDataValidation dataValidation;
        readonly IStringOperations stringOperations;

        public LuckyTicket(IDataValidation dataValidation, IStringOperations stringOperations)
        {
            this.dataValidation = dataValidation;
            this.stringOperations = stringOperations;
        }
        public void ShowStatistics()
        {
            Console.Clear();
            Console.WriteLine("\n\tGame statistics:");
            Console.WriteLine(string.Format("\n\tNumber of attempts - {0} " +
                "\n\tNumber of lucky tickets - {1}" +
                " \n\tNumber of unlucky tickets - {2}" +
                " \n\tGame start time - {3} " +
                "\n\tGame end time - {4} " +
                "\n\tDuration of a game session - {5} sec.",
                numberOfEnteredNumbers,
                numberOfLuckyTickets,
                numberOfUnluckyTickets,
                gameStartTime,
                gameEndTime,
                durationGame));
            Console.WriteLine("\tEntered ticket numbers:");
            foreach (string number in allNumberTicket)
            {
                Console.WriteLine(string.Format("\t- {0}", number));
            }
        }
        public void ExecuteProgram()
        {
            gameStartTime = DateTime.Now;
            ConsoleKeyInfo keyPress;
            do
            {
                Console.WriteLine("\n\t\t\t\tWelcome to the Lucky Ticket Program!\n\n\tEnter ticket number:");
                string numberTicket = Console.ReadLine();
                //Validate the entered data
                if (dataValidation.IsValidData(numberTicket))
                {
                    //Checking the number of entered values
                    if (!stringOperations.IsEvenValue(numberTicket))
                    {
                        numberTicket = stringOperations.AddZeroToNumberTicket(numberTicket);
                    }
                    if (stringOperations.IsEqualValue(numberTicket))
                    {
                        numberOfLuckyTickets++;
                    }
                    else
                    {
                        numberOfUnluckyTickets++;
                    }
                    numberOfEnteredNumbers++;
                    AddNumber(numberTicket);
                }
                Console.WriteLine("\n\tTo enter a new ticket number press - 'Enter'" +
                                  "\n\tExiting the program - 'e'\n");
                keyPress = Console.ReadKey();
            } while (keyPress.KeyChar != 'e');
            gameEndTime = DateTime.Now;
            //Call the method CalculateDuration
            CalculateDuration();
            //Call the method ShowStatistics
            ShowStatistics();
        }
        public void CalculateDuration()
        {
            durationGame = (int)Math.Abs((gameEndTime - gameStartTime).TotalSeconds);
        }
        public void AddNumber(string numberTicket)
        {
            allNumberTicket.Add(numberTicket);

        }
    }
}
