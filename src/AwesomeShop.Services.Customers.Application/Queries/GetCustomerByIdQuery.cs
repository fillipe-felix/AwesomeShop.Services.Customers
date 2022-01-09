using System;
using AwesomeShop.Services.Customers.Application.View_Models;
using MediatR;

namespace AwesomeShop.Services.Customers.Application.Queries
{
    public class GetCustomerByIdQuery : IRequest<GetCustomerByIdViewModel>
    {
        public GetCustomerByIdQuery(Guid id)
        {
            Id = id;
        }
        
        public Guid Id { get; private set; }
    }
}