using BlazorEcommerce.Client.Services.AuthService;
using BlazorEcommerce.Shared;
using Blazored.LocalStorage;

namespace BlazorEcommerce.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;
        private readonly IAuthService _authService;

        public CartService(ILocalStorageService localStorage, HttpClient http, IAuthService authService)
        {
            _localStorage = localStorage;
            _http = http;
            _authService = authService;
        }   

        public event Action OnChange;

        public async Task AddToCart(CartItem cartItem)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if(cart == null)
            {
                cart = new List<CartItem>();
            }
            var sameItem = cart.Find(x => x.ProductId == cartItem.ProductId && x.ProductTypeId == cartItem.ProductTypeId);
            if (sameItem == null)
            {
                cart.Add(cartItem);
            }
            else
            {
                sameItem.Quantity += cartItem.Quantity;
            }
            await _localStorage.SetItemAsync("cart", cart);
            await GetCartItemsCount();
        }

        public async Task GetCartItemsCount()
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            await _localStorage.SetItemAsync<int>("cartItemsCount", cart != null ? cart.Count : 0);
        }

        public Task<List<CartItem>> GetCartProducts()
        {
            throw new NotImplementedException();
        }

        public Task RemoveProductFromCart(int productId, int productTypeId)
        {
            throw new NotImplementedException();
        }

        public Task StoreCartItems(bool emptyLOcalCart)
        {
            throw new NotImplementedException();
        }

        public Task UpdateQuantity(int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
