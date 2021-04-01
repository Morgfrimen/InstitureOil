using System.Collections.Generic;

namespace Lib
{
    public interface IInputCollection<TInput> where TInput : struct
    {
#region Properties

        IList<TInput> InputValue { get; }

#endregion
    }
}