namespace Shopping.Web.Pages
{
    public class CheckoutModel(IBasketService basketService, ILogger<CheckoutModel> logger)
        : PageModel
    {
        [BindProperty]
        public BasketCheckoutModel Order { get; set; } = default!;
        public ShoppingCartModel Cart { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            Cart = await basketService.LoadUserBasket();
            return Page();
        }
        public async Task<IActionResult> OnPostCheckoutAsync()
        {
            logger.LogInformation("Checkout button clicked");
            Cart = await basketService.LoadUserBasket();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //assume customerid is passed from the UI authenticated user 'swn'
            Order.CustomerId = new Guid("58c49479-ec65-4de2-86e7-033c546291aa");
            Order.UserName = Cart.UserName;
            Order.TotalPrice = Cart.TotalPrice;
            await basketService.CheckoutBasket(new CheckoutBasketRequest(Order));
            return RedirectToPage("Confirmation", "OrderSubmitted");
        }
    }
}
