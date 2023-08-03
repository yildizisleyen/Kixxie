using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;
    public static AudioClip openSound, meowSound;
    static AudioSource _audioSource;
    
    public static SoundManager Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        openSound = Resources.Load<AudioClip>("OpenSound");
        meowSound = Resources.Load<AudioClip>("meow");
    }
    public static void playSound(string clip)
    {
        switch (clip)
        {
            case "OpenScene":
                _audioSource.PlayOneShot(openSound);
                break;
            case "Meow":
                _audioSource.PlayOneShot(meowSound);
                break;
        }
    }
}
