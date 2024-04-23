using System;
using BloomMare.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BloomMare.UI {
    [RequireComponent(typeof(Button))]
    public class SubjectButton : MonoBehaviour {
        [SerializeField] private TMP_Text m_Title;

        private Subject m_Subject;
        private Button m_Button;
        private Action<Subject> m_OnClick;

        private void Awake() {
            m_Button = GetComponent<Button>();
            m_Button.onClick.AddListener(OnClicked);
        }

        public void Refresh(Subject subject, Action<Subject> onClick) {
            m_OnClick = onClick;
            m_Subject = subject;
            m_Title.text = subject.subjectName;
        }

        private void OnClicked() {
            m_OnClick.Invoke(m_Subject);
        }
    }
}