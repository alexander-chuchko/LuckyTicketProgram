using System;
using System.Text.RegularExpressions;

namespace LuckyTicketProgram
{
    class DataValidation : IDataValidation
    {
        private Regex patternNumberTicket;
        public DataValidation()
        {
            patternNumberTicket = new Regex(@"(^\d{4,8})");
        }
        //The ticket number is a number that can be 4-8 digits
        public bool IsValidData(string numberTicket)
        {
            if (patternNumberTicket.IsMatch(numberTicket))
            {
                return true;
            }
            else
            {
                Console.WriteLine("\tIncorrect data entered!");
                return false;
            }
        }
    }
}
