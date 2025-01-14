using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnitOfWorkTest.Data;
using UnitOfWorkTest.DesignPatternRepository.Interfaces;

namespace UnitOfWorkTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(
            ILogger<OrderController> logger,
            IUnitOfWork unitOfWork)
        {
            this._logger = logger;
            this._unitOfWork = unitOfWork;
        }

        [HttpPost("AddAsync")]
        public async Task<Order> AddAsync([FromBody] Order order)
        {
            var saved_order = await this._unitOfWork.OrderRepository.AddAsync(order);
            this._unitOfWork.Commit();
            return saved_order;
        }
    }
}