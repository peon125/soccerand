using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour 
{
    public float startingPositionX, startingPositionZ;
    public CooldowsHandler cooldownHandler;
    Text[] cooldownTexts;
    int[] buttonsValues;
    GameSet gameSetter;
    bool isABot;
	
	void Start () 
    {
        isABot = false;
        gameSetter = GameObject.Find("gameSetter").GetComponent<GameSet>();
        buttonsValues = new int[4];
        for (int i = 0; i < buttonsValues.Length; i++)
        {
            buttonsValues[i] = 0;
        }
       
        if (gameObject.name == "player1")
        {
            //buttonsSet = gameSetter.getWhiteSet();
            GameObject character = Instantiate(gameSetter.getWhiteCharacter(), new Vector3(startingPositionX, 1, startingPositionZ), new Quaternion(0, 90, 0, 0), transform);
            isABot = !(gameSetter.getWhitePlays());
        }
        else if (gameObject.name == "player2")
        {
            //buttonsSet = gameSetter.getBlackSet();
            GameObject character = Instantiate(gameSetter.getBlackCharacter(), new Vector3(startingPositionX, 1, startingPositionZ), new Quaternion(0, -90, 0, 0), transform);   
            isABot = !(gameSetter.getBlackPlays());
        }
        
        cooldownTexts = cooldownHandler.cooldownsTexts;
    }

    public Text[] getCooldownTexts()
    {
        return cooldownTexts; // niepotrzebna funkcja
    }

    public void setButtonValueToOne(int i)
    {
        buttonsValues[i] = 1;
    }

    public void setButtonValueToMinusOne(int i)
    {
        buttonsValues[i] = -1;
    }

    public void setButtonValueToZero(int i)
    {
        buttonsValues[i] = 0;
    }

    public int[] getButtonsValues()
    {
        return buttonsValues;
    }

    public bool getIsABot()
    {
        return isABot;
    }
}
