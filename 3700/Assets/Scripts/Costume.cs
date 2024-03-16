using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Costume : MonoBehaviour
{
    [SerializeField]
    Class costume;
    [SerializeField]
    bool isVertical;
    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
  
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;
        if (isVertical)
        {
            this.transform.position = new Vector3(pos.x, pos.y - Time.deltaTime * speed, pos.z);
        }
        else
        {
            this.transform.position = new Vector3(pos.x - Time.deltaTime * speed, pos.y, pos.z);

        }
    }

    //Increases the speed of this enemy
    public void increaseSpeed(int amount)
    {
        this.speed += amount;
    }

    public Class getCostume() { return costume; }
}
