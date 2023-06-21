using System;
using NUnit.Framework;
using Scopy.Implementation;

namespace Scopy.UnitTests
{
    public class TimeScopeTests
    {
        private ScopeFactory _scopeFactory;

        [SetUp]
        public void Setup()
        {
            _scopeFactory = new ScopeFactory();
        }

        [Test]
        public void should_create_scope()
        {
            var date = new DateTime(2020, 11, 11);
            using var tsp = _scopeFactory.UseTimeScope();
            tsp.CreateScope(new DateTime(2020, 11, 11));
            Assert.AreEqual(date, tsp.Current);
        }
        
        [Test]
        public void should_create_nested_scope()
        {
            using (var tsp1 = _scopeFactory.UseTimeScope())
            {
                tsp1.CreateScope(new DateTime(1111, 11, 11));
                Assert.AreEqual(new DateTime(1111, 11, 11), tsp1.Current);
                using (var tsp2 = _scopeFactory.UseTimeScope())
                {
                    tsp2.CreateScope(new DateTime(2222, 11, 11));
                    Assert.AreEqual(new DateTime(2222, 11, 11), tsp2.Current);
                }
                Assert.AreEqual(new DateTime(1111, 11, 11), tsp1.Current);
            }
        }

        [Test]
        public void should_return_default_when_value_not_set_on_scope()
        {
            using (var tsp = _scopeFactory.UseTimeScope())
            {
                Assert.AreEqual(default(DateTime), tsp.Current);
            }
        }
    }
}
