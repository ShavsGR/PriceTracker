using MediatR;
using Microsoft.EntityFrameworkCore;
using PriceTracker.Application.Common.Interfaces;
using PriceTracker.Application.DTOs;

namespace PriceTracker.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDTO?>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetProductByIdQueryHandler(IApplicationDbContext context)
        {
             _dbContext = context;
        }

        public async Task<ProductDTO?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Products
                .AsNoTracking()
                .Where(p => p.Id == request.Id)
                .Select(p => new ProductDTO(
                    p.Id, 
                    p.Name, 
                    p.ProductURL, 
                    new PriceDTO(p.CurrentPrice.PriceValue, p.CurrentPrice.Currency), 
                    p.PublishDateTime, 
                    p.LastUpdate
                 ))
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
