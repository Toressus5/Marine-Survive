using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendDialogue : MonoBehaviour
{
    public GameObject dialogManager;
    public GameObject dialogueUI;
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
        if (collision.gameObject.tag == "player")
        {
            print(collision.gameObject);
            dialogueUI.SetActive(true);
            dialogManager.GetComponent<Dialogue>().StartConversation();
        }
    }
}
