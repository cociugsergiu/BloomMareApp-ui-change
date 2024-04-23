using BloomMare.Data;
using UnityEngine;
using Vuforia;

namespace BloomMare.Lessons {
    public class ModelLoader : MonoBehaviour {
        [SerializeField] private VuforiaBehaviour m_VuforiaBehaviour;
        [SerializeField] private Lesson m_SelectedLesson;
        [SerializeField] private GlobalConfig m_GlobalConfig;
        [SerializeField] private GameObject m_ScanOverlay;

        private void Start() {
            var target = Instantiate(m_GlobalConfig.activeTarget);
            var lessonModel = Instantiate(m_SelectedLesson.prefab, target.pivot.position, target.pivot.rotation, target.pivot);

            m_VuforiaBehaviour.DevicePoseBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        private void OnDestroy() {
            m_VuforiaBehaviour.DevicePoseBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }

        private void OnTargetStatusChanged(ObserverBehaviour observer, TargetStatus status) {
            m_ScanOverlay.SetActive(status.StatusInfo == StatusInfo.NOT_OBSERVED);
        }
    }
}