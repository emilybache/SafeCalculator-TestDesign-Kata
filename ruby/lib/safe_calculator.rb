# frozen_string_literal: true

class Authorizer
  def authorize
    # in real life it would do some fancy lookup accross the network
    raise StandardError, 'not implemented yet'
  end
end

class SafeCalculator
  def initialize(authorizer)
    @authorizer = authorizer
  end

  def add(left, right)
    authorized = @authorizer.authorize

    # Bug! Should be `if !authorized`
    raise StandardError, 'Not authorized' if authorized

    left + right
  end
end
