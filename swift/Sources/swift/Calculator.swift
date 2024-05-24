import Foundation

protocol Authorizer {
    func authorize() throws -> Bool
}

enum AuthorizationError: Error {
    case notImplemented
}

class SafeCalculator {
    private let authorizer: Authorizer

    init(authorizer: Authorizer) {
        self.authorizer = authorizer
    }

    func add(x: Int, y: Int) throws -> Int {
        let authorized = try authorizer.authorize()
        // Bug! should be (!authorized)
        if authorized {
            throw AuthorizationError.notImplemented
        }
        return x + y
    }
}
