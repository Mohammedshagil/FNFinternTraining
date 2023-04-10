using System.Security.Cryptography;

namespace ConsoleApp2
{
    public delegate void MutualFundTrigger(int Nav);
    public class MutualFund
    {
        int Nav = 40;
        
        public void SetNavPoints(int Nav)
        {
            this.Nav = Nav;
            this.DisplayDashboard();
        }
        void DisplayDashboard()
        {
            Dashboard.DisplayDashboard(Nav);
        }

    }
    public class Dashboard
    {
        public static void DisplayDashboard(int Nav)
        {
            if(Nav < 40)
            {
                Console.Write($"\t\t\t    {DateTime.Now}    |   {Nav:00}   |");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("    BAD");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if(Nav > 40)
            {
                Console.Write($"\t\t\t    {DateTime.Now}    |   {Nav:00}   |");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("    GOOD");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else { Console.WriteLine($"\t\t\t    {DateTime.Now}    |   {Nav:00}   |    STATIC\t"); }
        }
    }



    public class MarketInsights
    {
        public event MutualFundTrigger MutualFundTrigger;
        int marketUnit;
        Random ran = new();
        public void MarketInsight() {
            if (MutualFundTrigger != null)
            {
                while (true)
                {
                marketUnit = RandomNumberGenerator(0, 100);
                System.Threading.Thread.Sleep(1000);
                this.NotifyTheUnit(marketUnit);
                }
            }
        }

        public void NotifyTheUnit(int marketUnit)
        {
            this.MutualFundTrigger.Invoke(marketUnit);
        }

        private int RandomNumberGenerator(int v1, int v2)
        {
            return ran.Next(v1, v2);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string displayMsg = "************************************MUTUALFUND DASHBOARD*****************************************\r\n\r\n\t\t\t         DATE              | POINTS |    STATUS\t";
            Console.WriteLine(displayMsg);
            MarketInsights marketInsights = new();
            MutualFund mutualFund = new();
            MutualFundTrigger MFTrigger = new(mutualFund.SetNavPoints);
            marketInsights.MutualFundTrigger += MFTrigger;
            marketInsights.MarketInsight();



        }
    }
}