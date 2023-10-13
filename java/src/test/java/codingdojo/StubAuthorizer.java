package codingdojo;

public class StubAuthorizer implements Authorizer {

    private final boolean authorize;

    public StubAuthorizer(boolean shouldAuthorize) {
        authorize = shouldAuthorize;
    }

    @Override
    public boolean authorize() {
        return authorize;
    }
}
