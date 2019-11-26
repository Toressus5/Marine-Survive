using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Rect spawnArea;

    public int enemyAmount;
    public static int enemiesAlive;

    public GameObject enemy;
    public GameObject enemyAnimation;
    private float yOffset = 0;
    private Animator animator;

    public static Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        while(enemyAmount > 0)
        {
            spawnPoint = new Vector3(Random.Range(spawnArea.xMin, spawnArea.xMax), Random.Range(spawnArea.yMin, spawnArea.yMax), yOffset);
            
            if (enemy != null && !Physics.SphereCast(spawnPoint, 1, Vector3.up, out RaycastHit hit, 0, LayerMask.NameToLayer("Ground")))
            {

                enemyAmount -= 1;
                enemiesAlive++;
               
                StartCoroutine(EnemySpawn(EnemySpawner.spawnPoint));

            }

        }
    }
    public IEnumerator EnemySpawn(Vector3 spawnPoint)
    {
        GameObject enemie = Instantiate(enemyAnimation, spawnPoint, Quaternion.identity, transform);
        yield return new WaitForSeconds(3f);
        Destroy(enemie);
        Instantiate(enemy, spawnPoint, Quaternion.identity, transform);
       
    }

}
