#include <stdarg.h>
#include <setjmp.h>
#include <stddef.h>
#include <stdbool.h>
#include "cmocka.h"

#include "calculator.h"


static void test_should_not_raise_error_when_authorized(void **state)
{
    (void)state;  // unused variable

    // TODO: write this test
}



int main(void) {
    const struct CMUnitTest tests[] = {
            cmocka_unit_test(test_should_not_raise_error_when_authorized),
    };

    return cmocka_run_group_tests(tests, NULL, NULL);
}
