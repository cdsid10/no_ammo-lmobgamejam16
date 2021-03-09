using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaber : MonoBehaviour
{
    private Audio _audio;
    
    [SerializeField] private GameObject saber, force;

    public bool saberOn;

    private bool canSaber, canForce;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip[] forceOof;
    // Start is called before the first frame update
    void Start()
    {
        _audio = FindObjectOfType<Audio>();
        _audioSource = GetComponent<AudioSource>();
        canForce = true;
        canSaber = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canSaber)
        {
            saber.SetActive(true);
            saberOn = true;
            canForce = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            saber.SetActive(false);
            saberOn = false;
            canForce = true;
        }
        else if (Input.GetMouseButtonDown(1) && canForce)
        {
            force.SetActive(true);
            StartForce();
            saberOn = false;
            canSaber = false;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            StopForce();
            force.SetActive(false);
            canSaber = true;
        }
    }
    
    public void StartForce()
    {
        _audioSource.clip = forceOof[Random.Range(0,2)];
        _audioSource.Play();
    }

    public void StopForce()
    {
        _audioSource.Stop();
    }
}
