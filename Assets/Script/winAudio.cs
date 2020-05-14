using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winAudio : MonoBehaviour
{
    public AudioSource Aswin;
    private bool play = true;
    //打败boss的时候播放win音乐
    private void FixedUpdate()
    {
        if (boss.bossdead &&play)
        {
            Aswin.Play();
            play = false;
        }
    }
}
