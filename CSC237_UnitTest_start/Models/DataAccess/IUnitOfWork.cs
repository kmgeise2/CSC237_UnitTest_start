
namespace CSC237_UnitTest_start.Models
{
    public interface IUnitOfWork
    {
        IRepository<Contact> Contacts { get; }
        IRepository<Category> Categories { get; }

        void Save();
    }
}
