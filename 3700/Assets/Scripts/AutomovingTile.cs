using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomovingTile : MonoBehaviour
{
    [SerializeField]
    bool isVertical;
    Vector3 originalPosition;
    [SerializeField]
    float timer = 0f;
    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        this.originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;
        if (isVertical)
        {
            this.transform.position = new Vector3(pos.x, this.originalPosition.y - this.timer * speed, pos.z);

        }
        else
        {
            this.transform.position = new Vector3(this.originalPosition.x - this.timer * speed, pos.y , pos.z);

        }
        timer = (timer + Time.deltaTime) % 10;
    }
}
