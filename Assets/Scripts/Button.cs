using UnityEngine;
using DG.Tweening;
public class Button : MonoBehaviour, IInteract
{
    [Header("References")] 
    [SerializeField] private GameObject wallDrebi;
    [SerializeField] private Transform button;
    [SerializeField] private AudioSource buttonPress;
    [SerializeField] private AudioSource wallBreak;

    [Header("Variables")] 
    private float _initPos;
    private bool _isEnabled;
    private void Start()
    {
        wallDrebi = GameObject.Find("Empty.003");
        button = transform.GetChild(0);
        buttonPress = GetComponent<AudioSource>();
        _initPos = button.transform.localPosition.z;
    }

    public void Use()
    {
        if (_isEnabled) return;
        buttonPress.Play();
        button.transform.DOLocalMoveZ(0.08f, 0.2f).SetEase(Ease.InOutCubic).OnComplete(() =>
        {
            button.transform.DOLocalMoveZ(_initPos, 0.1f).SetEase(Ease.InOutCubic);
            wallBreak.Play();
            wallDrebi.SetActive(false);
            _isEnabled = true;
        });
    }
}
