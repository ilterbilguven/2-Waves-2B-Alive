using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// for controlling mute operaitons
/// if there is a mute button in the scene, script will detect it to change it visually.
/// if not, only for toggling mute
/// </summary>

public class MuteController : MonoBehaviour
{
    

    [SerializeField] private Sprite mute;
    [SerializeField] private Sprite unmute;

    [SerializeField] private AudioSource source;
    
    private Button button;
    private int muteCounter;

    private void Start()
    {
        muteCounter = PlayerPrefs.GetInt("IsMute", 0);        
    }

    private void Update()
    {
        try
        {
            if (button == null)
            {
                button = GameObject.Find("MuteButton").GetComponent<Button>();
            }
        }
        catch (Exception)
        {
            //nothing
        }


        try
        {
            if (PlayerPrefs.GetInt("IsMute", 0) == 1)
            {
                source.mute = true;
                button.image.sprite = mute;
            }
            else
            {
                source.mute = false;
                button.image.sprite = unmute;
            }
        }
        catch (Exception)
        {

            //nothing
        }

    }

    public void ToggleMute()
    {
        muteCounter = ++muteCounter % 2;
        PlayerPrefs.SetInt("IsMute", muteCounter);
    }
}