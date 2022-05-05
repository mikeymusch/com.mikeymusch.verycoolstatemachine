namespace com.mikeymusch.verycoolstatemachine
{
    public struct ConditionItem
    {
        public Condition Condition { get; }
        public bool ExpectedResult { get; }
        
        public ConditionItem(Condition condition, bool expectedResult)
        {
            Condition = condition;
            ExpectedResult = expectedResult;
        }
    }
}