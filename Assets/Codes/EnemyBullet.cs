using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    GameObject Player;
    public float bulletSpeed;
    Rigidbody2D rb;
    Vector2 moveDirection;
    private int damage = 1;

    private AudioSource aSource;
    public AudioClip launch;
    public AudioClip destroy;

    private float offset = -90;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("player");
        if (Player != null)
        {
            aSource = gameObject.GetComponent<AudioSource>();

            aSource.PlayOneShot(launch);


            rb = gameObject.GetComponent<Rigidbody2D>();
            moveDirection = (Player.transform.position - transform.position).normalized * bulletSpeed;
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y);

            Vector3 difference = Player.transform.position - transform.position;
            float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            DestroyBullet();
            Player.GetComponent<PlayerMovement>().Hurt(damage);
            
        }

        if (collision.gameObject.tag == "Walls")
        {
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject,0.1f);
    }
}
