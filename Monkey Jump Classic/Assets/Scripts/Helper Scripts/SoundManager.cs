using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip jumpclip, gameoverclip;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    public void JumpSoundFX()
    {
        soundFX.clip = jumpclip;
        soundFX.Play();
    }

    public void GameOverSoundFX()
    {
        soundFX.clip = gameoverclip;
        soundFX.Play();
    }
}
