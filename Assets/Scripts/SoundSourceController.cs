using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// for handling sound source in mainmenu
/// </summary>
public class SoundSourceController : MonoBehaviour
{
    private MuteController bgm;
    public string name;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bgm = GameObject.Find(name).GetComponent<MuteController>();
    }

    public void ToggleMute()
    {
        bgm.ToggleMute();
    }
}
