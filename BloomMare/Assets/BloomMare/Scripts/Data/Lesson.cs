using UnityEngine;

namespace BloomMare.Data {
    [CreateAssetMenu(menuName = "BloomMare/Lesson", fileName = "L_")]
    public class Lesson : ScriptableObject {
        [SerializeField] private string m_Title;
        [SerializeField] private Sprite m_Icon;
        [SerializeField] private GameObject m_Prefab;
        [SerializeField] private Subject m_Subject;
        [SerializeField] private Grade m_Grade;

        public string title => m_Title;
        public Sprite icon => m_Icon;
        public GameObject prefab => m_Prefab;
        public Subject subject => m_Subject;
        public Grade grade => m_Grade;
    }
}