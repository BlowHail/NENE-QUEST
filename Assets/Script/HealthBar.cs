using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthbar;
    public float healthmax;
    public static bool dead = false;
    
    void Update()
    {
         //血条
        healthbar.fillAmount = 1 - (float)playercontrol.hit / healthmax;
    }
    private void FixedUpdate()
    {
        if (playercontrol.hit >= healthmax)
            dead = true;
        else
            dead = false;
    }
}
