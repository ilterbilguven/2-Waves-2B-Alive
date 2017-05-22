using UnityEngine;

/// <summary>
///     Singleton for BG to make sure that it doesn't get duplicated.
/// </summary>
public class BGsingleton : MonoBehaviour
{
    static BGsingleton()
    {
        Instance = null;
    }

    private static BGsingleton Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}