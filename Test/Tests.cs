using System;

using LibOilWater;

using NUnit.Framework;

namespace Test
{
    public class Tests
    {
#region Methods

        [Test]
        public void Test_BearTask()
        {
            uint[] array = {4, 2, 3, 1, 5, 1, 6, 4};
            uint n = (uint) array.Length;
            IRunTask<uint> bear = CoreTask.GeCoreTask().GetBearTask(n, 4, new uint[] {4, 2, 3, 1, 5, 1, 6, 4});
            uint resultBearTask = bear.Run();
            Assert.AreEqual(resultBearTask, 5);
            CollectionAssert.AreEqual((bear as IInputCollection<uint>).InputValue, array);
            Assert.AreEqual((bear as IResult<uint>).ResultCollection, resultBearTask);
            array = new uint[] {3, 1, 2, 1, 3};
            n = (uint) array.Length;
            bear = CoreTask.GeCoreTask().GetBearTask(n, 2, array);
            resultBearTask = bear.Run();
            Assert.AreEqual(resultBearTask, 0);
            CollectionAssert.AreEqual((bear as IInputCollection<uint>).InputValue, array);
            Assert.AreEqual((bear as IResult<uint>).ResultCollection, resultBearTask);
            array = new uint[] {12, 34, 55, 43, 21};
            n = (uint) array.Length;
            bear = CoreTask.GeCoreTask().GetBearTask(n, 100, array);
            resultBearTask = bear.Run();
            Assert.AreEqual(resultBearTask, 5);
            CollectionAssert.AreEqual((bear as IInputCollection<uint>).InputValue, array);
            Assert.AreEqual((bear as IResult<uint>).ResultCollection, resultBearTask);
            array = new uint[] {12, 34, 55, 43, 21};
            n = 2;
            Assert.Throws<IndexOutOfRangeException>(() => CoreTask.GeCoreTask().GetBearTask(n, 100, array));
            array = new uint[] {12, 34, 55, 43, 21};
            n = (uint) array.Length;
            uint k = 101;
            Assert.Throws<ArgumentException>(() => CoreTask.GeCoreTask().GetBearTask(n, k, array));
            array = new uint[] {12, 34, 55, 43, 21};
            n = 0;
            k = 10;
            Assert.Throws<ArgumentException>(() => CoreTask.GeCoreTask().GetBearTask(n, k, array));
            array = null;
            n = 1;
            k = 10;
            Assert.Throws<NullReferenceException>(() => CoreTask.GeCoreTask().GetBearTask(n, k, array));
        }

        [Test]
        public void Test_NastyaTask()
        {
            IRunTask<int> nastyaTask = CoreTask.GeCoreTask().GetNastyaTask(5, new[] {1, 1, 1, 1, 1});
            int resultNastyaTask = nastyaTask.Run();
            Assert.AreEqual(resultNastyaTask, 1);
            nastyaTask = CoreTask.GeCoreTask().GetNastyaTask(3, new[] {2, 0, -1});
            resultNastyaTask = nastyaTask.Run();
            Assert.AreEqual(resultNastyaTask, 2);
            nastyaTask = CoreTask.GeCoreTask().GetNastyaTask(4, new[] {5, -6, -5, 1});
            resultNastyaTask = nastyaTask.Run();
            Assert.AreEqual(resultNastyaTask, 4);
            nastyaTask = CoreTask.GeCoreTask().GetNastyaTask(0, new int[] { });
            resultNastyaTask = nastyaTask.Run();
            Assert.AreEqual(resultNastyaTask, 0);
            Assert.Throws<ArgumentNullException>(() => CoreTask.GeCoreTask().GetNastyaTask(3, null));
            Assert.Throws<IndexOutOfRangeException>(() => CoreTask.GeCoreTask().GetNastyaTask(1, new[] {5, -6, -5, 1}));
        }

        [Test]
        public void Test_Water()
        {
            IRunTask<uint> water = CoreTask.GeCoreTask().GeWaterTaskUintValue(new uint[] {2, 5, 1, 2, 3, 4, 7, 7, 6});
            uint square = water.Run();
            Assert.AreEqual(square, 10);
            CollectionAssert.AreEqual((water as IInputCollection<uint>).InputValue, new uint[] {2, 5, 1, 2, 3, 4, 7, 7, 6});
            Assert.AreEqual((water as IResult<uint>).ResultCollection, square);
            water = CoreTask.GeCoreTask().GeWaterTaskUintValue(new uint[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1});
            square = water.Run();
            Assert.AreEqual(square, 0);
            water = CoreTask.GeCoreTask().GeWaterTaskUintValue(null);
            Assert.Throws<Exception>(() => water.Run());
            water = CoreTask.GeCoreTask().GeWaterTaskUintValue(new uint[] { });
            Assert.Throws<Exception>(() => water.Run());
            water = CoreTask.GeCoreTask().GeWaterTaskUintValue(new uint[] {0, 0, 0, 0, 0, 0});
            Assert.Throws<Exception>(() => water.Run());
        }

#endregion
    }
}