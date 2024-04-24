using System.Collections;
using BloomMare.Data;
using BloomMare.UI;
using UnityEngine;

namespace BloomMare {
    public class Bootstrapper : MonoBehaviour {
        [SerializeField] private float m_LoadDelay = 4f;
        [SerializeField] private LoadingScreen m_LoadingScreen;
        [SerializeField] private GlobalConfig m_GlobalConfig;

        private IEnumerator Start() {
            DontDestroyOnLoad(m_LoadingScreen.gameObject);
            Global.Initialize(m_GlobalConfig, m_LoadingScreen);
            yield return new WaitForSeconds(m_LoadDelay);
            Global.LoadScene(SceneType.Menu);
        }
    }
}