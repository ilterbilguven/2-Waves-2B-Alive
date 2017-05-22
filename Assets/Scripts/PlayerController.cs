using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

/// <summary>
/// Player Controls:
/// audio controls
/// fire animation
/// jump controls
/// game over scenerio
/// tap to start
/// 
/// some of them may have been in seperate scripts
/// </summary>
public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject fireAnimation;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip teleportClip;
    [SerializeField] private AudioClip jumpClip;

    [SerializeField] private GameObject bottomPortal;
    [SerializeField] private GameObject topPortal;

    [SerializeField] private Text tapToStart;

    [SerializeField] private ButtonHandler bh;

    [SerializeField] private Button pauseButton;
    [SerializeField] private PauseController pb;

    [SerializeField] private float force;

    [SerializeField] private bool godMode = false;

    private int gravityDirection = 1;

    private bool reverseStart;

    public bool pressedStart { get; private set; }
    private bool pressedJump;


    private void Start()
    {
        if (Random.Range(0, 2) == 1)
        {
            reverseStart = true;
            transform.position = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
            gravityDirection *= -1;
        }
    }

    private void Update()
    {
        if (!pb.pause)
        {
            pressedJump = CrossPlatformInputManager.GetButtonDown("Jump");
            if (!pressedStart)
            {
                GetComponent<Rigidbody2D>().gravityScale = 0;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                bh.action = ButtonHandler.Actions.MainMenu;
                pauseButton.gameObject.SetActive(false);
                if (pressedJump)
                {
                    pressedStart = true;
                    bh.action = ButtonHandler.Actions.Nothing;
                    tapToStart.gameObject.SetActive(false);
                    GetComponent<Rigidbody2D>().gravityScale = reverseStart ? -1.25f : 1.25f;
                    GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                    pauseButton.gameObject.SetActive(true);
                }
            }
            animator.SetBool("isJump", pressedJump);
            fireAnimation.SetActive(pressedJump);

            if (pressedJump)
            {
                GetComponent<Rigidbody2D>().AddForce(transform.up * force * gravityDirection);
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                source.PlayOneShot(jumpClip);
            }
            source.mute = PlayerPrefs.GetInt("IsMute", 0) == 1;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "TopCollider":
                transform.position = new Vector3(transform.position.x, bottomPortal.transform.position.y + 1.5f,
                    transform.position.z);
                GetComponent<Rigidbody2D>().gravityScale *= -1;
                transform.localScale = new Vector3(transform.localScale.x,
                    -transform.localScale.y, transform.localScale.z);
                //gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                gravityDirection *= -1;
                source.PlayOneShot(teleportClip);
                break;
            case "BottomCollider":
                transform.position = new Vector3(transform.position.x, topPortal.transform.position.y - 1.5f, transform.position.z);
                GetComponent<Rigidbody2D>().gravityScale *= -1;
                transform.localScale = new Vector3(transform.localScale.x,
                    -transform.localScale.y, transform.localScale.z);
                //gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                gravityDirection *= -1;
                source.PlayOneShot(teleportClip);
                break;
            case "Obstacle":
                if (!godMode && pressedStart)
                    SceneManager.LoadScene(2);
                break;
        }
    }
}