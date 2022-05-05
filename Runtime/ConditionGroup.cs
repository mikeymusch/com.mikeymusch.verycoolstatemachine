using System.Collections.Generic;

namespace com.mikeymusch.verycoolstatemachine
{
    public struct ConditionGroup
    {
        public List<ConditionItem> ConditionItems { get; }

        public ConditionGroup(List<ConditionItem> conditions)
        {
            ConditionItems = conditions;
        }
    }
}