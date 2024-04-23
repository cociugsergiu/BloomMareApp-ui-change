using UnityEngine;

namespace BloomMare.Data {
    [CreateAssetMenu(menuName = "BloomMare/Grade", fileName = "G_")]
    public class Grade : ScriptableObject {
        [SerializeField] private string m_Title;
        [SerializeField] private Color m_Tint = Color.white;
        [SerializeField] private Sprite m_Icon;

        public string title => m_Title;
        public Color tint => m_Tint;
        public Sprite icon => m_Icon;
    }
}