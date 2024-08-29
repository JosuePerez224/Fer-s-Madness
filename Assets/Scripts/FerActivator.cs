using System;
using UnityEngine;

public class FerActivator : MonoBehaviour
{
    [SerializeField] private FernandaManager _fernandaManager;

    private void Awake()
    {
        _fernandaManager = FindObjectOfType<FernandaManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            _fernandaManager.enabled = true;
            transform.gameObject.SetActive(false);
        }
    }
}
