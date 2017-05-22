using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Pauses the game.
/// While pause; 
/// jumpbutton: disabled
/// pauseScreen: enabled
/// After unpausing;
/// Countdown from 3, and everything is normal.
/// </summary>
public class PauseController : MonoBehaviour
{
    public bool pause { get; private set; }
    [SerializeField]private ScoreController sc;
    [SerializeField]private Button pauseButton;
    [SerializeField]private GameObject pauseScreen;
    [SerializeField]private Color transparentWhite;
    [SerializeField]private GameObject jumpButton;

    public void TooglePause()
    {
        pauseButton.interactable = pause;
        pauseScreen.SetActive(!pause);
        if (!pause)
        {
            pause = true;
            Time.timeScale = 0;
            sc.setScoreText("PAUSED");
            sc.setScoreColor(Color.white);
            pauseButton.gameObject.SetActive(false);
            jumpButton.SetActive(false);
        }
        else
        {
            StartCoroutine(UnPause());
        }
    }

    private IEnumerator UnPause()
    {
                Debug.Log("3");
                sc.setScoreText("3");
                yield return new WaitForSecondsRealtime(1);
                Debug.Log("2");
                sc.setScoreText("2");
                yield return new WaitForSecondsRealtime(1);
                Debug.Log("1");
                sc.setScoreText("1");
                jumpButton.SetActive(true);
                yield return new WaitForSecondsRealtime(1);
                pause = false;
                Time.timeScale = 1;
                pauseButton.gameObject.SetActive(true);
                sc.setScoreColor(transparentWhite);
    }


}
