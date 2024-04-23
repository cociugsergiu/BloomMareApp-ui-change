using System.Collections.Generic;
using BloomMare.Data;
using UnityEngine;

namespace BloomMare.UI {
    public class ViewPickGrade : View {
        [SerializeField] private Transform m_Container;

        private readonly List<GradeButton> m_Buttons = new();

        protected override void OnBeforeShow() {
            var buttonPrefab = Global.config.gradeButtonPrefab;

            foreach (var grade in Global.GetAllGrades()) {
                var gradeButton = Instantiate(buttonPrefab, m_Container);
                gradeButton.Refresh(grade, OnPickGrade);
                m_Buttons.Add(gradeButton);
            }
        }

        protected override void OnAfterHide() {
            foreach (var gradeButton in m_Buttons) {
                Destroy(gradeButton);
            }

            m_Buttons.Clear();
        }

        private void OnPickGrade(Grade grade) {
            Global.SelectGrade(grade);
            ViewManager.Show<ViewPickSubject>();
        }
    }
}