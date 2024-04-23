using System;
using BloomMare.Data;
using UnityEngine;
using UnityEngine.UI;

namespace BloomMare.UI {
    [RequireComponent(typeof(Button))]
    public class GradeButton : MonoBehaviour {
        [SerializeField] private Image m_IconImage;

        private Grade m_Grade;
        private Button m_Button;
        private Action<Grade> m_OnClick;

        private void Awake() {
            m_Button = GetComponent<Button>();
            m_Button.onClick.AddListener(OnClicked);
        }

        public void Refresh(Grade grade, Action<Grade> onClick) {
            m_OnClick = onClick;
            m_Grade = grade;
            m_IconImage.sprite = grade.icon;
            m_IconImage.color = grade.tint;
        }

        private void OnClicked() {
            m_OnClick.Invoke(m_Grade);
        }
    }
}