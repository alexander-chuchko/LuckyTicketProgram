
namespace LuckyTicketProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            LuckyTicket luckyTicket = new LuckyTicket(new DataValidation(), new StringOperations());
            luckyTicket.ExecuteProgram();
        }
    }
}
