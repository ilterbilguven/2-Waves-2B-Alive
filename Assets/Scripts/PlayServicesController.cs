using GooglePlayGames;
using UnityEngine;

/// <summary>
/// initializing play services
/// </summary>
public class PlayServicesController : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(success =>
        {
            // handle success or failure
        });
    }

    public void ShowLeaderboard()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI("fillithere");
    }

    // Update is called once per frame
    private void Update()
    {
    }
}