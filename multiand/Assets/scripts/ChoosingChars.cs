using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosingChars : MonoBehaviour 
{
    public Menu2Control gameController;
    public GameObject arrowPrefab;
    Collider[] characters;
    GameObject arrow;
    GameSet gameSet;
    Settings settings;

	void Start() 
    {
        arrow = null;
        settings = GameObject.Find("settings").GetComponent<Settings>();
        gameSet = GameObject.Find("gameSetter").GetComponent<GameSet>();
        if (gameSet.getWhitePlays())
        {
            IAmABot();
        }
	}
	
	void Update() 
    {
		
	}

    void IAmABot()
    {
        //
    }
}
