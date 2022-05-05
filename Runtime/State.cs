using UnityEngine;

namespace com.mikeymusch.verycoolstatemachine
{
    [CreateAssetMenu(fileName = "State", menuName = "State")]
    public class State : ScriptableObject
    {
        public void OnEnter()
        {
            Debug.Log($"Entering {name}");
        }

        public void OnUpdate()
        {
        }

        public void OnExit()
        {
            Debug.Log($"Leaving {name}");
        }
    }
}