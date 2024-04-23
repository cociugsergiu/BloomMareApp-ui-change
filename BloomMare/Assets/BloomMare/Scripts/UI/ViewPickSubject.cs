using System.Collections.Generic;
using BloomMare.Data;
using UnityEngine;

namespace BloomMare.UI {
    public class ViewPickSubject : View {
        [SerializeField] private Transform m_Container;

        private readonly List<SubjectButton> m_Buttons = new();

        protected override void OnBeforeShow() {
            var buttonPrefab = Global.config.subjectButtonPrefab;

            foreach (var grade in Global.GetSubjectsForGrade(Global.selectedGrade)) {
                var subjectButton = Instantiate(buttonPrefab, m_Container);
                subjectButton.Refresh(grade, OnPickSubject);
                m_Buttons.Add(subjectButton);
            }
        }

        protected override void OnAfterHide() {
            foreach (var gradeButton in m_Buttons) {
                Destroy(gradeButton);
            }

            m_Buttons.Clear();
        }

        private void OnPickSubject(Subject subject) {
            Global.SelectSubject(subject);
            ViewManager.Show<ViewPickLesson>();
        }
    }
}