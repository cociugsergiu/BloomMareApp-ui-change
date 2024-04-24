using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using Image = UnityEngine.UI.Image;

namespace BloomMare.Controls {
    [RequireComponent(typeof(Button))]
    public class FlashlightSwitcher : MonoBehaviour {
        [SerializeField] private Image m_Icon;
        [SerializeField] private Sprite m_On;
        [SerializeField] private Sprite m_Off;

        private bool isOn { get; set; }

        private void Awake() {
            if (!Global.settings.flashToggleButton) {
                gameObject.SetActive(false);
                return;
            }

            var button = GetComponent<Button>();
            button.onClick.AddListener(ToggleFlashlight);
        }

        private void Start() {
            isOn = VuforiaBehaviour.Instance.CameraDevice.Flash;
            m_Icon.sprite = isOn ? m_On : m_Off;
        }

        private void ToggleFlashlight() {
            isOn = !isOn;
            VuforiaBehaviour.Instance.CameraDevice.SetFlash(isOn);
            m_Icon.sprite = isOn ? m_On : m_Off;
        }
    }
}