using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// To make BG look infinite
/// </summary>
public class InfiniteBG : MonoBehaviour
{

	[SerializeField] private float speed;
	
	void FixedUpdate () {
        gameObject.transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
        if (gameObject.transform.position.x < -12)
        {
            gameObject.transform.position += new Vector3(2* 21.58f, 0, 0);
        }
	}
}
