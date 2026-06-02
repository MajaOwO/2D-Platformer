using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void Pause()
    {
        Debug.Log("Pause");
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Home()
    {
        Debug.Log("Home");
        SceneManager.LoadScene("WelcomeScrean");
        Time.timeScale = 1;
    }
    public void Resume()
    {
        Debug.Log("Home");
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

}
