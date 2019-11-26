using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int health;
    public int damage;

    public Slider healthBar;
    public GameObject healthBarUI;

    public Transform shotPoint;
    public GameObject bullet;
    private GameObject shotBullet;

    public Transform target;

    public float timeToShoot;
    public float startTimeToShoot;
    private int shootAround = 40;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.value = health;
        target = GameObject.FindGameObjectWithTag("player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (timeToShoot <= 0)
        {
            shotBullet = Instantiate(bullet, shotPoint.position, transform.rotation);
            timeToShoot = startTimeToShoot; 
        }
        else
        {
            timeToShoot -= Time.deltaTime;
        }

    }

    public void TakeDamage(int damage)
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            healthBarUI.SetActive(false);
        }
        health -= damage;
        healthBar.value -= damage;


    }
}
