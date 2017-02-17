using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WhoPlays : MonoBehaviour 
{
    public GameObject white, black;
    public GameSet gameSet;
	
	void Update() 
    {
        if (Input.touchCount > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider == null)
                return;

            WhitePlays(hit);

            BlackPlays(hit);

            if (hit.collider.gameObject.name == "play")
            {
                SceneManager.LoadScene("menu2");
            }
        }
	}

    void WhitePlays(RaycastHit2D hit)
    {
        if(hit.collider.gameObject.name == "white")
        {
            gameSet.setWhitePlays(!gameSet.getWhitePlays());

            if(gameSet.getWhitePlays())
            {
                white.GetComponent<Image>().color = Color.green;
            }
            else
            {
                white.GetComponent<Image>().color = Color.red;
            }
        }
    }

    void BlackPlays(RaycastHit2D hit)
    {
        if(hit.collider.gameObject.name == "black")
        {
            gameSet.setBlackPlays(!gameSet.getBlackPlays());

            if(gameSet.getBlackPlays())
            {
                black.GetComponent<Image>().color = Color.green;
            }
            else
            {
                black.GetComponent<Image>().color = Color.red;
            }
        }
    }
}
