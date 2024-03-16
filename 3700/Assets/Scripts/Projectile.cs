using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    bool isVertical;
    [SerializeField]
    float speed;
    Player player;
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
            this.transform.position = new Vector3(pos.x, pos.y + Time.deltaTime * speed, pos.z);
        }
        else
        {
            this.transform.position = new Vector3(pos.x + Time.deltaTime * speed, pos.y, pos.z);

        }
    }

    //Collisions this bullet and the collider to explode
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CandyScript c))
        {
            this.player.changeScore(-30);
            Object.Destroy(c.gameObject);
        }
        else if (collision.gameObject.TryGetComponent(out EnemyScript e))
        {

            Object.Destroy(e.gameObject);
        }
        else if (collision.gameObject.TryGetComponent(out Costume cost))
        {

            Object.Destroy(cost.gameObject);
        }
        Object.Destroy(this.gameObject);
    }

    //sets the player that created this bubble
    public void setPlayer(Player player) 
    {
        this.player = player;
    }
}
