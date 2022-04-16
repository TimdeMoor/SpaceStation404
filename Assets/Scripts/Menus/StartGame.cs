using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menus
{
    public class StartGame : MonoBehaviour
    {
        [SerializeField] private PlayableDirector timeLine;
        [SerializeField] private Toggle michaelMode;
        public void StartGameScene()
        {
            SetPlayerPrefs();
            FadeOut();
            Invoke(nameof(StartGameSceneDelayed), 2f);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        private void StartGameSceneDelayed()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void FadeOut()
        {
            timeLine.Play();
        }

        private void SetPlayerPrefs()
        {
            PlayerPrefs.SetInt("invertMouse", (michaelMode.isOn ? 1 : 0));
        }
    }
}
