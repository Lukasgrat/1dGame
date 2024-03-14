using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    GameObject projecTileHolder;
    [SerializeField]
    Sprite orignalSprite;
    [SerializeField]
    Sprite upgradeSprite;
    bool hasUpgrade;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timer = 0;
        hasUpgrade = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && timer == 0) 
        {
            Vector3 pos = this.transform.position;
            Projectile newProc =  Object.Instantiate(proc,
            new Vector3(pos.x + 1, pos.y, pos.z),
            new Quaternion(), projecTileHolder.transform);
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
            this.scoreUpdate(this.score + 100);
            Object.Destroy(c.gameObject);
        }
        else if (collision.gameObject.TryGetComponent(out EnemyScript e))
        {
            if (hasUpgrade)
            {
                Object.Destroy(e.gameObject);
                this.changeScore(-200);
            }

            else
            {
                this.loseScreen.SetActive(true);
                Object.Destroy(this);
            }
        }
    }
    void scoreUpdate(int score)
    {
        this.score = score;
        this.scoreDisplay.text = this.score.ToString();
    }

    public void changeScore(int change) 
    {
        this.scoreUpdate(this.score + change);
    }
}
