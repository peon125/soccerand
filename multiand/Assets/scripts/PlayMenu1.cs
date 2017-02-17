using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu1 : MonoBehaviour 
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("menu2");
    }
}
