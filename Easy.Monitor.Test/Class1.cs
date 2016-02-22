using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace Easy.Monitor.Test
{
    public class Class1
    {
        [Test]
        public void DateTimeConverTest()
        {
            var stringdate = "201601020304";

            int year = int.Parse(stringdate.Substring(0, 4));
            int month = int.Parse(stringdate.Substring(4,2));
            int day = int.Parse(stringdate.Substring(6,2));
            int hour = int.Parse(stringdate.Substring(8, 2));
            int minute = int.Parse(stringdate.Substring(10, 2));

        }
    }
}
