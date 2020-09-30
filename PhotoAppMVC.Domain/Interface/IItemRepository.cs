using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhotoAppMVC.Domain.Model;


namespace PhotoAppMVC.Domain.Interface
{
    public interface IItemRepository
    {
        void DeleteItem(int itemId);

        int AddItem(Item item);


        IQueryable<Item> GetItemByTypeId(int typeId);


        Item GetItemById(int itemId);


        IQueryable<Tag> GetAllTags();

        IQueryable<Type> GetAllTypes();

    }
}
