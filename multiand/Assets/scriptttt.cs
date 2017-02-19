using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptttt : MonoBehaviour {

    public Image img;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void klikajto(string s)
    {
        Debug.Log(s);
    }

    public void Zmiana1()
    {
        img.color = Color.green;
    }

    public void Zmiana2()
    {
        img.color = Color.blue;
    }
}
