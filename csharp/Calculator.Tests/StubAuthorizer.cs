using Calculator;

namespace TestCalculator;

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