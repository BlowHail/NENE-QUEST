using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playercontrol : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float attacktime;
    public Animator anim;
    public float force;
    public Transform Boss;
    public  static int hit=0;
    private bool ishurt=false;
    private float horizontal;
    private float vertical;
    public AudioSource AS,Aspig;
    public Image gamover;
    private bool attackpress=false;
    void Start()
    {
        hit = 0;
        gamover.fillAmount = 0;
    }

    void Update()
    {
        //攻击
        if (Input.GetButtonDown("Attack"))
            attackpress = true;
        if (HealthBar.dead)
        {
            gamover.fillAmount = 1;
            AS.Pause();
            //Destroy(rb.gameObject);
            Invoke("ReStar", 3f);
            //Time.timeScale = 0;
        }
        if (boss.bossdead)
        {
            AS.Pause();
            Invoke("ReStar", 5f);
        }
    }
    private void FixedUpdate()
    {
        movement();
        attack();
        switchanim();
        BossAttack();
        if(ishurt  )  //被攻击后退
        {
            //rb.velocity = new Vector2(-50, 0);
            rb.AddForce(Vector2.left * force, ForceMode2D.Impulse);
            StartCoroutine(delay());
        }   
    }
    void ReStar() //重新开始游戏
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //用距离判断是否受到boss伤害
    void BossAttack()
    {
        if (Mathf.Abs(rb.transform.position.x - Boss.transform.position.x) < 5.1f)
        {
            ishurt = true;
            hit++;
            HurtAnim();
        }

    }
    IEnumerator delay() //被击延迟（防止被野猪判定多次撞击
    {
        yield return new WaitForSeconds(0.4f);
        ishurt = false;
    }
    void movement() //上下左右移动
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        float size = transform.localScale.x;
        size = Mathf.Abs(size);
        if (horizontal != 0)
            transform.localScale = new Vector3(size*horizontal, size, size);
    }
    void attack() //玩家攻击
    {
        if (attackpress)
        {
            anim.SetBool("attack", true);
            attackpress = false;
            StartCoroutine(starattack());
        }
    }
    IEnumerator starattack()
    {
        yield return new WaitForSeconds(attacktime);
        anim.SetBool("attack", false);
    }
    void switchanim()
    {
        anim.SetFloat("running", Mathf.Abs(rb.velocity.x));
    }
    void HurtAnim()
    {
        anim.SetBool("hurt", true);
        StartCoroutine(HurtAnimDelay());

    }
    IEnumerator HurtAnimDelay()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("hurt", false);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="enemy" &&!ishurt&& ( collision.transform.position.x-rb.transform.position.x)<2f)
        {
            hit+=2;
            ishurt = true;
            HurtAnim();
            Aspig.Play();     //被野猪撞的音效 hit_07
        }
        if(collision.tag=="fire")
        {
            hit++;
            HurtAnim();
            //ishurt = true;
        }
        if (collision.tag == "riceball")
        {
            hit--;
            Destroy(collision.gameObject);
            if (hit < 0)
                hit = 0;
        }
    }

}
