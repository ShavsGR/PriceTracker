using MediatR;
using PriceTracker.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceTracker.Application.Products.Queries.GetAlertsByUser
{
    public record GetAlertsByUserQuery(Guid UserId) : IRequest<List<PriceAlertDTO>>;
}
