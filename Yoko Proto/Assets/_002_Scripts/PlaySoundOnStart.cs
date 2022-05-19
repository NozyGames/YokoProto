using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{

    [SerializeField] private AudioClip _clip;

    void Start()
    {
        AudioManager.Instance.PlaySound(_clip);
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }
}
