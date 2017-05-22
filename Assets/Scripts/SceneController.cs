using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// to load levels with button actions
/// </summary>
public class SceneController : MonoBehaviour
{
    public void goToScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}