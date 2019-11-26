using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float bulletSpeed;
    public Transform target;

    public float health;

    public Transform shotPoint;
    public GameObject bullet;
    private GameObject shotBullet;

    public float timeToShoot;
    public float startTimeToShoot;

    Vector2 moveDirection;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        target = GameObject.FindGameObjectWithTag("player").transform;
        //StartCoroutine(EnemySpawn(EnemySpawner.spawnPoint));
    }

    // Update is called once per frame
    void Update()
    {
        //moving towards the player
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y, 0), speed);

            if (timeToShoot <= 0)
            {
                shotBullet = Instantiate(bullet, shotPoint.position, transform.rotation);
                Shoot(target.position, shotBullet);
                timeToShoot = startTimeToShoot;
            }
            else
            {
                timeToShoot -= Time.deltaTime;
            }
        }




    }

    public void TakeDamage(int damage)
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            EnemySpawner.enemiesAlive -= 1;
        }
        health -= damage;
    }
    
    public void Shoot(Vector3 position, GameObject bullet)
    {

        //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //rb.velocity = (position - bullet.transform.position).normalized * speed;
    }
}
