using UnityEngine;

namespace BloomMare.Lessons {
    public class ModelLoader : MonoBehaviour {
        [SerializeField] private GameObject m_ScanOverlay;

        private void Start() {
            var target = Instantiate(Global.config.activeTarget);
            Instantiate(Global.selectedLesson.prefab, target.pivot.position, target.pivot.rotation, target.pivot);

            target.TargetFound += OnTargetFound;
            target.TargetLost += OnTargetLost;
        }

        private void OnTargetFound() {
            m_ScanOverlay.SetActive(false);
        }

        private void OnTargetLost() {
            m_ScanOverlay.SetActive(true);
        }
    }
}