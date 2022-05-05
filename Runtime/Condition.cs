using UnityEngine;

namespace com.mikeymusch.verycoolstatemachine
{
    public abstract class Condition : ScriptableObject
    {
        public abstract bool Statement();
    }
}