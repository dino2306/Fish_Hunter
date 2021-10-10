using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public MovementJoysitck joystick;
    private Rigidbody2D rb;
    public float speed = 5f;

    public GameObject[] Fishs;
    public int n;

    public Vector2 GameobjectRotation;
    private float GameobjectRotation2;
    private float GameobjectRotation3;

    public bool FacingRight = true;
    Vector2 vstart;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // n = PlayerPrefs.GetInt("selectOption", 0);

        foreach (GameObject fish in Fishs)
        {
            fish.SetActive(false);
        }
        Fishs[n].SetActive(true);
        vstart =Fishs[n].transform.position;
    }

    private void FixedUpdate()
    {
        if (joystick.joysiickVec.y != 0)
        {

            rb.MovePosition(rb.position + joystick.joysiickVec * speed * Time.fixedDeltaTime);
            // rb.velocity = new Vector2(joystick.joysiickVec.x * speed, joystick.joysiickVec.y * speed);
        }
        else
        {
            rb.velocity = Vector2.zero;

        }

    }
  // public float angle;
    // Update is called once per frame
    void Update()
    {
        if (joystick.joysiickVec == Vector2.zero) return;
        GameobjectRotation = new Vector2(joystick.joysiickVec.x, joystick.joysiickVec.y);
        GameobjectRotation3 = GameobjectRotation.x;
        if (FacingRight)
        {
            //Rotates the object if the player is facing right
            GameobjectRotation2 = GameobjectRotation.x + GameobjectRotation.y * 90;
            Fishs[n].transform.rotation = Quaternion.Euler(GameobjectRotation2 * Vector3.forward);
        }
        else
        {
            //Rotates the object if the player is facing left
            GameobjectRotation2 = GameobjectRotation.x + GameobjectRotation.y * -90;
            Fishs[n].transform.rotation = Quaternion.Euler(0f, 180f, -GameobjectRotation2);
        }
        if (GameobjectRotation3 < 0 && FacingRight)
        {
            // Executes the void: Flip()
            Flip();

        }
        else if (GameobjectRotation3 > 0 && !FacingRight)
        {
            // Executes the void: Flip()
            Flip();
        }
        /*
         * tat ca cac doan tren dung de check khi qua quay sang trai or sang phai se chuyen vector Y cua player sang 180 do!
        */
        Upspeed();
    /*    if (joystick.joysiickVec.x > 0)
        {
            Fishs[n].transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (joystick.joysiickVec.x < 0)
        {
            Fishs[n].transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (joystick.joysiickVec == Vector2.zero) return;

        angle = Mathf.Atan2(joystick.joysiickVec.y, joystick.joysiickVec.x) * Mathf.Rad2Deg;
        var lookRotation = Quaternion.Euler(angle * Vector3.forward);
        transform.rotation = lookRotation;
        transform.localScale = joystick.joysiickVec.x > 0 ? Vector3.one : new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        Debug.Log(Fishs[n].transform.localScale.y);
*/
    }
    private void Flip()
    {
        // Flips the player.
        FacingRight = !FacingRight;

        Fishs[n].transform.rotation= Quaternion.Euler(0, 180,0);
    }
    private void Upspeed()
    {
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            speed *=  2;
            Debug.Log(speed);
        }
        else if (Input.GetKeyUp(KeyCode.Space) )
        {
            speed /= 2;
            Debug.Log(speed);
        }
    }
}
