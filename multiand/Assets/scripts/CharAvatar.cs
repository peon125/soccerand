using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAvatar : MonoBehaviour 
{
    public GameObject arrowPrefab;
    Menu2Control gameController;
    GameSet gameSet;
    string whichPlayer; //possible only "white" or "black"
    int index;

	void Start() 
    {
        gameSet = GameObject.Find("gameSetter").GetComponent<GameSet>();
        gameController = GameObject.Find("gameController").GetComponent<Menu2Control>();
	}

    public void Choose()
    {
        if (whichPlayer == "white" && gameSet.getWhitePlays())
        {
            Destroy(GameObject.Find("whiteArrow"));
            GameObject arrow = Instantiate(arrowPrefab, new Vector3(transform.position.x - 20, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0), transform);
            arrow.name = "whiteArrow";

            gameSet.setWhiteCharacter(index);
            gameController.setWhitePicsAndDesc(index);
        } 
        else if(whichPlayer == "black" && gameSet.getBlackPlays())
        {
            Destroy(GameObject.Find("blackArrow"));
            GameObject arrow = Instantiate(arrowPrefab, new Vector3(transform.position.x + 20, transform.position.y, transform.position.z), new Quaternion(0, 90, 0, 0), transform);
            arrow.name = "blackArrow";

            gameSet.setBlackCharacter(index);
            gameController.setBlackPicsAndDesc(index);
        }
    }

    public string getWhichPlayer()
    {
        return whichPlayer;
    }

    public void setWhichPlayer(string s)
    {
        whichPlayer = s;
    }

    public void setIndex(int i)
    {
        index = i;
    }

    public int getIndex()
    {
        return index;
    }

}
