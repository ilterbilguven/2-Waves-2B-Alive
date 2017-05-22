using System.Collections;
using UnityEngine;

/// <summary>
/// generates enemies in random time to the game over.
/// </summary>

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab1;
    [SerializeField] private GameObject enemyPrefab2;

    [SerializeField] private PlayerController pc;
    
    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.2f, 1.2f));
            if(!pc.pressedStart) continue;
            Instantiate(enemySelect(), new Vector2(20, Random.Range(-5f, 5f)), Quaternion.Euler(0, 0, 90f)).transform.parent = gameObject.transform;
        }
    }

    /// <summary>
    /// we have 2 prefabs for enemies, this function chooses it randomly.
    /// </summary>
    /// <returns></returns>
    private GameObject enemySelect()
    {
        return Random.Range(0, 2) == 1 ? enemyPrefab2 : enemyPrefab1;
    }
}