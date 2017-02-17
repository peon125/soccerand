using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAvatar : MonoBehaviour 
{
    public GameObject arrowPrefab;
    GameSet gameSet;
    string whichPlayer; //possible only "white" or "black"
    int index;

	void Start() 
    {
        gameSet = GameObject.Find("gameSetter").GetComponent<GameSet>();
	}

    void OnMouseDown()
    {
        GameObject arrow = Instantiate(arrowPrefab, new Vector3(transform.position.x - 20, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0), transform);

        if (whichPlayer == "white")
        {
            Destroy(GameObject.Find("whiteArrow"));
            arrow.name = "whiteArrow";

            gameSet.setWhiteCharacter(index);
        } 
        else if(whichPlayer == "black")
        {
            Destroy(GameObject.Find("blackArrow"));
            arrow.name = "blackArrow";

            gameSet.setWhiteCharacter(index);
        }
    }

    public void setWhichPlayer(string s)
    {
        whichPlayer = s;
    }

    public void setIndex(int i)
    {
        index = i;
    }
}
