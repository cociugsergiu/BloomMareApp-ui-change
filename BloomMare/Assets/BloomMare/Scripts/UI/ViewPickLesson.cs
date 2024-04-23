using System.Collections.Generic;
using BloomMare.Data;
using UnityEngine;

namespace BloomMare.UI {
    public class ViewPickLesson : View {
        [SerializeField] private Transform m_Container;

        private readonly List<LessonButton> m_Buttons = new();

        protected override void OnBeforeShow() {
            var buttonPrefab = Global.config.lessonButtonPrefab;

            var index = 1;
            foreach (var lesson in Global.GetLessonsForGradeAndSubject(Global.selectedGrade, Global.selectedSubject)) {
                var lessonButton = Instantiate(buttonPrefab, m_Container);
                lessonButton.Refresh(lesson, index, OnPickLesson);
                m_Buttons.Add(lessonButton);
                index++;
            }
        }

        protected override void OnAfterHide() {
            foreach (var gradeButton in m_Buttons) {
                Destroy(gradeButton.gameObject);
            }

            m_Buttons.Clear();
        }

        private void OnPickLesson(Lesson lesson) {
            Global.SelectLesson(lesson);
            Global.LoadScene(SceneType.Scan);
        }
    }
}