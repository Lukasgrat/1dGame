using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    float cooldown;
    float timer;
    [SerializeField]
    CandyScript candyPrefab;
    [SerializeField]
    List<EnemyScript> enemyPrefab;
    [SerializeField]
    Costume wizard;
    [SerializeField]
    Costume sailor;
    [SerializeField]
    Costume defaultCostume;

    [SerializeField]
    Player p;
    int speedIncrease;
    int hasIncreasedSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        speedIncrease = 0;
    }

    void updateSpeed(int value, int IS)
    {
        if (p.getScore() > value && hasIncreasedSpeed == IS)
        {
            hasIncreasedSpeed++;
            speedIncrease += 5;
            timer = 4;
            cooldown *= .8f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateSpeed(2000, 0);
        updateSpeed(4000, 1);
        updateSpeed(8000, 2);


        if (timer == 0)
        {
            int num = Random.Range(0, 60);
            if (num < 2)
            {
                Costume returnEn = Object.Instantiate(this.wizard,
                new Vector3(this.transform.position.x,
                this.transform.position.y,
                this.transform.position.z),
                new Quaternion(), this.transform);
                returnEn.increaseSpeed(speedIncrease);
            }
            else if (num < 3)
            {
                Costume returnEn = Object.Instantiate(this.sailor,
                new Vector3(this.transform.position.x,
                this.transform.position.y,
                this.transform.position.z),
                new Quaternion(), this.transform);
                returnEn.increaseSpeed(speedIncrease);
            }
            else if (num < 4)
            {
                Costume returnEn = Object.Instantiate(this.defaultCostume,
                new Vector3(this.transform.position.x,
                this.transform.position.y,
                this.transform.position.z),
                new Quaternion(), this.transform);
                returnEn.increaseSpeed(speedIncrease);
            }
            else if (num < 24)
            {
                int rand = Random.Range(0, enemyPrefab.Count-1);
                EnemyScript returnEn = Object.Instantiate(enemyPrefab[rand],
                new Vector3(this.transform.position.x,
                this.transform.position.y,
                this.transform.position.z),
                new Quaternion(), this.transform);
                returnEn.increaseSpeed(speedIncrease);
            }
            else
            {
                CandyScript returnCan = Object.Instantiate(candyPrefab,
                new Vector3(this.transform.position.x,
                this.transform.position.y,
                this.transform.position.z),
                new Quaternion(), this.transform);
                returnCan.increaseSpeed(speedIncrease);
            }
            timer = cooldown;
        }
        else if (timer < Time.deltaTime)
        {
            timer = 0;
        }
        else 
        {
            timer -= Time.deltaTime;
        }
    }

     
}
