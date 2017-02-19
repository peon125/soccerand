﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ControlCharacter : MonoBehaviour
{
    public GameObject[] firesPrefabs;
    public float[] delays;
    public float speed, boundary;
    public float[] cooldowns;
    public Sprite[] spellsPics;
    public Sprite avatar, bigPic;
    PlayerHandler ph;
    Transform bulletsTransform;
    GameObject ball;
    CooldowsHandler cooldownsHandler;
    Text[] cooldownTexts;
    float characterDefaultXPosistion;
    string[] buttons;
    bool isABot;
    int[] buttonsValues;

    void Start() 
    {
        isABot = false;
        ph = transform.parent.GetComponent<PlayerHandler>();
        buttons =  ph.getButtons();
        buttonsValues = ph.getButtonsValues();
        cooldownTexts = ph.getCooldownTexts();
        characterDefaultXPosistion = transform.position.x;
        cooldowns = new float[3];
        cooldownsHandler = ph.cooldownHandler;
        bulletsTransform = GameObject.Find("bullets").transform;
        ball = GameObject.FindGameObjectWithTag("ball");

        if (buttons[0] == "0")
        {
            isABot = true;
        }
    }

    void Update() 
    {
        if (isABot)
            IAmABot();
        else
        {
            buttonsValues = ph.getButtonsValues();

            Move();

            Shoot();
        }

        for (int i = 0; i < cooldowns.Length; i++)
        {
            cooldowns[i] -= Time.deltaTime;
        }

        cooldownsHandler.setCooldowns(cooldowns);
    }

    void Move()
    {
        transform.position += new Vector3(0f, 0f, (float)Math.Round(buttonsValues[0] * speed));
        transform.position = new Vector3(characterDefaultXPosistion, transform.position.y, Mathf.Clamp(transform.position.z, -boundary, boundary));
    }

    void Shoot()
    {
        for (int j = 1; j < buttons.Length; j++)
        {
            int i = j - 1;
            if (buttonsValues[i] == 1 && cooldowns[i] <= 0)
            {
                GameObject shot = Instantiate(firesPrefabs[i], firesPrefabs[i].transform.position + transform.position, firesPrefabs[i].transform.rotation, bulletsTransform);
                ShotHandler shotHandler = shot.GetComponent<ShotHandler>();
                shotHandler.setColorToChangeOn(transform.GetChild(0).GetComponent<Renderer>().material.color);

                cooldowns[i] = delays[i];
                break;
            }
        }
    }

    void IAmABot()
    {
        for (int i = 0; i < cooldowns.Length; i++)
        {
            if (cooldowns[i] <= 0)
            {
                GameObject shot = Instantiate(firesPrefabs[i], firesPrefabs[i].transform.position + transform.position, firesPrefabs[i].transform.rotation, bulletsTransform);
                shot.GetComponent<MeshRenderer>().material.color = transform.GetChild(0).GetComponent<Renderer>().material.color;

                cooldowns[i] = delays[i];
                break;
            }
        }

        if (ball.transform.position.z > transform.position.z)
        {
            transform.position += new Vector3(0, 0, speed);
        }
        else
        {
            transform.position -= new Vector3(0, 0, speed);
        }
    }

    public void ResetCooldowns()
    {
        for (int i = 0; i < cooldowns.Length; i++)
        {
            cooldowns[i] = 0f;
        }
    }

    public float[] getCooldowns()
    {
        return cooldowns;
    }
}