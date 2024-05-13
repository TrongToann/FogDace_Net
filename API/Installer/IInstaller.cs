namespace API.Installer
{
    public interface IInstaller
    {
        void InstallService(IServiceCollection service, IConfiguration configuration);

    }
}
