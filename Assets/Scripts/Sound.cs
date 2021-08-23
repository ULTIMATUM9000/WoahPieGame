using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0f, 1f)]
    public float pitch;
    [Range(-1f, 1f)]
    public float panStereo;

    public bool playOnAwake;
    public float minDistance;
    public float maxDistance;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
}