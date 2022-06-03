using System;

namespace com.mikeymusch.verycoolstatemachine
{
    internal interface IEditableTransitionTable
    {
        public void AddTransitionGroup();
        public Type GetGenericType();
    }
}