using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingLog : MonoBehaviour
{
    public Vector3 target;
    public float speed;

    // Update is called once per frame
    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if(transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
