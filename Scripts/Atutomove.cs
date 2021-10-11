using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atutomove : MonoBehaviour
{
    public float speed;
    public Transform player;
    public Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        vstart = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        AutoMove();
     
    }
    public Vector3 vstart, vEnd;
   public bool check = false;
    private void AutoMove()
    {
        if (!check )
        {
            if (Vector3.Distance(transform.position, vEnd) <= 0.1f)
            {
                check = true;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, vEnd, Time.deltaTime * speed);

            }
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            if (Vector3.Distance(transform.position, vstart) <= 0.1f)
            {
                check = false;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, vstart, Time.deltaTime * speed);
            }
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
