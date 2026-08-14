using MediatR;
using Microsoft.EntityFrameworkCore;
using PriceTracker.Application.Common.Interfaces;
using PriceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceTracker.Application.Products.Commands.CreateAlert
{
    public class CreateAlertCommandHandler : IRequestHandler<CreateAlertCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateAlertCommandHandler(IApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Guid> Handle(CreateAlertCommand request, CancellationToken cancellationToken)
        {
            var productExist = await _dbContext.Products.AnyAsync(p => p.Id == request.ProductId,cancellationToken);

            if (!productExist)
            {
                throw new KeyNotFoundException($"Product with ID {request.ProductId} doesn't exist");
            }

            var targetPrice = new Price(request.TargetPrice, request.Currency);
            var priceAlert = new PriceAlert(request.ProductId, request.UserId, targetPrice);

            _dbContext.PriceAlerts.Add(priceAlert);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return priceAlert.Id;
        }
    }
}
