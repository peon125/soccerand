using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WhiteChoosingChar : MonoBehaviour 
{
    public Menu2Control gameController;
    public GameObject arrowPrefab;
    public Transform listOfChars;
    GameObject[] characters;
    GameObject arrow;
    GameSet gameSet;
    Settings settings;

    void Start() 
    {
        arrow = null;
        settings = GameObject.Find("settings").GetComponent<Settings>();
        gameSet = GameObject.Find("gameSetter").GetComponent<GameSet>();
        characters = new GameObject[0];

        if (gameSet.getWhitePlays())
        {
            IAmABot();
        }
    }

    void Update()
    {
        if (Input.touchCount <= 0)
            return;
        
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

        RaycastHit hit;// = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        //Debug.Log(hit.ToString());

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == null)
            {
                return;
            }

            for (int i = 0; i < listOfChars.childCount; i++)
            {
                if (hit.collider == listOfChars.GetChild(i).GetComponent<BoxCollider2D>())
                {
                    gameSet.setWhiteCharacter(i);

                    if (arrow != null)
                    {
                        Destroy(arrow);
                    }

                    Transform t = listOfChars.GetChild(i).transform;

                    arrow = Instantiate(arrowPrefab, new Vector3(t.position.x - 20, t.position.y, t.position.z), new Quaternion(0, 0, 0, 0), t);
                }
            }
        }
    }

    void IAmABot()
    {
        //
    }
}
