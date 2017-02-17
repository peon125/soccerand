using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMatch : MonoBehaviour 
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("scena1");
    }
}
