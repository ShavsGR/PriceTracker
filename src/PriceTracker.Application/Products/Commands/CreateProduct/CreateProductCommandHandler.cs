using MediatR;
using PriceTracker.Application.Common.Interfaces;
using PriceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceTracker.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand,Guid>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var price = new Price(request.InitialPrice, request.Currency);
            var product = new Product(request.Name,request.Url,price);

            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
