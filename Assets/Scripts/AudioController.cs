using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource[] ScarySounds;
    public AudioSource[] Whispers;
    public AudioSource HeartBeat;
    int x = 0;
    int y = 0;

    float timer;

    void Start()
    {
        HeartBeat.Play();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 30)
        {
            Whispers[x++].Play();
            if (x == 9) x = 0;
            timer = 0;
        }
    }
}
