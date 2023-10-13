from unittest.mock import Mock

import pytest

from safe_calculator import SafeCalculator, Authorizer


class StubAuthorizer(Authorizer):
    def __init__(self, is_authorized):
        self.is_authorized = is_authorized

    def authorize(self):
        return self.is_authorized


def test_add_should_not_raise_any_error_when_authorized():
    calculator = SafeCalculator(StubAuthorizer(True))
    assert calculator.add(10, 2) == 12


def test_add_should_raise_error_when_not_authorized():
    calculator = SafeCalculator(StubAuthorizer(False))
    with pytest.raises(RuntimeError):
        calculator.add(10, 2)


def test_add_should_not_raise_any_error_when_authorized_with_fw():
    spy = Mock()
    spy.authorize = Mock(return_value=True)
    calculator = SafeCalculator(spy)
    assert calculator.add(10, 2) == 12


def test_add_should_raise_error_when_not_authorized_with_fw():
    spy = Mock()
    spy.authorize = Mock(return_value=False)
    calculator = SafeCalculator(spy)
    with pytest.raises(RuntimeError):
        calculator.add(10, 2)

