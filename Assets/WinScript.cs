using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WinScript : MonoBehaviour
{
    private int playerHealth;
    public GameObject endScreen;
    public TextMesh text;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    { 

        if (endScreen.activeInHierarchy == true)
        {

            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(1);
                EnemySpawner.enemiesAlive = 0;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

    }
}
