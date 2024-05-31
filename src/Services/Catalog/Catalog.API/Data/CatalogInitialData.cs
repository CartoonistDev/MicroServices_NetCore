﻿namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
            return;

        //Marten UPSERT will cater for existing records
        session.Store<Product>(GetPreconfiguredProducts());

        await session.SaveChangesAsync();

    }

    private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
    {
        new Product()
        {
            Id = new Guid("018fc847-db2d-489e-952c-519f5a95b7d3"),
            Name = "IPhone XR",
            Description = "This phone is the company's biggest change to it's first line products",
            ImageFile = "product-1.png",
            Price = 1020.00M,
            Category = new List<string>{"Smart Phone"}
        },
        new Product()
        {
            Id = new Guid("018fc847-db4d-489e-952c-519f5a95b7d4"),
            Name = "Samsung Note 10",
            Description = "This phone is the company's biggest change to it's first line products",
            ImageFile = "product-2.png",
            Price = 950.00M,
            Category = new List<string>{"Smart Phone"}
        },
        new Product()
        {
            Id = new Guid("018fc847-db6d-489e-952c-519f5a95b7d5"),
            Name = "Tecno Pop 5",
            Description = "This phone is the company's biggest change to it's first line products",
            ImageFile = "product-3.png",
            Price = 450.00M,
            Category = new List<string>{"Smart Phone"}
        },
        new Product()
        {
            Id = new Guid("018fc847-db2d-489e-952d-519f5a95b7d6"),
            Name = "Infinix Zero 3",
            Description = "This phone is the company's biggest change to it's first line products",
            ImageFile = "product-4.png",
            Price = 450.00M,
            Category = new List<string>{"Smart Phone"}
        },
        new Product()
        {
            Id = new Guid("018fc847-db2d-489e-992c-519f5a95b7d7"),
            Name = "Huwai Plus",
            Description = "This phone is the company's biggest change to it's first line products",
            ImageFile = "product-5.png",
            Price = 750.00M,
            Category = new List<string>{"Smart Phone"}
        },
        new Product()
        {
            Id = new Guid("018fc847-db2d-489e-952c-519f8a95b7d8"),
            Name = "LG G7 ThinQ",
            Description = "This phone is the company's biggest change to it's first line products",
            ImageFile = "product-6.png",
            Price = 450.00M,
            Category = new List<string>{"Home Kitchen"}
        },
        new Product()
        {
            Id = new Guid("018fc847-db2d-189e-952c-519f5a95b7d9"),
            Name = "Panasonic Lumix",
            Description = "This phone is the company's biggest change to it's first line products",
            ImageFile = "product-7.png",
            Price = 450.00M,
            Category = new List<string>{"Camera"}
        }
    };
}
