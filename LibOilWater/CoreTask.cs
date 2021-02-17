using System.Collections.Generic;

using LibOilWater.NastyaArrayTask;
using LibOilWater.WaterTask;

namespace LibOilWater
{
    public sealed class CoreTask
    {
#region Static Fields and Constants

        private static CoreTask coreTask;

#endregion

#region Fields

        private IRunTask<uint> _bearTask;

        private IRunTask<uint> _waterResultUintValue;

        private IRunTask<int> _nastyaTask;

#endregion

#region Constructors

        private CoreTask() { }

#endregion

#region Methods

        public static CoreTask GeCoreTask() => coreTask ??= new();

        public IRunTask<uint> GetBearTask(uint n, uint k, IList<uint> collectionValue) => _bearTask = new BearTask.BearTask(n, k, collectionValue);
        public IRunTask<uint> GeWaterTaskUintValue(IList<uint> inputEnumerable) => _waterResultUintValue = new WaterTaskUintTypeValue(inputEnumerable);

        public IRunTask<int> GetNastyaTask(int n, IList<int> collection) => _nastyaTask = new NastyaTask(n, collection);

#endregion
    }
}