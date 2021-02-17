using System;
using System.Collections.Generic;
using System.Linq;

namespace LibOilWater.NastyaArrayTask
{
    internal sealed class NastyaTask : IRunTask<int>, IResult<int>, IInputCollection<int>
    {
#region Constructors

        internal NastyaTask(int n,IList<int> collection)
        {
            Validate(n,collection);
            InputValue = collection;
        }

        private void Validate(int n, IList<int> collection)
        {
            if (collection is null)
                throw new ArgumentNullException("Массив не должен быть Null");
            if (collection.Count != n)
                throw new IndexOutOfRangeException("Значение n должно соответсвовать размерности массива");
            
        }

#endregion

#region Properties

        public IList<int> InputValue { get; }

        public int ResultCollection { get; private set; }

#endregion

#region Methods

        private void GetTimeIntArrayWork()
        {
            ResultCollection = InputValue.Distinct().Count(item => item != 0);
        }

        public int Run()
        {
            GetTimeIntArrayWork();

            return ResultCollection;
        }

#endregion
    }
}