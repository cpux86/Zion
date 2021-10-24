using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Threading;
using Domain.Entities.OrderAggregate;
using AutoMapper;

namespace Application.Features.Orders.Commands.EditOrder
{
    public class EditOrderCommandHandler : IRequestHandler<EditOrderCommand, bool>
    {
        private readonly IOrderDbContext _dbContext;

        public EditOrderCommandHandler(IOrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(EditOrderCommand request, CancellationToken cancellationToken)
        {
            // Если запрошанный заказ имеется в БД, то получаем его для заполнения
            Order order = _dbContext.Orders.Where(o => o.Id.ToString() == request.OrderId).FirstOrDefault();
            if (order==null)
            {
                return false;
            }
            order.Title = request.Title;
            order.Comments = request.Comments;
            order.ImageSource = request.ImageSource;
            order.ModifiedOn = DateTime.UtcNow;

            

            //await _dbContext.Orders.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
