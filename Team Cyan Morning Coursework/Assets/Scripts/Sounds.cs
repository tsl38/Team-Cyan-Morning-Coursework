using System;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class Sounds
{
    //Unity AudioClip reference
    public AudioClip soundClip;
    //Stores the unity AudioSource in a variable.
    [HideInInspector]
    public AudioSource source;

    //Name of the sound.
    public string nameOfSound;

    //Volume of the sound.
    [Range(0f, 1f)]
    public float volume;
    //Pitch of the sound.
    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;
}
