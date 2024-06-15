
using Basket.API.Basket.StoreBasketHandler;

namespace Basket.API.Basket.StoreBasketEndpoints;
public record StoreBasketRequest(ShoppingCart Cart);
public record StoreBasketResponse(string UserName);
public class StoreBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async(StoreBasketRequest request, ISender sender) =>
        {
            var basket = request.Adapt<StoreBasketCommand>();
            
            var result = await sender.Send(basket);
            
            var response = result.Adapt<StoreBasketResponse>();

            return Results.Ok(response);
        })
        .WithName("StoreBasket")
        .Produces<StoreBasketResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Store Basket")
        .WithDescription("Store Basket");
    }
}
