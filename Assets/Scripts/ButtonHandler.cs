using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// To handle android's navbar buttons.
/// </summary>
public class ButtonHandler : MonoBehaviour {
	public enum Actions
    {
        MainMenu,
        Nothing,
        Quit
    }

    [SerializeField] private PauseController pb;
	public Actions action { get; internal set; }

	// Update is called once per frame
	private void Update ()
	{

	    if (Input.GetKey("escape"))
	    {
	        switch (action)
	        {
                    case Actions.MainMenu:
                        SceneManager.LoadScene("Main");
                        break;
                    case Actions.Nothing:
                        break;
                    case Actions.Quit:
                        Application.Quit();
                        break;
	        }
	    }
	}

    
    private void OnApplicationPause(bool pause)
    {
	    if (pb == null) return;
	    if (!pb.pause && pause) pb.TooglePause();
    }
}
