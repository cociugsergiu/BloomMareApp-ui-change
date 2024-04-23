using UnityEngine;

namespace BloomMare.Lessons {
    public class TargetObject : MonoBehaviour {
        [Tooltip("The point to spawn a model at")]
        [SerializeField] private Transform m_Pivot;

        public Transform pivot => m_Pivot;
    }
}