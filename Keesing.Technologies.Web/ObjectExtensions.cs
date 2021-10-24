using System.Threading.Tasks;

namespace Keesing.Technologies.Web
{
    public static class ObjectExtensions
    {
        public static Task<T> AsTask<T>(this T @object)
        {
            return Task.FromResult(@object);
        }
    }
}