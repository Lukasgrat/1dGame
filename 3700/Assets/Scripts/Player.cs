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
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out CandyScript c)) 
        {
            this.scoreUpdate(this.score + 100);
            Object.Destroy(c.gameObject);
        }
        else if(collision.gameObject.TryGetComponent(out EnemyScript e)) 
        { 
            this.loseScreen.SetActive(true);
            Object.Destroy(this);
        }
    }
    void scoreUpdate(int score) 
    {
        this.score = score;
        this.scoreDisplay.text = this.score.ToString();
    }
}
