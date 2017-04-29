namespace FilteringV10
{
    public interface IFilterCondition
    {
        bool Condition(int value);
    }
}