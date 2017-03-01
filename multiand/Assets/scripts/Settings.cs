using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    GameObject settingsGUI;
    bool isPaused;

	void Start()
    {
        if(GameObject.Find("settings").tag == "Default")
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        settingsGUI = transform.GetChild(0).gameObject;
        settingsGUI.SetActive(false);
        isPaused = false;
	}

	void Update()
    {
        if (Input.GetButtonDown("escape"))
        {
            if (settingsGUI.activeInHierarchy)
            {
                isPaused = false;
                settingsGUI.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                isPaused = true;
                settingsGUI.SetActive(true);
                Time.timeScale = 0;
            }
        }
	}

    public bool getIsPaused()
    {
        return isPaused;
    }

    public void Klinkj()
    {
        Debug.Log("kliknal");
    }

    public void Klikajjakzjeb(string s)
    {
        Debug.Log(s);
    }
}
