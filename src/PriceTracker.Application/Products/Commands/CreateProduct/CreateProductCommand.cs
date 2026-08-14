using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceTracker.Application.Products.Commands.CreateProduct
{
    public record CreateProductCommand(
        string Name, string Url, decimal InitialPrice, string Currency = "EUR") : IRequest<Guid>;
}
