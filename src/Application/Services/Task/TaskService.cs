using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Task
{
    public class TaskService : ITaskService
    {
        private readonly ICatalogContext _catalogContext;

        public TaskService(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public Task<int> CreateAsync(TaskRequestDto taskRequest)
        {
            
            throw new NotImplementedException();
        }
    }
}
