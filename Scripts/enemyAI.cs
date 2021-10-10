using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;

    public bool shouldRotate;

    public LayerMask whatIsplayer;

   public Transform target;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Vector3 dir;

    public bool isInchaseRange;
    public bool isInAttackRange;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      //  target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        isInchaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsplayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsplayer);
        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y , dir.x) * Mathf.Rad2Deg;
        if (shouldRotate)
        {
            rb.rotation = angle;
        }
        dir.Normalize();
        movement = dir;

    }

    private void FixedUpdate()
    {
        if (isInchaseRange && !isInAttackRange)
        {
            MoveCharacter(movement);
            shouldRotate = true;
        }
        else
        {
            shouldRotate = false;
        }
        if (isInAttackRange)
        {
            rb.velocity = Vector2.zero;
        }

    }

    private void MoveCharacter(Vector2 dir)
    {
          rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
     //   rb.MovePosition(rb.position +( dir * speed * Time.deltaTime));
    }
}
