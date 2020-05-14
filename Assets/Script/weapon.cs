using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class weapon : MonoBehaviour
{
    public Animator anim;
    public float attacktime;
    public Collider2D Collider2D;
    public AudioSource AS;
    private bool attackpress = false;
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetButtonDown("Attack"))
            attackpress = true;
    }
    private void FixedUpdate()
    {
        attack();
    }
    void attack()
    {
        if(attackpress)
        {
            anim.SetBool("attack", true);
            attackpress = false;
            AS.Play();
            StartCoroutine(starattack()); //延迟关闭攻击动画
        }
    }
    IEnumerator starattack()
    {
        Collider2D.enabled = true;
        yield return new WaitForSeconds(attacktime);
        
        anim.SetBool("attack", false);
        StartCoroutine(hitbox());           //延迟关闭武器的 Collider 2D
    }
    IEnumerator hitbox()
    {
        yield return new WaitForSeconds(attacktime);
        Collider2D.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 碰到野猪直接杀死，碰到boss伤害+1（boss.hit记录伤害）
        if (collision.tag == "enemy" && Collider2D.enabled == true)
            Destroy(collision.gameObject);
        if (collision.tag == "boss" && Collider2D.enabled == true)
            boss.hit++;
    }
}
