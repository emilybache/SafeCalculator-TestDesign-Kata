project(calculator-cmocka C)

add_cmocka_test(calculator_test
        SOURCES test-calculator.c
        LINK_LIBRARIES src cmocka-static)

add_cmocka_test_environment(calculator_test)

set_property(TARGET
        calculator_test
        PROPERTY
        LINK_FLAGS
        "${DEFAULT_LINK_FLAGS} -Wl,--wrap=calculation_is_authorized"
)

