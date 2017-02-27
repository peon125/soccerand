using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu1Control : MonoBehaviour 
{
    public GameSet gameSet;

    public void setWhitePlays(GameObject go)
    {
        gameSet.setWhitePlays(!gameSet.getWhitePlays());

        if(gameSet.getWhitePlays())
        {
            go.GetComponent<Image>().color = Color.green;
        }
        else
        {
            go.GetComponent<Image>().color = Color.red;
        }
    }

    public void setBlackPlays(GameObject go)
    {
        gameSet.setBlackPlays(!gameSet.getBlackPlays());

        if(gameSet.getBlackPlays())
        {
            go.GetComponent<Image>().color = Color.green;
        }
        else
        {
            go.GetComponent<Image>().color = Color.red;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("menu2");
    }
}
