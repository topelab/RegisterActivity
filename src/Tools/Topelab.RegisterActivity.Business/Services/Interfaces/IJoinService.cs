namespace Topelab.RegisterActivity.Business.Services.Interfaces
{
    public interface IJoinService
    {
        void Start(string filePattern, string outputFile, bool create);
    }
}