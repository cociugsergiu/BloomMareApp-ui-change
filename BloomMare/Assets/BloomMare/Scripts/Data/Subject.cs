using UnityEngine;

namespace BloomMare.Data {
    [CreateAssetMenu(menuName = "BloomMare/Subject", fileName = "S_")]
    public class Subject : ScriptableObject {
        [SerializeField] private string m_SubjectName;

        public string subjectName => m_SubjectName;
    }
}