using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackPlays : MonoBehaviour 
{
    public GameSet gameSet;

    void OnMouseDown()
    {
        gameSet.setBlackPlays(!gameSet.getBlackPlays());

        if(gameSet.getBlackPlays())
        {
            GetComponent<Image>().color = Color.green;
        }
        else
        {
            GetComponent<Image>().color = Color.red;
        }
    }
}
