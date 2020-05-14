using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wildpig : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    public float speed;
  
    void Update()
    {
        
    }
    //野猪的位置刷新到和玩家一条线上，向前冲撞
    private void FixedUpdate()
    {
        if(rb.transform.position.x-player.transform.position.x<20)
        {
            if (rb.transform.position.x - player.transform.position.x > 18)
                rb.transform.position = new Vector3(rb.position.x, player.transform.position.y, 0);
            else if (rb.transform.position.x - player.transform.position.x < 18)
                rb.velocity = new Vector2(-speed, 0);
        }
        if (rb.transform.position.x - player.transform.position.x < -8)
            Destroy(rb.gameObject);
    }
}
