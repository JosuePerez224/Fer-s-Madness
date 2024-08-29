using System;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class SuggestionManager : MonoBehaviour
{
    [Header("References")]
    public string typeSuggestion;
    public TMP_Text suggRun;
    public TMP_Text suggInteract;
    public TMP_Text suggWasd;
    
    [Header("variables")]
    private Color _colorToShow = new Color(1, 1, 1, 0.8705882f);
    private Color _colorToHide = new Color(1, 1, 1, 0);
    public float timer = 0.0f;
    [SerializeField] private float duration;
    private bool isTriggered;


    private void Update()
    {
        if (isTriggered)
        {
            timer += Time.deltaTime;

            if (isTriggered && timer > duration)
            {
                suggRun.DOColor(_colorToHide, 1.1f).OnComplete(() =>
                {
                    this.gameObject.SetActive(false);
                });
                suggInteract.DOColor(_colorToHide, 1.1f).OnComplete(() =>
                {
                    this.gameObject.SetActive(false);
                });
                suggWasd.DOColor(_colorToHide, 1.1f).OnComplete(() =>
                {
                    this.gameObject.SetActive(false);
                });
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "Player")
        {
            SuggestionToShow(typeSuggestion);
            isTriggered = true;
        }
    }

    private void SuggestionToShow(string suggestion)
    {
        switch (suggestion)
        {
            case "RunSuggestion":
            {
                suggRun.DOColor(_colorToShow, 1.1f);
            }
                break;
            case "InteractSuggestion":
            {
                suggInteract.DOColor(_colorToShow, 1.1f);
            }
                break;
            case "WASD":
            {
                suggWasd.DOColor(_colorToShow, 1.1f);
            }
                break;
        }
    }
}
