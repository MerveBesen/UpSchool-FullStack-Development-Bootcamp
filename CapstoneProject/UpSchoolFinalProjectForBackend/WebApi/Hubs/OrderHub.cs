using Domain.Entities;
using Infrastructure.Persistence.EntityFramework.Contexts;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Hubs;

public class OrderHub:Hub
{
    private readonly ApplicationDbContext _dbContext;

    public OrderHub(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    // public async Task<bool> AddAsync(Guid orderId)
    // {
    //     var order = new Order()
    //         {
    //             Name = 
    //         }
    //         
    //     _crawlerAppDbContext.Orders.AddAsync(order)
    // }
}