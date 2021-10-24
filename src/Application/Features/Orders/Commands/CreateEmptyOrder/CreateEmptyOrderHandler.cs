using Application.Interfaces;
using Domain.Entities.OrderAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.CreateEmptyOrder
{
    public class CreateEmptyOrderHandler : IRequestHandler<CreateEmptyOrderCommand, Guid>
    {
        private readonly IOrderDbContext _dbContext;

        public CreateEmptyOrderHandler(IOrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateEmptyOrderCommand request, CancellationToken cancellationToken)
        {
            //var order = new Order()
            //{
            //    //Id = Guid.NewGuid(),
            //    // назначаем владельца сущьности
            //    //CreatedBy = Guid.Parse(request.UserId),
            //    // устанавливаем дату создания заказа, дата остается не изменна, не зависимо от статуса заказа
            //    CreatedOn = DateTimeOffset.UtcNow

            //};

            var order = new Order(request.UserId);
            

            await _dbContext.Orders.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
