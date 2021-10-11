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
        vstart = transform.position;
    }
    private void OnEnable()
    {
        if (Player.instance != null)
        {
            target = Player.instance.transform;
        }
    }
    // Update is called once per frame
    void Update()
    {

        isInchaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsplayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsplayer);
        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (shouldRotate)
        {
            rb.rotation = angle;
            if (dir.x > 0 && attack)
            {
                GetComponent<SpriteRenderer>().flipY = false;
                // GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (dir.x < 0 && attack)
            {
                GetComponent<SpriteRenderer>().flipY = true;
                //  GetComponent<SpriteRenderer>().flipX = false;

            }
        }
      
      
        dir.Normalize();
        movement = dir;

        AutoMove();
    }


    private void FixedUpdate()
    {
        if (isInchaseRange)
        {
            MoveCharacter(movement);
            shouldRotate = true;
            attack = true;
        }
        else
        {
            shouldRotate = false;
            attack = false;
        }
        //if (isInAttackRange)
        //{
        //    rb.velocity = Vector2.zero;
        //}
    }

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
        //   rb.MovePosition(rb.position +( dir * speed * Time.deltaTime));
    }
    public Vector3 vstart, vEnd;
    public bool check = false, attack = false;
    public float speedAuto;
    private void AutoMove()
    {
        if (!attack)
        {
            if (!check)
            {
                if (Vector3.Distance(transform.position, vEnd) <= 0.1f)
                {
                    check = true;
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, vEnd, Time.deltaTime * speedAuto);

                }
                GetComponent<SpriteRenderer>().flipX = true;
                // GetComponent<SpriteRenderer>().flipX = false;

            }
            else
            {
                if (Vector3.Distance(transform.position, vstart) <= 0.1f)
                {
                    check = false;
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, vstart, Time.deltaTime * speedAuto);
                }
                GetComponent<SpriteRenderer>().flipX = false;
                // GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else
        {
            return;
        }
    }

    public GameObject diePlayFab;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
           // Destroy(gameObject);
        }
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(3);
        Destroy(diePlayFab);
    }
}
