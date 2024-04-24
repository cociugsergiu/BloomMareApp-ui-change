using UnityEngine;

namespace BloomMare.Data {
    [CreateAssetMenu(menuName = "BloomMare/Subject", fileName = "S_")]
    public class Subject : ScriptableObject {
        [SerializeField] private string m_SubjectName;
        [SerializeField] private Sprite m_Icon;

        public string subjectName => m_SubjectName;
        public Sprite icon => m_Icon;
    }
}