using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    float cooldown;
    float timer;
    [SerializeField]
    CandyScript candyPrefab;
    [SerializeField]
    EnemyScript enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer == 0)
        {
            int num = Random.Range(0, 10);
            if (num < 3)
            {
                Object.Instantiate(enemyPrefab,
                new Vector3(this.transform.position.x,
                this.transform.position.y,
                this.transform.position.z),
                new Quaternion(), this.transform);
            }
            else
            {
                Object.Instantiate(candyPrefab,
                new Vector3(this.transform.position.x,
                this.transform.position.y,
                this.transform.position.z),
                new Quaternion(), this.transform);
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
