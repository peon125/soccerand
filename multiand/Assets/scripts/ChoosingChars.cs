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
	}

    public void ChooseChar(CharAvatar go)
    {
        int index;
        GameObject arrow;
        switch (go.getWhichPlayer())
        {
            case "white":
                index = go.getIndex();
                Destroy(GameObject.Find("whiteArrow"));arrow = Instantiate(arrowPrefab, new Vector3(transform.position.x - 20, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0), transform);
                arrow.name = "whiteArrow";

                gameSet.setWhiteCharacter(index);
                gameController.setWhitePicsAndDesc(index);
                break;

            case "black":
                index = go.getIndex();
                Destroy(GameObject.Find("whiteArrow"));
                arrow = Instantiate(arrowPrefab, new Vector3(transform.position.x - 20, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0), transform);
                arrow.name = "whiteArrow";

                gameSet.setWhiteCharacter(index);
                gameController.setWhitePicsAndDesc(index);
                break;
        }
    }
}
