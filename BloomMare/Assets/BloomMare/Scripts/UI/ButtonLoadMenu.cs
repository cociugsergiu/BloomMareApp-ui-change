using UnityEngine;
using UnityEngine.UI;

namespace BloomMare.UI {
    [RequireComponent(typeof(Button))]
    public class ButtonLoadMenu : MonoBehaviour {
        private Button m_Button;

        private void Awake() {
            m_Button = GetComponent<Button>();
            m_Button.onClick.AddListener(OnClicked);
        }

        private void OnClicked() {
            Global.LoadScene(SceneType.Menu);
        }
    }
}