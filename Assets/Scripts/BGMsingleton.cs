using UnityEngine;

/// <summary>
///     Singleton for BGM to make sure that it doesn't get duplicated.
/// </summary>
public class BGMsingleton : MonoBehaviour
{
    static BGMsingleton()
    {
        Instance = null;
    }

    private static BGMsingleton Instance { get; set; }

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