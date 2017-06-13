using TestApp.Models.Phones;

namespace TestApp.Operations.Abstraction
{
    public interface IPhonesOperations
    {
        PhonesListModel GetAll(int? sort);
        PhoneGetModel Get(int id);
        void Post(PhonePostModel model);
        void Edit(PhoneEditModel model);
        void Delete(int id);
    }
}
