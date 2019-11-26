using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    GameObject Player;
    GameObject[] Enemy;
    private int damage = 1;
    EnemyController eControler;

    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", lifeTime);
        Player = GameObject.FindGameObjectWithTag("player");
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in Enemy)
        {
            eControler = enemy.GetComponent<EnemyController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            enemy.TakeDamage(damage);
            DestroyBullet();
        }
        if (collision.gameObject.tag == "Boss")
        {
            Boss boss = collision.gameObject.GetComponent<Boss>();
            boss.TakeDamage(damage);
            DestroyBullet();
        }
        if (collision.gameObject.tag == "Walls") 
        {
            DestroyBullet();
        }
    }


}
