using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteSpinner : MonoBehaviour
{
    [SerializeField]
    private float offset;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 difference = target.position - transform.position;
            float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
        }
        
    }
}
