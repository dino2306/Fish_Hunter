using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Ui : MonoBehaviour
{
    public GameObject Panel_shop;
   
    public string yourName;
  
    public InputField input_F;
    public Text Welcom;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("YOURNAME") )
        {

            input_F.text = "Player";
        }
        else
        {
            input_F.text = PlayerPrefs.GetString("YOURNAME");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Backspace))
        {
            PlayerPrefs.DeleteAll();
        }
    }
    public void Shop()
    {
        Panel_shop.SetActive(true);
       
    }
    public void Exit_shop()
    {
        Panel_shop.SetActive(false);
        
    }


   
    public void Enter_Name()
    {
        yourName = input_F.text;
        Welcom.text = "Welcom " + yourName + "...";
     
       PlayerPrefs.SetString("YOURNAME", yourName);

        StartCoroutine(PlayGame());
    }

    IEnumerator PlayGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }
}
