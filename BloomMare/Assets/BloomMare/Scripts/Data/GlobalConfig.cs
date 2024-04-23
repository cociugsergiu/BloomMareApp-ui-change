using BloomMare.Lessons;
using BloomMare.UI;
using UnityEngine;

namespace BloomMare.Data {
    [CreateAssetMenu(menuName = "BloomMare/Global Config", fileName = "GlobalConfig")]
    public class GlobalConfig : ScriptableObject {
        [Tooltip("The target used for all lessons")]
        [SerializeField] private TargetObject m_ActiveTarget;

        [Header("Data")]
        [Tooltip("Grades path relative to Resources folder")]
        [SerializeField] private string m_GradesPath = "Grades";
        [Tooltip("Subjects path relative to Resources folder")]
        [SerializeField] private string m_SubjectsPath = "Subjects";
        [Tooltip("Lessons path relative to Resources folder")]
        [SerializeField] private string m_LessonsPath = "Lessons";

        [Header("Prefabs")]
        [SerializeField] private GradeButton m_GradeButtonPrefab;
        [SerializeField] private SubjectButton m_SubjectButtonPrefab;
        [SerializeField] private LessonButton m_LessonButtonPrefab;

        public TargetObject activeTarget => m_ActiveTarget;
        public string gradesPath => m_GradesPath;
        public string subjectsPath => m_SubjectsPath;
        public string lessonsPath => m_LessonsPath;
        public GradeButton gradeButtonPrefab => m_GradeButtonPrefab;
        public SubjectButton subjectButtonPrefab => m_SubjectButtonPrefab;
        public LessonButton lessonButtonPrefab => m_LessonButtonPrefab;
    }
}