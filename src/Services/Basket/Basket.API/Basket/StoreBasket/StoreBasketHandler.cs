﻿namespace Basket.API.Basket.StoreBasketHandler;
public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
public record StoreBasketResult(string UserName);

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required");
    }
}
public class StoreBasketCommandHandler(IDocumentSession session)
    : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        var cart = command.Cart;

        //TODO: Store Basket in database (use Marten upsert - if exist = update, else create new document
        //TODO: update cache
       
        //session.Store(cart);

        //await session.SaveChangesAsync(cancellationToken);

        return new StoreBasketResult("swn");
    }
}
