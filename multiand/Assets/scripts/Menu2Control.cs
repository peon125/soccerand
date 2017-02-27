using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu2Control : MonoBehaviour 
{
    public Image whiteBigPic, blackBigPic;
    public Image[] whiteSpellPics, blackSpellPics;
    public Transform whiteList, blackList;
    public Image imgPrefab;
    public float distOnList;
    Sprite[,] pics;
    GameObject[] chars;
    string[,] descriptions;
    GameSet gameSet;

	void Start () 
    {
        gameSet = GameObject.Find("gameSetter").GetComponent<GameSet>();
        chars = gameSet.getCharacters();
        pics = new Sprite[2, 5];
        descriptions = new string[2,3];
        for (int i = 0; i < pics.GetLength(1); i++)
        {
            pics[0, i] = chars[0].GetComponent<ControlCharacter>().pics[i];
            pics[1, i] = chars[1].GetComponent<FrostPlayerControl>().pics[i];
        }

        for (int i = 0; i < descriptions.GetLength(1); i++)
        {
            descriptions[0, i] = chars[0].GetComponent<ControlCharacter>().descriptions[i];
            descriptions[1, i] = chars[1].GetComponent<FrostPlayerControl>().descriptions[i];
        }

        for (int i = 0; i < pics.GetLength(0); i++)
        {
            imgPrefab.sprite = pics[i, 3]; //i keep little avatars on the fourth position
            Image imgWhite = (Image)Instantiate(imgPrefab, new Vector3(whiteList.transform.position.x, whiteList.transform.position.y - i * distOnList, 0), new Quaternion(0, 0, 0, 0), whiteList);
            imgWhite.name = "whiteChar" + (i + 1);
            imgWhite.GetComponent<CharAvatar>().setIndex(i);
            imgWhite.GetComponent<CharAvatar>().setWhichPlayer("white");
            Image imgBlack = (Image)Instantiate(imgPrefab, new Vector3(blackList.transform.position.x, blackList.transform.position.y - i * distOnList, 0), new Quaternion(0, 0, 0, 0), blackList);
            imgBlack.name = "blackChar" + (i + 1);
            imgBlack.GetComponent<CharAvatar>().setIndex(i);
            imgBlack.GetComponent<CharAvatar>().setWhichPlayer("black");
        }
	}

    public void setWhitePicsAndDesc(int i)
    {
        whiteBigPic.sprite = pics[i, 4];
            
        for (int j = 0; j < whiteSpellPics.Length; j++)
        {
            whiteSpellPics[j].sprite = pics[i, j];
            whiteSpellPics[j].transform.GetChild(0).GetComponent<Text>().text = descriptions[i, j];
        }
    }

    public void setBlackPicsAndDesc(int i)
    {
        blackBigPic.sprite = pics[i, 4];

        for (int j = 0; j < blackSpellPics.Length; j++)
        {
            blackSpellPics[j].sprite = pics[i, j];
            blackSpellPics[j].transform.GetChild(0).GetComponent<Text>().text = descriptions[i, j];
        }
    }
}
