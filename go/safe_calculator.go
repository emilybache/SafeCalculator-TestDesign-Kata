package calculator

type Calculator struct {
	authorizer IAuthorizer
}

func (c *Calculator) Add(x, y int) int {
	authorized := c.authorizer.Authorize()

	// BUG! Should be if !authorized
	if authorized {
		panic("Not authorized")
	}
	return x + y
}
