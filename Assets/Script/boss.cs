using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class boss : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject player;
    public float speed;
    public Transform left, right;
    public int helth;
    public static int hit = 0;
    private int hurt=0;
    public Image win;
    public GameObject fire;
    public static bool ishurt;
    private bool arrowleft;

    public static bool bossdead=false;
    // Start is called before the first frame update
    void Start()
    {
        arrowleft = true;
        ishurt = false;
        transform.DetachChildren();
        InvokeRepeating("Fire", 5, 10f);  //boss 10秒喷一次火
        win.fillAmount = 0;
        hit = 0;
        bossdead = false;
    }
    private void Update()
    {
        Health();
    }
    void FixedUpdate()
    {
        Movement();
        
    }
    void Health() //血量检测
    {
        if (hurt < hit)
        {
            hurt = hit;
            anim.SetBool("hurt", true);
        }
        else
            anim.SetBool("hurt", false);
        //helth = hit;
        if (helth <= hit)
        {
            win.fillAmount = 1;
            Destroy(rb.gameObject);
            bossdead = true;
        }
    }
    void Movement() //左右移动
    {
        if (arrowleft)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (transform.position.x < left.transform.position.x)
                arrowleft = false;
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > right.transform.position.x)
                arrowleft = true;
        }
      
    }
    //喷火方式，一次喷两个火球，间隔0.7秒再喷一次，一共喷三次
    // 如果有dalao有更好的方式请告诉我 _(:з」∠)_
    void Fire() 
    {
        anim.SetBool("fire", true);
        float sizex, x;

        x = Random.Range(0, 100);
        x /= 100f;
        sizex = transform.position.x - 6.5f + x;
        Instantiate(fire, fire.transform.position = new Vector3(sizex, 3.55f, 0), transform.rotation);

        StartCoroutine(SecondFire());

        x = Random.Range(0, 100);
        x /= 100f;
        sizex = transform.position.x - 6.5f + x;
        Instantiate(fire, fire.transform.position = new Vector3(sizex, 3.55f, 0), transform.rotation);

    }
IEnumerator SecondFire()
    {
        yield return new WaitForSeconds(0.7f);
        float sizex, x;

        x = Random.Range(0, 100);
        x /= 100f;
        sizex = transform.position.x - 6.5f + x;
        Instantiate(fire, fire.transform.position = new Vector3(sizex, 3.55f, 0), transform.rotation);

        x = Random.Range(0, 100);
        x /= 100f;
        sizex = transform.position.x - 6.5f + x;
        Instantiate(fire, fire.transform.position = new Vector3(sizex, 3.55f, 0), transform.rotation);
        StartCoroutine(ThirdFire());

    }
    IEnumerator ThirdFire()
    {
        yield return new WaitForSeconds(0.7f);
        float sizex, x;

        x = Random.Range(0, 100);
        x  /= 100f;
        sizex = transform.position.x - 6.5f + x;
        Instantiate(fire, fire.transform.position = new Vector3(sizex, 3.55f, 0), transform.rotation);

        x = Random.Range(0, 100);
        x /= 100f;
        sizex = transform.position.x - 6.5f + x;
        Instantiate(fire, fire.transform.position = new Vector3(sizex, 3.55f, 0), transform.rotation);
        anim.SetBool("fire", false);

    }

}
