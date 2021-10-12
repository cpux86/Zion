using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Task
{
    public interface ITaskService
    {
        Task<int> CreateAsync(TaskRequestDto taskRequest);
    }
}
