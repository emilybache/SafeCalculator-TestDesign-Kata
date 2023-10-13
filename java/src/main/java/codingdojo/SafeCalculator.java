package codingdojo;

public class SafeCalculator {
  private final Authorizer authorizer;

  SafeCalculator(Authorizer authorizer) {
    this.authorizer = authorizer;
  }

  public int add(int a, int b) {
    var authorized = authorizer.authorize();
    if (authorized) { // <- bug here, should be if (!authorized)
      throw new UnauthorizedAccessException("Not authorized");
    }
    return a + b;
  }
}