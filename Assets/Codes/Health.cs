using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int numberOfHearts;
    public Image[] hearts;
    public Sprite emptyHeart;
    public Sprite fullHeart;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<PlayerMovement>().health > numberOfHearts)
        {
            GetComponent<PlayerMovement>().health = numberOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < GetComponent<PlayerMovement>().health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
