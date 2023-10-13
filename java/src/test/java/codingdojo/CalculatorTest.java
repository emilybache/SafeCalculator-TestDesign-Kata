package codingdojo;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

public class CalculatorTest {
  @Test
  void should_not_throw_when_authorized() {

    Authorizer stubAuthorizer = new StubAuthorizer(true);
    var calculator = new SafeCalculator(stubAuthorizer);
    assertEquals(3, calculator.add(1, 2));
  }

  @Test
  void should_throw_when_not_authorized() {
    Authorizer stubAuthorizer = new StubAuthorizer(false);
    var calculator = new SafeCalculator(stubAuthorizer);
    assertThrows(UnauthorizedAccessException.class, () -> calculator.add(1,2));
  }
}
