using Topelab.RegisterActivity.Business.Enums;

namespace Topelab.RegisterActivity.Business.Services.Interfaces
{
    public interface ISplitService
    {
        void Start(string inputFile, string outputFile, SplitType splitType);
    }
}