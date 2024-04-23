using UnityEngine;

namespace BloomMare.UI {
    public class View : MonoBehaviour {
        public bool isShown => gameObject.activeInHierarchy;

        public void Initialize() {
            OnInitialize();
        }

        public void Show() {
            OnBeforeShow();
            gameObject.SetActive(true);
            OnAfterShow();
        }

        public void Hide() {
            OnBeforeHide();
            gameObject.SetActive(false);
            OnAfterHide();
        }

        protected virtual void OnInitialize() { }
        protected virtual void OnBeforeShow() { }
        protected virtual void OnAfterShow() { }
        protected virtual void OnBeforeHide() { }
        protected virtual void OnAfterHide() { }
    }
}