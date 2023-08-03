using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bgSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip backgroundSound;
    private AudioSource _audioSource;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = backgroundSound;
        StartCoroutine(_bgSound(4));
    }
    IEnumerator _bgSound(int delay)
    {
        yield return new WaitForSeconds(delay);
        _audioSource.Play();
    }
}
