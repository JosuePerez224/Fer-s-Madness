using System;
using UnityEngine;


public class AmbientMusic : MonoBehaviour
{
    [SerializeField] private AudioSource backroomsAmbient;
    [SerializeField] private AudioSource ambientPulse;
    [SerializeField] private AudioSource initGameSound;
   

    private bool _isEnabled;
    public bool IsEnabled => _isEnabled;

    private void Start()
    {
        backroomsAmbient.loop = true;
        backroomsAmbient.Play();
        initGameSound.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player")
        {
            ambientPulse.Play();
            _isEnabled = true;
        }
    }
}
