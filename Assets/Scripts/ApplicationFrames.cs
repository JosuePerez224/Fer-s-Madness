using System;
using UnityEngine;

public class ApplicationFrames : MonoBehaviour
{
    [SerializeField] private FPS fps;
    private bool isEnabled;
    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isEnabled = !isEnabled;
            fps.enabled = isEnabled;
        }
    }
}
