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

        private bool isOn => VuforiaBehaviour.Instance.CameraDevice.Flash;

        private void Awake() {
            var button = GetComponent<Button>();
            button.onClick.AddListener(ToggleFlashlight);
        }

        private void Start() {
            m_Icon.sprite = isOn ? m_On : m_Off;
        }

        private void ToggleFlashlight() {
            var wasEnabled = VuforiaBehaviour.Instance.CameraDevice.SetFlash(!isOn);
            m_Icon.sprite = wasEnabled ? m_On : m_Off;
        }
    }
}