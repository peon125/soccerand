﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotHandler : MonoBehaviour {
    public float speed;
    public float force;
    public int whatShotAmI;
    Vector3 passingVector;
    Color colorToChangeOn;
    
	void Start()
    {
        if (transform.position.x > 0)
        {
            transform.Rotate(new Vector3(0f, 180f, 0f));
            speed = -speed;
            force = -force;
        }

        force *= 200;

        GetComponent<Rigidbody>().velocity = new Vector3(speed, 0f, 0f);
	}

    void OnCollisionEnter(Collision collid) 
    {
        Destroy(gameObject);

        if(collid.gameObject.tag == "ball")
        {
            collid.gameObject.GetComponent<Rigidbody>().AddForce (new Vector3(force, 0f, 0f));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "half" && whatShotAmI == 0)
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "wholeCourt" && whatShotAmI != 0)
        {
            Destroy(gameObject);
        }
    }

    public void setColorToChangeOn(Color c)
    {
        colorToChangeOn = c;
    }
}
