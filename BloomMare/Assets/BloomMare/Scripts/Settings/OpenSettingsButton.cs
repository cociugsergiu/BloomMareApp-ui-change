using BloomMare.UI;
using UnityEngine;
using UnityEngine.UI;

namespace BloomMare.Settings {
    [RequireComponent(typeof(Button))]
    public class OpenSettingsButton : MonoBehaviour {
        private void Awake() {
            var button = GetComponent<Button>();
            button.onClick.AddListener(OnClicked);
        }

        private void OnClicked() {
            ViewManager.Show<SettingsPanel>();
        }
    }
}