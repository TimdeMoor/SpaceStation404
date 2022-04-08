using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class StartGame : MonoBehaviour
    {
        public void StartGameScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
