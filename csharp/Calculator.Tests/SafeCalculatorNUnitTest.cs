using Calculator;
using Moq;
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
        
    [Test]
    public void DoNotThrowWhenAuthorized_Moq()
    {
        var authorizer = new Mock<IAuthorizer>();
        authorizer.Setup(a => a.Authorize()).Returns(true);
        var calculator = new SafeCalculator(authorizer.Object);
        Assert.AreEqual(3, calculator.Add(1,2));
    }
        
    [Test]
    public void ThrowWhenNotAuthorized_Moq()
    {
        IAuthorizer authorizer = Mock.Of<IAuthorizer>(a => a.Authorize() == false);
        var calculator = new SafeCalculator(authorizer);
        Assert.Throws<Exception>(() => calculator.Add(1, 2));
    }
}