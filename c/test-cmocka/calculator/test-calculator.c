#include <stdarg.h>
#include <setjmp.h>
#include <stddef.h>
#include <stdbool.h>
#include "cmocka.h"

#include "calculator.h"

bool __wrap_calculation_is_authorized(void);
bool __wrap_calculation_is_authorized(void) {
    return mock_type(bool);
}

static void test_should_not_raise_error_when_authorized(void **state)
{
    (void)state;  // unused variable

    will_return_maybe(__wrap_calculation_is_authorized, true);

    int result = 0;
    bool success = calculator_add(10, 2, &result);
    assert_true(success);
    assert_int_equal(12, result);
}


static void test_should_return_error_code_when_not_authorized(void **state)
{
    (void)state;  // unused variable

    will_return_maybe(__wrap_calculation_is_authorized, false);

    int result = 0;
    bool success = calculator_add(10, 2, &result);
    assert_false(success);
}


int main(void) {
    const struct CMUnitTest tests[] = {
            cmocka_unit_test(test_should_not_raise_error_when_authorized),
            cmocka_unit_test(test_should_return_error_code_when_not_authorized),
    };

    return cmocka_run_group_tests(tests, NULL, NULL);
}
