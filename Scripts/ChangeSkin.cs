using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public GameObject[] Skin;
    public int n;
   
    // Start is called before the first frame update
    void Start()
    {
        n = PlayerPrefs.GetInt("selectOption", 0);
        foreach (GameObject skinChidle in Skin)
        {
            skinChidle.SetActive(false);
        }
        Skin[n].SetActive(true);



    }

    // Update is called once per frame
    void Update()
    {
        nextSkin();
        BackSkin();
    }

    void nextSkin()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Skin[n].SetActive(false);
            n++;
            if (n == Skin.Length)
            {
                n = 0;
            }
            Skin[n].SetActive(true);
            PlayerPrefs.SetInt("selectOption", n);
        }
      
    }
    void BackSkin()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Skin[n].SetActive(false);
            n--;
            if (n == -1)
            {
                n = Skin.Length - 1;
            }
            Skin[n].SetActive(true);
            PlayerPrefs.SetInt("selectOption", n);
        }

    }
}
