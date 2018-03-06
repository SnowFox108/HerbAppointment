using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace AnyaSpa.ClientTest
{
    public class Runner
    {
        public Runner(TestConnection test)
        {
            //test.Read();
            //test.Insert();
            test.GetCachingService();            
        }
    }
}
