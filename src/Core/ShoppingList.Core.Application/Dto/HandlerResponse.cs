using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Application.Dto
{
    public class HandlerResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
    }
}
