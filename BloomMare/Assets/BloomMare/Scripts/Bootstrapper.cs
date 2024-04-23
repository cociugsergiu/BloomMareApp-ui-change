using System.Collections;
using BloomMare.Data;
using UnityEngine;

namespace BloomMare {
    public class Bootstrapper : MonoBehaviour {
        [SerializeField] private float m_LoadDelay = 4f;
        [SerializeField] private GlobalConfig m_GlobalConfig;

        private IEnumerator Start() {
            Global.Initialize(m_GlobalConfig);
            yield return new WaitForSeconds(m_LoadDelay);
            Global.LoadScene(SceneType.Menu);
        }
    }
}