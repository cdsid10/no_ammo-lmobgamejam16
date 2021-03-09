using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] private AudioClip[] _audioClip;

    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayHealthIncrease()
    {
        _audioSource.PlayOneShot(_audioClip[0],0.35f);
    }
    
    public void PlayHealthDecrease()
    {
        _audioSource.PlayOneShot(_audioClip[1], 0.25f);
    }
    
    public void PlayHighScore()
    {
        _audioSource.PlayOneShot(_audioClip[2], 0.1f);
    }

    public void Hit()
    {
        _audioSource.pitch = (Random.Range(0.7f, 1.3f));
        _audioSource.PlayOneShot(_audioClip[Random.Range(3, 7)], 0.25f);
    }

    
}
