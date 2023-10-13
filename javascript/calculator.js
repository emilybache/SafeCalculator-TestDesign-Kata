class SafeCalculator {
  constructor (authorizer) {
    this.authorizer = authorizer
  }

  add (a, b) {
    const authorized = this.authorizer.authorize()
    // Bug! Should be `if(!authorized)`
    if (authorized) {
      throw new Error('Not authorized')
    }
    return a / b
  }
}

module.exports = SafeCalculator
