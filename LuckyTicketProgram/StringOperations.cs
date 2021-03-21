using System;

namespace LuckyTicketProgram
{
    class StringOperations : IStringOperations
    {
        //Method that checks for a value for parity
        public bool IsEvenValue(string numberTicket)
        {
            if (numberTicket.Length % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Method adding zero to number ticket
        public string AddZeroToNumberTicket(string numberTicket)
        {
            return numberTicket.Insert(0, "0");
        }
        //Method for split and compare of strings
        public bool IsEqualValue(string numberTicket)
        {
            int countFirstPart = 0;
            int countSecondPart = 0;
            int iterationCounter = 0;
            try
            {
                foreach (char symbol in numberTicket)
                {
                    if (numberTicket.Length / 2 > iterationCounter)
                    {
                        countFirstPart += (int)char.GetNumericValue(symbol);
                        iterationCounter++;
                    }
                    else
                    {
                        countSecondPart += (int)char.GetNumericValue(symbol);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: "+ex.Message);
            }

            if (countFirstPart == countSecondPart)
            {
                Console.WriteLine(string.Format("\t{0} - Lucky ticket!", numberTicket));
                return true;
            }
            else
            {
                Console.WriteLine(string.Format("\t{0} - Unlucky ticket!", numberTicket));
                return false;
            }
        }
    }
}
