using ProjectStomatology.Models;

namespace ProjectStomatology.Repository.InterfaceRepository
{
    public interface JdiseaseHistory<T>
    {
        IEnumerable<T> GetAll();
        Task<T> Details(int id);
        Task<T> Delete(int id);
        T Edit(int id);
        void Create(JdiseaseHistory rclient);
    }
}
