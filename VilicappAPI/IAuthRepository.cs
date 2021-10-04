namespace VilicappAPI
{
    public interface IAuthRepository
    {
        bool HasPermission(string roleName);
    }
}