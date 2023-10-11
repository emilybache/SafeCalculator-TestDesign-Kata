using Calculator;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace TestCalculator;

[TestFixture]
public class SafeCalculatorNUnitTest
{
    [Test]
    public void DoNotThrowWhenAuthorized()
    {
        var authorizer = new StubAuthorizer(true);
        var calculator = new SafeCalculator(authorizer);
        Assert.AreEqual(3, calculator.Add(1,2));
    }        
        
    [Test]
    public void ThrowWhenNotAuthorized()
    {
        var authorizer = new StubAuthorizer(false);
        var calculator = new SafeCalculator(authorizer);
        Assert.Throws<Exception>(() => calculator.Add(1, 2));
    }
    
    
    public class StubAuthorizer : IAuthorizer
    {
        private bool _authorize;

        public StubAuthorizer(bool authorize)
        {
            _authorize = authorize;
        }

        public bool Authorize()
        {
            return _authorize;
        }
    }
}