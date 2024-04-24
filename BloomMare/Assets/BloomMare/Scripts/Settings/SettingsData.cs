using System;

namespace BloomMare.Settings {
    [Serializable]
    public class SettingsData : ICloneable {
        public bool flashToggleButton;
        public bool focusOnTap;

        public SettingsData() { }

        public SettingsData(SettingsData original) {
            flashToggleButton = original.flashToggleButton;
            focusOnTap = original.flashToggleButton;
        }

        public object Clone() {
            return new SettingsData(this);
        }
    }
}