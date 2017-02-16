using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSet : MonoBehaviour 
{
    public GameObject[] characters;
    public AudioClip dadadedadadada;
    int whiteIndex, blackIndex;
    bool whitePlays, blackPlays;

	void Start() 
    {
        GetComponent<AudioSource>().Play();

        DontDestroyOnLoad(gameObject);
	}

    public bool getWhitePlays()
    {
        return whitePlays;
    }

    public void setWhitePlays(bool b)
    {
        whitePlays = b;
    }

    public bool getBlackPlays()
    {
        return blackPlays;
    }

    public void setBlackPlays(bool b)
    {
        blackPlays = b;
    }

    public GameObject[] getCharacters()
    {
        return characters;
    }

    public GameObject getWhiteCharacter()
    {
        return characters[whiteIndex];
    }

    public void setWhiteCharacter(int character)
    {
        whiteIndex = character;
    }

    public GameObject getBlackCharacter()
    {
        return characters[blackIndex];
    }

    public void setBlackCharacter(int character)
    {
        blackIndex = character;
    }
}
