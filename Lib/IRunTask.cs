namespace Lib
{
    public interface IRunTask<T> where T : struct
    {
#region Methods

        public T Run();

#endregion
    }
}