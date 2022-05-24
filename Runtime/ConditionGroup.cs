using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.mikeymusch.verycoolstatemachine
{
    [Serializable]
    public struct ConditionGroup
    {
        [SerializeField] List<ConditionItem> conditionItems;
        
        public ConditionGroup(List<ConditionItem> conditionItems)
        {
            this.conditionItems = conditionItems;
        }
    }
}