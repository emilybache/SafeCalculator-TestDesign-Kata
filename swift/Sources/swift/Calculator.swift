import Foundation

class Authorizer {
    func authorize() throws -> Bool {
        // In real life, this would perform network authorization logic
        throw AuthorizationError.notImplemented
    }
}

enum AuthorizationError: Error {
    case notImplemented
}

class SafeCalculator {
    private let authorizer: Authorizer

    init(authorizer: Authorizer) {
        self.authorizer = authorizer
    }

    func add(left: Int, right: Int) throws -> Int {
        let authorized = try authorizer.authorize()
        if authorized {
            throw AuthorizationError.notImplemented
        }
        return left + right
    }
}
