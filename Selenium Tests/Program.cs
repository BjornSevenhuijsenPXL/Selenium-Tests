using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            ChromeDriver driver = new ChromeDriver(@"../../" + "/Drivers/");
        }
    }
}
