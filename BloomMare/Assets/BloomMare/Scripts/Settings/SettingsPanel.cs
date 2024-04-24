using BloomMare.UI;
using UnityEngine;
using UnityEngine.UI;

namespace BloomMare.Settings {
    public class SettingsPanel : View {
        [SerializeField] private Toggle m_FlashToggle;
        [SerializeField] private Toggle m_FocusOnTap;

        private void Awake() {
            m_FlashToggle.isOn = Global.settings.flashToggleButton;
            m_FocusOnTap.isOn = Global.settings.focusOnTap;

            m_FlashToggle.onValueChanged.AddListener(value => { Global.settings.flashToggleButton = value; });
            m_FocusOnTap.onValueChanged.AddListener(value => { Global.settings.focusOnTap = value; });
        }
    }
}