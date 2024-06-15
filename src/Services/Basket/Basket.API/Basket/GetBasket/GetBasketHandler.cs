namespace Basket.API.Basket.GetBasket;

public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;
public record GetBasketResult(ShoppingCart Cart);

public class GetBasketQueryHandler(IDocumentSession session)
    : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        //var basket = await session.LoadAsync<ShoppingCart>(request.UserName, cancellationToken);

        //if (basket is null)
        //{
        //    //return BasketNotFoundException();
        //}
        return new GetBasketResult(new ShoppingCart("swn"));
    }
}
