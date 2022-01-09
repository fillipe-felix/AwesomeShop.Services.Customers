using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.Services.Customers.Core.Repositories;
using AwesomeShop.Services.Customers.Core.ValueObjects;
using MediatR;

namespace AwesomeShop.Services.Customers.Application.Commands.Handlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);

            customer.Update(request.PhoneNumber, request.Address.ToEntity());

            await _customerRepository.UpdateAsync(customer);

            return Unit.Value;
        }
    }
}