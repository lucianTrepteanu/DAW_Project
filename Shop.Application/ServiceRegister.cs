using Shop.Application.Cart;
using Shop.Application.Data;
using Shop.Application.Orders;
using Shop.Application.UsersAdmin;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection @this)
        {
            @this.AddTransient<Shop.Application.Orders.GetOrder>();
            @this.AddTransient<GetOrders>();
            @this.AddTransient<UpdateOrder>();

            @this.AddTransient<CreateUser>();

            return @this;
        }
    }
}
