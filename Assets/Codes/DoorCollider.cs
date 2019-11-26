using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    public GameObject keySprite;
    public GameObject dialogManager;
    public GameObject dialogueUI;
    public GameObject bossHealth;
    
    bool colliding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (keySprite.activeInHierarchy == true)
        {
            gameObject.SetActive(false);
            bossHealth.SetActive(true);
        }
        else if (colliding == false)
        {
            colliding = true;
            dialogManager.GetComponent<Dialogue>().StartConversation();
            dialogueUI.SetActive(true);
        }
    }
}
