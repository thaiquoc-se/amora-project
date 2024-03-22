using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Services.ViewModel.ResponseVM
{
    public class ServiceResponseVM<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public string? Title { get; set; }
        public IEnumerable<string>? Errors { get; set; }
        public T? Result { get; set; }
    }
}
