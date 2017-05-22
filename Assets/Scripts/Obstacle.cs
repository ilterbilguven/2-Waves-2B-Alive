using System.Collections;
using UnityEngine;


/// <summary>
/// canChange: to keep the obstacles safe untill they need to change.
/// points: positons
/// rotations: )
/// obstacles: gameobjects
/// </summary>
public class Obstacle : MonoBehaviour
{
    public bool[] canChange { get; private set; }
    public Vector3[] points { get; private set; }
    public float[] rotations { get; private set; }
    public GameObject[] obstacles { get; private set; }

    public Obstacle(int count)
    {
        obstacles = new GameObject[count];
        points = new Vector3[count];
        rotations = new float[count];
        canChange = new bool[count];
        

        for (var i = 0; i < count; i++)
        {
            points[i] = Vector3.zero;
            rotations[i] = 0;
            canChange[i] = false;
        }
    }
}