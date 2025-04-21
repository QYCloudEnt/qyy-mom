namespace TMom.Infrastructure.Helper
{
    public class ReflectionHelper
    {
        public static async Task<T> GetInvokeMethodResultAsync<T>(Task<T> actualReturnValue, Func<object, Task> func, Action<Exception> finalAction)
        {
            Exception exception = null;
            try
            {
                var result = await actualReturnValue;
                await func(result);
                return result;
            }
            catch (Exception ex)
            {
                exception = ex;
                throw;
            }
            finally
            {
                finalAction(exception);
            }
        }
    }
}