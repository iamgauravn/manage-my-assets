namespace manage_my_assets.Service.Interface
{
    public interface IUserMasterService
    {
        bool authUser(string email, string password);
    }
}
