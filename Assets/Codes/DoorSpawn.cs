using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpawn : MonoBehaviour
{
    public GameObject triggerDoor;
    public GameObject colliderDoor;
    public GameObject collider1Door;
    public GameObject collider2Door;
    public GameObject room;
    float enemyCount;
    private IEnumerator coroutine;

    private void Start()
    {
        enemyCount = room.GetComponent<EnemySpawner>().enemyAmount;
        colliderDoor.SetActive(false);
        if (collider1Door != null)
        {
            collider1Door.SetActive(false);
        }
        if (collider2Door != null)
        {
            collider2Door.SetActive(false);
        }

    }
    private void Update()
    {
        if (EnemySpawner.enemiesAlive <= 0)
        {

            colliderDoor.SetActive(false);
            if (collider1Door != null)
            {
                collider1Door.SetActive(false);
            }
            if (collider2Door != null)
            {
                collider2Door.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            //triggerDoor.SetActive(false);
            colliderDoor.SetActive(true);
            if (collider1Door != null)
            {
                collider1Door.SetActive(true);
            }
            if (collider2Door != null)
            {
                collider2Door.SetActive(true);
            }
            room.SetActive(true);

        }
        if (EnemySpawner.enemiesAlive <= 0)
        {
            
            colliderDoor.SetActive(false);
            if (collider1Door != null)
            {
                collider1Door.SetActive(false);
            }
            if (collider2Door != null)
            {
                collider2Door.SetActive(false);
            }
        }
    }
}
