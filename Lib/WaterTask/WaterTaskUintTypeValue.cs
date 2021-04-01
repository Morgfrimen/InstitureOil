using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib.WaterTask
{
    internal sealed class WaterTaskUintTypeValue : IRunTask<uint>, IResult<uint>, IInputCollection<uint>
    {
#region Fields

        private readonly Dictionary<uint, Range> _dictionaryBorderPuddle;

#endregion

#region Constructors

        public WaterTaskUintTypeValue(IList<uint> inputValue)
        {
            InputValue = inputValue;
            _dictionaryBorderPuddle ??= new();
        }

#endregion

#region Properties

        public IList<uint> InputValue { get; }
        public uint ResultCollection { get; private set; }

#endregion

#region Methods

        /// <summary>
        ///     Метод, кторый находит "лужу"
        /// </summary>
        /// <returns>true- если всё прошло без ошибок, false - если произошла ошибка</returns>
        private void FindFirstPuddle(uint index = default)
        {
            if (InputValue is null || InputValue.Count is default(int))
                throw new Exception("Колеекция не может быть Null");

            List<uint> list = InputValue.ToList(); //Работая с IEnumerable - производится пересчет, поэтому в данном случае лучше привести к List и работать со списком
            uint leftBorder = list.First();
            Range range = default;

            foreach (uint value in InputValue)
            {
                if (value < leftBorder)
                {
                    int indexLeftBorderValue = list.FindIndex(0, item => item == leftBorder);
                    int indexRightBorder = list.FindIndex(indexLeftBorderValue + 1, item => item >= leftBorder);
                    range = new(indexLeftBorderValue + 1, indexRightBorder);

                    break;
                }

                leftBorder = value;
            }

            if (leftBorder != default)
                _dictionaryBorderPuddle.Add(index, range);
            else
                throw new Exception("Левый border == default");
        }

        public uint Run()
        {
            FindFirstPuddle();
            SquareWater();

            return ResultCollection;
        }

        private void SquareWater(uint index = default)
        {
            uint[] array = InputValue.ToArray()[_dictionaryBorderPuddle[index]];
            int min = _dictionaryBorderPuddle[index].Start.Value - 1 < default(int) ? 0 : _dictionaryBorderPuddle[index].Start.Value - 1;
            uint minValueInputCollection = InputValue.ToArray()[min];
            uint sumResult = default;
            foreach (uint value in array)
                sumResult += minValueInputCollection - value;
            ResultCollection = sumResult;
        }

#endregion
    }
}