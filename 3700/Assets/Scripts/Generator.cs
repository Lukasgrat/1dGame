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
    Player p;
    int speedIncrease;
    int hasIncreasedSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        speedIncrease = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (p.getScore() > 2000 && hasIncreasedSpeed == 0)
        {
            hasIncreasedSpeed = 1;
            speedIncrease = 3;
            timer = 4;
            cooldown = cooldown * 3 / 4;
        }
        else if (p.getScore() > 4000 && hasIncreasedSpeed == 1)
        {
            hasIncreasedSpeed = 2;
            speedIncrease += 3;
            timer = 4;
            cooldown = cooldown * 3 / 4;
        }
        else if (p.getScore() > 8000 && hasIncreasedSpeed == 2)
        {
            hasIncreasedSpeed = 3;
            speedIncrease += 3;
            timer = 4;
            cooldown = cooldown * 3 / 4;
        }


        if (timer == 0)
        {
            int num = Random.Range(0, 10);
            if (num < 4)
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
