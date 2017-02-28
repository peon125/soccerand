using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class FrostPlayerControl : MonoBehaviour
{
    public GameObject[] firesPrefabs;
    public float[] delays;
    public float speed, boundary;
    public float[] cooldowns;
    public Sprite[] pics;
    public string[] descriptions;
    Transform bulletsTransform;
    PlayerHandler ph;
    GameObject ball;
    CooldowsHandler cooldownsHandler;
    Text[] cooldownTexts;
    float characterDefaultXPosistion;
    string[] buttons;
    bool isABot, canFireSuperShot;
    int[] buttonsValues;

    void Start() 
    {
        isABot = false;
        ph = transform.parent.GetComponent<PlayerHandler>();
        buttons =  ph.getButtons();
        cooldownTexts = ph.getCooldownTexts();
        buttonsValues = ph.getButtonsValues();
        characterDefaultXPosistion = transform.position.x;
        cooldownsHandler = ph.cooldownHandler;
        bulletsTransform = GameObject.Find("bullets").transform;
        canFireSuperShot = false;
        ball = GameObject.FindGameObjectWithTag("ball");

        /*if (buttons[0] == "0")
        {
            isABot = true;
        }*/
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
        transform.position += new Vector3(0f, 0f, (float)(buttonsValues[0] * speed));
        transform.position = new Vector3(characterDefaultXPosistion, transform.position.y, Mathf.Clamp(transform.position.z, -boundary, boundary));
    }

    void Shoot()
    {
        if(buttonsValues[1] == 1 && cooldowns[0] <= 0)
        {
            Vector3 pos = new Vector3(transform.position.x, firesPrefabs[0].transform.position.y, transform.position.z);
            GameObject shot = Instantiate(firesPrefabs[0], pos, firesPrefabs[0].transform.rotation, bulletsTransform) as GameObject;
            shot.GetComponent<MeshRenderer>().material.color = transform.GetChild(0).GetComponent<Renderer>().material.color;
            cooldowns[0] = delays[0];
        }

        if (buttonsValues[2] == 1 && cooldowns[1] <= 0 && canFireSuperShot)
        {
            Vector3 pos = new Vector3(transform.position.x, firesPrefabs[3].transform.position.y, transform.position.z);
            GameObject shot = Instantiate(firesPrefabs[3], pos, firesPrefabs[3].transform.rotation, bulletsTransform) as GameObject;
            shot.GetComponent<MeshRenderer>().material.color = transform.GetChild(0).GetComponent<Renderer>().material.color;
            cooldowns[1] = delays[3];

            canFireSuperShot = false;
        }
        else if (buttonsValues[2] == 1 && cooldowns[1] <= 0 && !canFireSuperShot)
        {
            float posX = 0;
            if (transform.position.x > 0)
            {
                posX = transform.position.x - 8;
            }
            else
            {
                posX = transform.position.x + 8;
            }

            Vector3 pos = new Vector3(posX, firesPrefabs[1].transform.position.y, transform.position.z);
            GameObject wall = Instantiate(firesPrefabs[1], pos, firesPrefabs[1].transform.rotation, bulletsTransform) as GameObject;
            wall.GetComponent<MeshRenderer>().material.color = transform.GetChild(0).GetComponent<Renderer>().material.color;
            wall.GetComponent<FrostWall>().setWhoCreated(gameObject);
            cooldowns[1] = delays[1];
        }

        if(buttonsValues[3] == 1 && cooldowns[2] <= 0)
        {
            Vector3 pos = new Vector3(transform.position.x, firesPrefabs[2].transform.position.y, transform.position.z);
            GameObject shot = Instantiate(firesPrefabs[2], pos, firesPrefabs[2].transform.rotation, bulletsTransform) as GameObject;
            ShotHandler shotHandler = shot.GetComponent<ShotHandler>();
            shot.GetComponent<MeshRenderer>().material.color = transform.GetChild(0).GetComponent<Renderer>().material.color;
            cooldowns[2] = delays[2];
        }
    }

    void IAmABot()
    {
        /*for (int i = 0; i < cooldowns.Length; i++)
        {
            if (cooldowns[i] <= 0)
            {
                GameObject shot = Instantiate(firesPrefabs[i], firesPrefabs[i].transform.position + transform.position, firesPrefabs[i].transform.rotation, bulletsTransform);
                ShotHandler shotHandler = shot.GetComponent<ShotHandler>();
                shotHandler.setColorToChangeOn(transform.GetChild(0).GetComponent<Renderer>().material.color);
                shotHandler.setwhatShotAmI(i);

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
        }*/
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

    public void setCanFireSuperShot(bool b)
    {
        canFireSuperShot = b;

        if(b)
        {
            cooldowns[1] = 0;
        }
    }
}