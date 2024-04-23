using System;
using UnityEngine;

namespace BloomMare.Lessons {
    public class TargetObject : MonoBehaviour {
        public event Action TargetFound;
        public event Action TargetLost;

        [Tooltip("The point to spawn a model at")]
        [SerializeField] private Transform m_Pivot;
        [SerializeField] private DefaultObserverEventHandler m_ObserverEventHandler;

        public Transform pivot => m_Pivot;

        private void Awake() {
            m_ObserverEventHandler.OnTargetFound.AddListener(OnTargetFound);
            m_ObserverEventHandler.OnTargetLost.AddListener(OnTargetLost);
        }

        private void OnDestroy() {
            m_ObserverEventHandler.OnTargetFound.RemoveListener(OnTargetFound);
            m_ObserverEventHandler.OnTargetLost.RemoveListener(OnTargetLost);
        }

        private void OnTargetFound() {
            TargetFound?.Invoke();
        }

        private void OnTargetLost() {
            TargetLost?.Invoke();
        }
    }
}