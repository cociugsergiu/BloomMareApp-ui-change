using System.Collections.Generic;
using UnityEngine;

namespace BloomMare.UI {
    public class ViewManager : MonoBehaviour {
        [SerializeField] private View m_StartView;

        private static View[] m_Views;
        private static readonly Stack<View> HISTORY = new();

        private void Start() {
            m_Views = FindObjectsOfType<View>(true);

            foreach (var view in m_Views) {
                view.Initialize();
                view.Hide();
            }

            Show<ViewPickGrade>();

            if (Global.selectedSubject != null) {
                Show<ViewPickSubject>();
            }

            if (Global.selectedLesson != null) {
                Show<ViewPickLesson>();
            }
        }

        private void OnDestroy() {
            m_Views = null;
            HISTORY.Clear();
        }

        public static void Show(View view) {
            if (HISTORY.TryPeek(out var viewToHide)) {
                viewToHide.Hide();
            }

            view.Show();
            HISTORY.Push(view);
        }

        public static void Show<T>() where T : View {
            foreach (var view in m_Views) {
                if (view.GetType() == typeof(T)) {
                    Show(view);
                    return;
                }
            }
        }

        public static void Back() {
            if (HISTORY.TryPop(out var viewToHide)) {
                viewToHide.Hide();
            }

            if (HISTORY.TryPeek(out var viewToShow)) {
                viewToShow.Show();
            }
        }
    }
}