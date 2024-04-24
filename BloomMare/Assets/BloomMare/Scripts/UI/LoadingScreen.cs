using System;
using System.Collections;
using UnityEngine;

namespace BloomMare.UI {
    public class LoadingScreen : MonoBehaviour {
        [SerializeField] private float m_FadeDuration = 1f;
        [SerializeField] private AnimationCurve m_FadeCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        [SerializeField] private CanvasGroup m_CanvasGroup;

        private Coroutine m_FadeCoroutine;

        public void Show(Action onComplete = null) {
            if (m_FadeCoroutine != null) {
                StopCoroutine(m_FadeCoroutine);
            }

            m_CanvasGroup.blocksRaycasts = true;
            m_FadeCoroutine = StartCoroutine(FadeRoutine(0f, 1f, onComplete));
        }

        public void Hide(Action onComplete = null) {
            if (m_FadeCoroutine != null) {
                StopCoroutine(m_FadeCoroutine);
            }

            m_CanvasGroup.blocksRaycasts = false;
            m_FadeCoroutine = StartCoroutine(FadeRoutine(0.5f, 0f, onComplete));
        }

        private IEnumerator FadeRoutine(float delay, float alpha, Action onComplete) {
            yield return new WaitForSeconds(delay);

            var time = 0f;
            var startAlpha = m_CanvasGroup.alpha;

            while (time < m_FadeDuration) {
                time += Time.deltaTime;
                m_CanvasGroup.alpha = Mathf.Lerp(startAlpha, alpha, m_FadeCurve.Evaluate(time / m_FadeDuration));
                yield return null;
            }

            m_CanvasGroup.alpha = alpha;
            yield return null;
            onComplete?.Invoke();
        }
    }
}