using BlazorEcommerce.Server.Services.AuthService;
using Blazored.LocalStorage;

namespace BlazorEcommerce.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext _context;
        private readonly ILocalStorageService _localStorage;
        private readonly IAuthService _authService;

        public CartService(ILocalStorageService localStorage, IAuthService authService, DataContext context) 
        { 
            _localStorage = localStorage;
            _authService = authService;
            _context = context;
        }

        public event Action OnChange;

        public async Task<ServiceResponse<bool>> AddToCart(CartItem cartItem)
        {   
            cartItem.UserId = _authService.GetUserId();
            var sameItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.ProductId == cartItem.ProductId && 
                ci.ProductTypeId == cartItem.ProductTypeId && 
                ci.UserId == cartItem.UserId);
            if(sameItem == null)
            {
                _context.CartItems.Add(cartItem);
            }
            else
            {
                sameItem.Quantity += cartItem.Quantity;
            }
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };

        }

      

        public async Task<ServiceResponse<int>> GetCartItemsCount()
        {
            var count = (await _context.CartItems.Where(ci => ci.UserId == _authService.GetUserId()).ToListAsync()).Count;
            return new ServiceResponse<int> { Data = count };
        }

       


        public Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem)
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<bool>> RemoveItemFromCart(int productId, int productTypeId)
        {
            throw new NotImplementedException();
        }


        public Task<ServiceResponse<List<CartProductResponse>>> GetDbCartProducts(int? userId = null)
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceResponse<List<CartProductResponse>>> StoreCartItems(List<CartItem> cartItems)
        {
            cartItems.ForEach(cartItem => cartItem.UserId = _authService.GetUserId());
            _context.CartItems.AddRange(cartItems);
            await _context.SaveChangesAsync();

            return await GetDbCartProducts();
        }

        Task<ServiceResponse<List<CartItem>>> GetCartItems()
        {
            return null;
        }

        Task<ServiceResponse<List<CartItem>>> ICartService.GetCartItems()
        {
            throw new NotImplementedException();
        }
    }
}
