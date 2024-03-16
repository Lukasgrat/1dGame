using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public enum Class
{
    Standard,
    Wizard,
    Sailor
}

public class Player : MonoBehaviour
{
    int score;
    [SerializeField]
    GameObject loseScreen;
    [SerializeField]
    TextMeshProUGUI scoreDisplay;
    [SerializeField]
    float cooldown = .25f;
    float timer;
    [SerializeField]
    Projectile proc;

    [SerializeField]
    Projectile procwiz;

    [SerializeField]
    Projectile procsail;
    [SerializeField]
    GameObject projecTileHolder;
    [SerializeField]
    Sprite orignalSprite;
    [SerializeField]
    Sprite sailorSprite;
    [SerializeField]
    Sprite wizardSprite;
    [SerializeField]
    Class currentClass;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && timer == 0)
        {
            Projectile newProc;
            Vector3 pos = this.transform.position;
            if (this.currentClass == Class.Standard)
            {
                newProc = Object.Instantiate(proc,
                new Vector3(pos.x + 1, pos.y, pos.z),
                Quaternion.Euler(0, 0, -50), projecTileHolder.transform);
            }
            else if (this.currentClass == Class.Wizard)
            {
                newProc = Object.Instantiate(procwiz,
                new Vector3(pos.x + 1, pos.y, pos.z),
                Quaternion.Euler(0, 0, -50), projecTileHolder.transform);
            }
            else
            {
                newProc = Object.Instantiate(procsail,
                new Vector3(pos.x + 1, pos.y, pos.z),
                Quaternion.Euler(0, 0, -50), projecTileHolder.transform);
            }
            newProc.setPlayer(this);
            this.timer = this.cooldown;
        }
        if (timer < Time.deltaTime)
        {
            timer = 0;
        }
        else 
        {
            timer -= Time.deltaTime;
        }
    }

    //Returns the score of this player
    public int getScore() 
    {
        return this.score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CandyScript c))
        {
            this.changeScore(100);
            Object.Destroy(c.gameObject);
        }
        else if (collision.gameObject.TryGetComponent(out EnemyScript e))
        {
            this.loseScreen.SetActive(true);
            Object.Destroy(this);
        }
        else if (collision.gameObject.TryGetComponent(out Costume costume))
        {
            this.scoreUpdate(this.score + 100);
            this.changeCostume(costume.getCostume());
            Object.Destroy(costume.gameObject);
        }
    }
    void scoreUpdate(int score)
    {
        this.score = score;
        this.scoreDisplay.text = this.score.ToString();
    }

    public void changeScore(int change) 
    {
        if (this.currentClass == Class.Wizard) 
        {
            change = change * 3 / 2;
        }
        else if (this.currentClass == Class.Sailor)
        {
            change = change * 2 / 3;
        }
        this.scoreUpdate(this.score + change);
    }

    //Given a class, changes the player into that costume
    void changeCostume(Class updateClass) 
    {
        if (updateClass == Class.Standard)
        {
            GetComponent<SpriteRenderer>().sprite = this.orignalSprite;
        }
        else if (updateClass == Class.Wizard)
        {
            GetComponent<SpriteRenderer>().sprite = this.wizardSprite;
        }
        else if (updateClass == Class.Sailor)
        {
            GetComponent<SpriteRenderer>().sprite = this.sailorSprite;
        }
        this.currentClass = updateClass;
    }
}
