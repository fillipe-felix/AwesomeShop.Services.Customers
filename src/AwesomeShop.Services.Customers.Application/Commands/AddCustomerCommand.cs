using System;
using MediatR;

namespace AwesomeShop.Services.Customers.Application.Commands
{
    public class AddCustomerCommand : IRequest<Guid>
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }
}