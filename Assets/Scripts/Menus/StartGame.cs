using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class StartGame : MonoBehaviour
    {
        [SerializeField] private PlayableDirector timeLine;
        public void StartGameScene()
        {
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
    }
}
