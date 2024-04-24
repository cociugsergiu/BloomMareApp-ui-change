using System;
using System.Collections.Generic;
using BloomMare.Data;
using BloomMare.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BloomMare {
    public enum SceneType {
        Menu,
        Scan
    }

    public static class Global {
        private static GlobalConfig m_Config;
        private static Grade[] m_Grades;
        private static Lesson[] m_Lessons;
        private static LoadingScreen m_LoadingScreen;

        public static GlobalConfig config => m_Config;

        public static Grade selectedGrade { get; private set; }
        public static Subject selectedSubject { get; private set; }
        public static Lesson selectedLesson { get; private set; }

        public static void Initialize(GlobalConfig globalConfig, LoadingScreen loadingScreen) {
            m_LoadingScreen = loadingScreen;
            m_Config = globalConfig;

            m_Grades = Resources.LoadAll<Grade>(globalConfig.gradesPath);
            m_Lessons = Resources.LoadAll<Lesson>(globalConfig.lessonsPath);

            Application.quitting += OnApplicationQuit;
        }

        public static void LoadScene(SceneType sceneType) {
           m_LoadingScreen.Show(() => {
               LoadSceneImmediate(sceneType);
               m_LoadingScreen.Hide();
           });
        }

        public static void LoadSceneImmediate(SceneType sceneType) {
            var sceneName = sceneType switch {
                SceneType.Menu => "Menu",
                SceneType.Scan => "Scan",
                _              => throw new ArgumentOutOfRangeException(nameof(sceneType), sceneType, null)
            };

            SceneManager.LoadScene(sceneName);
            GC.Collect();
            Resources.UnloadUnusedAssets();
        }

        public static void SelectGrade(Grade grade) {
            selectedGrade = grade;
        }

        public static void SelectSubject(Subject subject) {
            selectedSubject = subject;
        }

        public static void SelectLesson(Lesson lesson) {
            selectedLesson = lesson;
        }

        public static IEnumerable<Grade> GetAllValidGrades() {
            foreach (var grade in m_Grades) {
                foreach (var lesson in m_Lessons) {
                    if (lesson.grade == grade) {
                        yield return grade;
                        break;
                    }
                }
            }
        }

        public static IEnumerable<Subject> GetSubjectsForGrade(Grade grade) {
            var uniqueSubjects = new HashSet<Subject>();

            foreach (var lesson in GetLessonsForGrade(grade)) {
                uniqueSubjects.Add(lesson.subject);
            }

            return uniqueSubjects;
        }

        public static IEnumerable<Lesson> GetLessonsForGrade(Grade grade) {
            foreach (var lesson in m_Lessons) {
                if (lesson.grade == grade) {
                    yield return lesson;
                }
            }
        }

        public static IEnumerable<Lesson> GetLessonsForGradeAndSubject(Grade grade, Subject subject) {
            foreach (var lesson in m_Lessons) {
                if (lesson.grade == grade && lesson.subject == subject) {
                    yield return lesson;
                }
            }
        }

        private static void OnApplicationQuit() {
            Application.quitting -= OnApplicationQuit;

            m_Config = null;
            m_Grades = null;
            m_Lessons = null;
            m_LoadingScreen = null;
            selectedGrade = null;
            selectedSubject = null;
            selectedLesson = null;
        }
    }
}