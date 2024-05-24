using NUnit.Framework;
using Cdcn.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdcn.Application.Tests
{
    [TestFixture()]
    public class Class1Tests
    {
        [Test()]
        public void GetPowerTest()
        {
            var t = new Class1();
            var result = t.GetPower(1);
            Assert.That(result, Is.EqualTo(1));
        }
    }
}