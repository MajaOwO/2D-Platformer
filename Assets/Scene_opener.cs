using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_opener : MonoBehaviour
{
    public string sceneName;
   public void OpenScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
