using UnityEngine;

/// <summary>
/// defines enemy's behaviour
/// </summary>
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Start()
    {
        speed = Random.Range(-5f, -10f);
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + Time.deltaTime * speed, transform.position.y, transform.position.z);

        // sometimes ememies looks flipping, the code below is to fix it
        if (transform.localScale.y < 0)
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
    }


    // after exiting the camera, they hit the destroyer collider and get destroyed.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}