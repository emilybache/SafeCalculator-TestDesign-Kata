class Authorizer:
    def authorize(self):
        # in real life it would do some fancy lookup accross the network
        raise RuntimeError("not implemented yet")


class SafeCalculator:
    def __init__(self, authorizer: Authorizer):
        self.authorizer = authorizer


    def add(self, left, right):
        authorized = self.authorizer.authorize()
        # Bug! Should be `if not authorized`
        if authorized:
            raise RuntimeError("Not authorized")
        return left + right
