using System;
using System.Collections.Generic;
using System.Text;
using Calculator;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace TestCalculator;

public class SafeCalculatorXUnitTest
{
    [Fact]
    public void DoNotThrowWhenAuthorized()
    {
        var authorizer = new StubAuthorizer(true);
        var calculator = new SafeCalculator(authorizer);
        Assert.Equal(3, calculator.Add(1,2));
    }        
        
    [Fact]
    public void ThrowWhenNotAuthorized()
    {
        var authorizer = new StubAuthorizer(false);
        var calculator = new SafeCalculator(authorizer);
        Assert.Throws<Exception>(() => calculator.Add(1, 2));
    }
        
    [Fact]
    public void DoNotThrowWhenAuthorized_Moq()
    {
        var authorizer = new Mock<IAuthorizer>();
        authorizer.Setup(a => a.Authorize()).Returns(true);
        var calculator = new SafeCalculator(authorizer.Object);
        Assert.Equal(3, calculator.Add(1,2));
    }
        
    [Fact]
    public void ThrowWhenNotAuthorized_Moq()
    {
        IAuthorizer authorizer = Mock.Of<IAuthorizer>(a => a.Authorize() == false);
        var calculator = new SafeCalculator(authorizer);
        Assert.Throws<Exception>(() => calculator.Add(1, 2));
    }
}
