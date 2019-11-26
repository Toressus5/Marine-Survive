using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPickup : MonoBehaviour
{
    public GameObject keySprite;

    GameObject player;
    public GameObject dialogManager;
    public GameObject dialogueUI;
    static bool hasKey;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            dialogueUI.SetActive(true);
            keySprite.SetActive(true);
            dialogManager.GetComponent<Dialogue>().StartConversation();
            Destroy(gameObject, 0.5f);
            
        }
    }
}
