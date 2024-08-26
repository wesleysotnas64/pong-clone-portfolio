using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectController : MonoBehaviour
{
    public List<AudioSource> audios; //0 - paddle | 1 - wall | 2 - score

    public void PlayAudio(int audio)
    {
        audios[audio].Play();
    }
}
