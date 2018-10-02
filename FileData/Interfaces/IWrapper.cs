//Wrapper interface for 3rd party tool
namespace FileData
{
    public interface IWrapper
    {
        T Action<T>(string actionParameter, string filename);
    }
}
