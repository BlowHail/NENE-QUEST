using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force; // 1
    public float speed; // 4
    private bool over;
    private float oldsize;
    private bool scale = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        over = false;
    }

    private void FixedUpdate()
    {
        //给火球一个向下的力和一个向左的速度
        rb.velocity = new Vector2(-speed,rb.velocity.y);

        rb.AddForce(Vector2.down * force, ForceMode2D.Impulse);
        //火球拐弯和消失
        if (transform.position.y < -1.5f)
        {
            force = - Mathf.Abs(force);
            over = true;
        }
        if (over && transform.position.y > 0.5)
            Destroy(rb.gameObject);
        scaling();
    }
    //火球缩放
    void scaling()
    {
        if(scale && transform.localScale.x<0.4)
        {
            oldsize = transform.position.y;
            scale = false;
        }
        else if (transform.localScale.x < 0.4)
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.1f * Mathf.Abs(transform.position.y - oldsize), transform.localScale.y + 0.1f * Mathf.Abs(transform.position.y - oldsize), 1);
            scale = true;
        }
    }
}
