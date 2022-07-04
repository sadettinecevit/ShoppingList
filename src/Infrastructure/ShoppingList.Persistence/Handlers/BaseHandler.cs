using ShoppingList.Application.Interfaces.UnitOfWork;

namespace ShoppingList.Persistence.Handlers
{
    public abstract class BaseHandler
    {
        public readonly IUnitOfWorkService _unitOfWork;
        public BaseHandler(IUnitOfWorkService unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
