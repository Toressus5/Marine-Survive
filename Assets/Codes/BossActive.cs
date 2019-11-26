using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActive : MonoBehaviour
{
    public GameObject boss;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (door.activeInHierarchy == false)
        {
            boss.SetActive(true);
        }
    }
}
