using System;
using BloomMare.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BloomMare.UI {
    [RequireComponent(typeof(Button))]
    public class LessonButton : MonoBehaviour {
        [SerializeField] private TMP_Text m_Title;
        [SerializeField] private Image m_Icon;

        private Lesson m_Lesson;
        private Button m_Button;
        private Action<Lesson> m_OnClick;

        private void Awake() {
            m_Button = GetComponent<Button>();
            m_Button.onClick.AddListener(OnClicked);
        }

        public void Refresh(Lesson lesson, Action<Lesson> onClick) {
            m_OnClick = onClick;
            m_Lesson = lesson;
            m_Title.text = lesson.title;
            m_Icon.sprite = lesson.icon;
        }

        private void OnClicked() {
            m_OnClick.Invoke(m_Lesson);
        }
    }
}