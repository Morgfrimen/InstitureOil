namespace LibOilWater
{
    public interface IResult<T> where T : struct
    {
#region Properties

        T ResultCollection { get; }

#endregion
    }
}