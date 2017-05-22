using System.Collections;
using UnityEngine;

/// <summary>
/// Creates hexagons that follows a Sin function, animates and colorizes it.
/// Also function changes over time.
/// </summary>
public class ObstacleController : MonoBehaviour
{

    [SerializeField] private int obstacleCount;
    [SerializeField] private Color[] colors;

    private float[] functionValue;
    [SerializeField] private float heightMultiplier = 0.2f;
    private bool canPickRandom;

    [SerializeField] private GameObject prefab;

    private float[] randX;
    private float[] randY;

    private bool firstFuncPass;
    [SerializeField] private float space = 0.2f;
    [SerializeField] private float speed;
    [SerializeField] private PlayerController pc;
    private Obstacle obstacle;

    private void Start()
    {
        obstacle = new Obstacle(obstacleCount);
        
        //filling gameobjects
        for (var i = 0; i < obstacleCount; i++)
        {
            obstacle.obstacles[i] = Instantiate(prefab, Vector2.zero, Quaternion.identity);
            obstacle.obstacles[i].transform.parent = gameObject.transform;
        }

        InitRands(); // first pick of randoms

        functionValue = new float[2];

        StartCoroutine(Change());
    }

    private void InitRands()
    {
        randX = new float[2];
        randY = new float[2];
        for (var i = 0; i < 2; i++) randX[i] = Random.Range(0f, 2f);
        for (var i = 0; i < 2; i++) randY[i] = Random.Range(0f, 2f);

    }


    private void FixedUpdate()
    {
        // randomizing the inside of sin function.
        if (canPickRandom)
        {
            if (!firstFuncPass)
            {
                randX[1] = Random.Range(0f, 1.45f);
                randY[1] = Random.Range(0f, 1.45f);
            }
            if (firstFuncPass)
            {
                randX[0] = Random.Range(0f, 2f);
                randY[0] = Random.Range(0f, 2f);
            }
            canPickRandom = false;
        }

        // colorizing
        obstacle.obstacles[Random.Range(0, obstacleCount - 1)].GetComponent<Renderer>().material.color = colors[Random.Range(0, 5)];

        // animation
        for (var i = obstacleCount - 1; i >= 0; i--) obstacle.points[i] = new Vector3(i * space, ReturnFunctionValue(i), 0.0f);
        for (var i = obstacleCount - 1; i > 0; i--)
        {
                var center = (obstacle.points[i - 1] + obstacle.points[i]) / 2f;
        
                obstacle.rotations[i] = Vector3.Angle(obstacle.points[i - 1] - obstacle.points[i], Vector3.right);
        
                if (obstacle.points[i - 1].y < obstacle.points[i].y) obstacle.rotations[i] = -obstacle.rotations[i];
        
                obstacle.obstacles[i - 1].gameObject.transform.position = center;
        
                obstacle.obstacles[i - 1].gameObject.transform.rotation = Quaternion.Euler(0f, 0f, obstacle.rotations[i]);

       
        }

        
    }

    /// <summary>
    /// For changing the function more smoothly. 
    /// </summary>
    /// <returns></returns>
    private IEnumerator Change()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            if (!pc.pressedStart) continue; // Waiting for player to start playing.

            firstFuncPass = false;
            canPickRandom = true;

            for (var i = obstacleCount - 1; i >= 0; i--)
            {
                yield return new WaitForSeconds(0.05f);
                obstacle.canChange[i] = true;
            }
            canPickRandom = true;
            firstFuncPass = true;
            for (var i = obstacleCount - 1; i >= 0; i--)
            {
                yield return new WaitForSeconds(0.05f);
                obstacle.canChange[i] = false;
            }
            firstFuncPass = false;
        }
    }

    /// <summary>
    /// Returns the sin function value
    /// </summary>
    /// <param name="i">index</param>
    /// <returns>sin function value</returns>
    private float ReturnFunctionValue(int i)
    {
        var t = Time.time;

        functionValue[0] = randX[0] * Mathf.Sin(i * heightMultiplier + t * speed) +
                      randY[0] * Mathf.Sin(i * heightMultiplier + t * speed);
        functionValue[1] = randX[1] * Mathf.Sin(i * heightMultiplier + t * speed) +
                      randY[1] * Mathf.Sin(i * heightMultiplier + t * speed);

        return obstacle.canChange[i] ? functionValue[1] : functionValue[0];
    }
}
