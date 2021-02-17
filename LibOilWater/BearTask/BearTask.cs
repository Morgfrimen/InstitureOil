using System;
using System.Collections.Generic;

namespace LibOilWater.BearTask
{
    internal sealed class BearTask : IRunTask<uint>, IResult<uint>, IInputCollection<uint>
    {
#region Fields

        private readonly uint _k;
        private readonly uint _n;

#endregion

#region Constructors

        internal BearTask(uint n, uint k, IList<uint> collectionTaskBear)
        {
            ValidateData(n, k, collectionTaskBear);
            _n = n;
            _k = k;
            InputValue = collectionTaskBear;
        }

#endregion

#region Properties

        public IList<uint> InputValue { get; }

        public uint ResultCollection { get; private set; }

#endregion

#region Methods

        private void EnumerationTaskAndRunTask()
        {
            int indexEnd = default;
            bool isLeft = true;

            for (int index = 0; index < _n; index++)
            {
                uint a;

                if (isLeft)
                {
                    a = InputValue[index];
                }
                else
                {
                    indexEnd++;
                    a = InputValue[^indexEnd];
                }

                if (a > _k && isLeft)
                {
                    indexEnd++;
                    a = InputValue[^indexEnd];
                    isLeft = false;

                    if (a > _k)
                        return;
                }

                if (a > _k)
                    return;

                RunTask();
            }

            void RunTask() => ResultCollection++;
        }

        public uint Run()
        {
            EnumerationTaskAndRunTask();

            return ResultCollection;
        }

        private void ValidateData(uint n, uint k, IList<uint> collectionTaskBear)
        {
            if (collectionTaskBear is null)
                throw new NullReferenceException("Значение массива не может быть NULL");
            if (n < 1)
                throw new ArgumentException("Значение n должно быть больше 1");
            if (k is > 100)
                throw new ArgumentException("Значение k должно быть в диапозоне от 0 до 100");
            if (n != collectionTaskBear.Count)
                throw new IndexOutOfRangeException("Значение n должно быть равно количеству элементов в массиве");
        }

#endregion
    }
}