using MediatR;
using PriceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceTracker.Application.Products.Commands.CreateAlert
{
    public  record CreateAlertCommand(
        Guid Id, Guid ProductId, Guid UserId, decimal TargetPrice,string Currency = "EUR" ) : IRequest<Guid>;
}
