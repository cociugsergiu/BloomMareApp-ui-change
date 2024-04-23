using UnityEngine;
using UnityEngine.UI;

namespace BloomMare.UI {
    [RequireComponent(typeof(Button))]
    public class BackButton : MonoBehaviour {
        private Button m_Button;

        private void Awake() {
            m_Button = GetComponent<Button>();
            m_Button.onClick.AddListener(OnClicked);
        }

        private void OnDestroy() {
            m_Button.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked() {
            ViewManager.Back();
        }
    }
}