const test = require('tape')
const Calculator = require('../calculator')

test('should not throw when authorized', (t) => {
  const calculator = new Calculator()
  calculator.add(1,2)
  t.end()
})
