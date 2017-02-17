using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhitePlays : MonoBehaviour 
{
    public GameSet gameSet;

    void OnMouseDown()
    {
        gameSet.setWhitePlays(!gameSet.getWhitePlays());

        if(gameSet.getWhitePlays())
        {
            GetComponent<Image>().color = Color.green;
        }
        else
        {
            GetComponent<Image>().color = Color.red;
        }
    }
}
