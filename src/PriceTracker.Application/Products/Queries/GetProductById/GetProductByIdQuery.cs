using MediatR;
using PriceTracker.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceTracker.Application.Products.Queries.GetProductById
{
    public record GetProductByIdQuery(Guid Id): IRequest<ProductDTO?>;
}
