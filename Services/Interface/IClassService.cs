using Entity;

namespace Services.Interface
{
    public interface IClassService : IBaseService<Class>
    {
        bool IsExistedStudent(string userName);

        Class GetByName(string name);
    }
}