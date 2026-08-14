using MediatR;
using Microsoft.EntityFrameworkCore;
using PriceTracker.Application.Common.Interfaces;
using PriceTracker.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceTracker.Application.Products.Queries.GetAlertsByUser
{
    public class GetAlertsByUserQueryHandler : IRequestHandler<GetAlertsByUserQuery,List<PriceAlertDTO>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetAlertsByUserQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PriceAlertDTO>> Handle(GetAlertsByUserQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.PriceAlerts
                .AsNoTracking()
                .Where(pa => pa.UserId == request.UserId)
                .Select(pa => new PriceAlertDTO(
                    pa.Id,
                    pa.ProductId, 
                    pa.UserId,
                    new PriceDTO(pa.TargetPrice.PriceValue,pa.TargetPrice.Currency),
                    pa.Active,
                    pa.AlertDate,
                    pa.PublishDate
                ))
                .ToListAsync(cancellationToken);
                
        }
    }
}
