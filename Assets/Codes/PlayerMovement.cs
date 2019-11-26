using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMovement;
    private float verticalMovement;
    [SerializeField]
    public float speed;
    Rigidbody2D rb;
    private Vector3 lastDirection;
    [SerializeField]
    private float dashSpeed;
    public AudioClip getHurt;
    public AudioClip footSteps;

    Vector3 movement;

    private AudioSource aSource;

    public int health = 3;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        aSource = gameObject.GetComponent<AudioSource>();

    }

    private void FixedUpdate()
    {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        Vector3 baseLastDirection = new Vector3(movement.x, movement.y).normalized;
        lastDirection = baseLastDirection;
        
        transform.position = transform.position + movement * Time.deltaTime * speed;
        if (movement != new Vector3(0,0,0))
        {
            if (!aSource.isPlaying)
            {
                aSource.PlayOneShot(footSteps);
            }
            else
            {
                return;
            }

        }
        else if(aSource.isPlaying || movement == new Vector3(0, 0, 0))
        {
            aSource.Stop();
        }
       /* print(movement);
        if (Input.GetAxis("Horizontal") > 0 && Input.GetKeyDown(KeyCode.Mouse1))
        {
            print("works to the right");
            rb.AddForce(new Vector2(1, 0) * dashSpeed, ForceMode2D.Impulse);
        }
        else if (Input.GetAxis("Horizontal") < 0 && Input.GetKeyDown(KeyCode.Mouse1))
        {
            print("works to the left");
            rb.AddForce(new Vector2(-1, 0) * dashSpeed, ForceMode2D.Impulse);
        }

        if (Input.GetAxis("Vertical") > 0 && Input.GetKeyDown(KeyCode.Mouse1))
        {
            print("works to the up");
            rb.AddForce(new Vector2(0, 1) * dashSpeed, ForceMode2D.Impulse);
        }
        else if (Input.GetAxis("Vertical") > 0 && Input.GetKeyDown(KeyCode.Mouse1))
        {
            print("works to the down");
            rb.AddForce(new Vector2(0, -1) * dashSpeed, ForceMode2D.Impulse);
        }*/
    }
    private void Update()
    {
        DashHolder(lastDirection);
    }

    public void Hurt(int damage)
    {
        health -= damage;
        if (health == 0)
        {
            Destroy(gameObject,0.1f);
            
        }
        aSource.PlayOneShot(getHurt);
    }
    private void DashHolder(Vector3 lastDir)
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            float dashDistance = 3f;
            transform.position += lastDir * dashDistance;
        }

    }
}
     