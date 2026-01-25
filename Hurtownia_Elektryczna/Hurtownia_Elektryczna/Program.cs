using Hurtownia_Elektryczna.Menu;

namespace Hurtownia_Elektryczna
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var menu = new MenuManager();
            menu.Start();
        }
    }
}