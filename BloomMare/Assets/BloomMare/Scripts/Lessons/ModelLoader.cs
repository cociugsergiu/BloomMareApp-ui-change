using BloomMare.Data;
using UnityEngine;

namespace BloomMare.Lessons {
    public class ModelLoader : MonoBehaviour {
        [SerializeField] private Lesson m_SelectedLesson;
        [SerializeField] private GlobalConfig m_GlobalConfig;

        private void Start() {
            var target = Instantiate(m_GlobalConfig.activeTarget);
            var lessonModel = Instantiate(m_SelectedLesson.prefab, target.pivot.position, target.pivot.rotation, target.pivot);
        }
    }
}