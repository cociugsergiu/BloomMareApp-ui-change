using UnityEngine;
using UnityEngine.InputSystem;
using Vuforia;

namespace BloomMare.Controls {
    public class CameraFocusSetter : MonoBehaviour {
        [SerializeField] private InputActionReference m_TriggerFocus;
        [SerializeField] private InputActionReference m_FocusPoint;

        private void Update() {
            if (m_TriggerFocus.action.WasPressedThisFrame()) {
                SetFocusRegion(m_FocusPoint.action.ReadValue<Vector2>(), 0.15f);
            }
        }

        private static void SetFocusRegion(Vector2 focusPosition, float extent) {
            var regionOfInterest = new CameraRegionOfInterest(focusPosition, extent);
            if (VuforiaBehaviour.Instance.CameraDevice.FocusRegionSupported) {
                var success = VuforiaBehaviour.Instance.CameraDevice.SetFocusRegion(regionOfInterest);
                if (success) {
                    VuforiaBehaviour.Instance.CameraDevice.SetFocusMode(FocusMode.FOCUS_MODE_TRIGGERAUTO);
                }
                else {
                    Debug.Log("Failed to set Focus Mode for region " + regionOfInterest);
                }
            }
            else {
                Debug.Log("Focus region supported: " + VuforiaBehaviour.Instance.CameraDevice.FocusRegionSupported);
                VuforiaBehaviour.Instance.CameraDevice.SetFocusRegion(CameraRegionOfInterest.Default());
            }
        }
    }
}