using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhiteChoosingChar : MonoBehaviour 
{
    public Menu2Control gameController;
    public GameObject arrowPrefab;
    public Transform listOfChars;
    Collider[] characters;
    GameObject arrow;
    GameSet gameSet;
    Settings settings;

    void Start() 
    {
        arrow = null;
        settings = GameObject.Find("settings").GetComponent<Settings>();
        gameSet = GameObject.Find("gameSetter").GetComponent<GameSet>();

        for (int i = 0; i < listOfChars.childCount; i++)
        {
            characters[i] = listOfChars.GetChild(i).GetComponent<Collider>();
        }

        if (gameSet.getWhitePlays())
        {
            IAmABot();
        }
    }

    void Update() 
    {
        if (Input.touchCount > 0)
        {
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == null)
                {
                    return;
                }

                for (int i = 0; i < characters.Length; i++)
                {
                    if (hit.collider == characters[i])
                    {
                        gameSet.setWhiteCharacter(i);

                        if (arrow != null)
                        {
                            Destroy(arrow);
                        }

                        Transform t = characters[i].transform;

                        arrow = Instantiate(arrowPrefab, new Vector3(t.position.x - 25, t.position.y, t.position.z), new Quaternion(0, 0, 0, 0));
                    }
                }
            }
        }
    }

    void IAmABot()
    {
        //
    }
}
