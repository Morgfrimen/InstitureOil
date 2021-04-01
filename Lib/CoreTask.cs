using System.Collections.Generic;

using Lib.NastyaArrayTask;
using Lib.WaterTask;

namespace Lib
{
	public static class CoreTask
	{

		#region Methods

		public static IRunTask<uint> GetBearTask(uint n, uint k, IList<uint> collectionValue) => new BearTask.BearTask(n, k, collectionValue);

		public static IRunTask<int> GetNastyaTask(int n, IList<int> collection) => new NastyaTask(n, collection);
		public static IRunTask<uint> GetWaterTaskUintValue(IList<uint> inputEnumerable) => new WaterTaskUintTypeValue(inputEnumerable);

		#endregion
	}
}