using System;
using UnityEngine;

namespace Character
{
    public class Interaction : MonoBehaviour
    {
        [SerializeField] private float rayDistance = 1f;
        [SerializeField] private int layerInteract;
        private Transform _camera;
        private GameObject _hand;
        private Rigidbody _handRb;
        
        private void Start()
        {
            _camera = transform.Find("CameraPlayer");
            _hand = GameObject.Find("hand");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                RaycastHit hit;
                Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, rayDistance);

                if (hit.collider.gameObject.layer != layerInteract) return;
                hit.transform.TryGetComponent(out IInteract interact);
                interact.Use();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                try
                {
                    _handRb = _hand.GetComponentInChildren<Rigidbody>();
                }catch (NullReferenceException e)
                {
                    Debug.Log(e);
                }

                _handRb.isKinematic = false;
                _hand.transform.DetachChildren();
            }
        }
    }
}