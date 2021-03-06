using System;
using System.Threading;
using System.Threading.Tasks;
using AwesomeShop.Services.Customers.Core.Entities;
using AwesomeShop.Services.Customers.Core.Repositories;
using AwesomeShop.Services.Customers.Infrastructure.MessageBus;
using MediatR;

namespace AwesomeShop.Services.Customers.Application.Commands.Handlers
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEventProcessor _eventProcessor;
        public AddCustomerCommandHandler(ICustomerRepository repository, IEventProcessor eventProcessor)
        {
            _repository = repository;
            _eventProcessor = eventProcessor;
        }

        public async Task<Guid> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.Create(request.FullName, request.BirthDate, request.Email);

            await _repository.AddAsync(customer);

            _eventProcessor.Process(customer.Events);

            return customer.Id;
        }
    }
}