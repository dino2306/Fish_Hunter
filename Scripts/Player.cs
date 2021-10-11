using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public static Player instance;
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public MovementJoysitck joystick;
    private Rigidbody2D rb;
    public float speed = 5f;
    public Text input_F;
    public Text Score;
    public int kill;

    public GameObject[] Fishs;
    public int n;

    public Vector2 GameobjectRotation;
    private float GameobjectRotation2;
    private float GameobjectRotation3;

    public bool FacingRight = true;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
         n = PlayerPrefs.GetInt("selectOption", 0);

        foreach (GameObject fish in Fishs)
        {
            fish.SetActive(false);
        }
        Fishs[n].SetActive(true);

        if (!PlayerPrefs.HasKey("YOURNAME") )
        {

            input_F.text = "Player";
        }
        else
        {
            input_F.text = PlayerPrefs.GetString("YOURNAME");
        }
       
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
        if (Input.GetKey(KeyCode.H))
        {
            SceneManager.LoadScene(0);
            Debug.Log("eee");
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
    public GameObject diePlayFab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            kill++;
            Score.text ="Kill: " + kill.ToString();
            Instantiate(diePlayFab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            StartCoroutine(Reviver());
        }
        if (collision.gameObject.tag.Equals("Item"))
        {
            Destroy(collision.gameObject);
        }
    }



    public GameObject hs;
  
    IEnumerator Reviver()
    {
        yield return new WaitForSeconds(3);
        Instantiate(hs, transform.position, Quaternion.identity);
    }
}
