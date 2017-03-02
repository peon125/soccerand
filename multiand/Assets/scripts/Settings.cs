using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    GameObject settingsGUI;
    Button[] buttons;
    bool isPaused;

	void Start()
    {
        buttons = new Button[0];

        if(GameObject.Find("settings").tag == "Default")
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        settingsGUI = transform.GetChild(0).gameObject;
        settingsGUI.SetActive(false);
        isPaused = false;
	}

    void OnLevelWasLoaded()
    {
        buttons = GameObject.FindGameObjectWithTag("Interface").GetComponentsInChildren<Button>();
        Debug.Log(buttons.Length);
    }

	void Update()
    {
        if (Input.GetButtonDown("escape"))
        {
            if (settingsGUI.activeInHierarchy)
            {
                foreach(Button b in buttons)
                {
                    b.interactable = false;
                }

                isPaused = false;
                Time.timeScale = 1;
                settingsGUI.SetActive(false);
            }
            else
            {
                foreach(Button b in buttons)
                {
                    b.enabled = true;
                }

                isPaused = true;
                Time.timeScale = 0;
                settingsGUI.SetActive(true);
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
