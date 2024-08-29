using UnityEngine;
using DG.Tweening;
public class Lock : MonoBehaviour, IInteract
{
    [Header("References")] 
    [SerializeField] private GameObject hand;
    [SerializeField] private Transform objectHand;
    private AudioSource _keyOpening;
    
    [Header("Variables")] 
    [SerializeField] private Ease ease;
    [SerializeField] private Transform padlock;
    [SerializeField] private string lockCode;
    [SerializeField] private Vector3 strengt;
    private Vector3 _endPos;
    private float _duration = 0.2f;
    private bool isUnlocked;
    public bool IsUnlocked => isUnlocked;

    private void Start()
    {
        hand = GameObject.Find("hand");
        _endPos = new Vector3(0, 0.03f, 0);
        padlock = transform.GetChild(0);
        _keyOpening = GetComponent<AudioSource>();
    }

    public void Use()
    {
        objectHand = hand.transform.GetChild(0);
        objectHand.transform.TryGetComponent(out Key key);

        if (lockCode != key.KeyCode) return;
        _keyOpening.Play();
        padlock.DOLocalMove(_endPos, _duration).SetEase(ease).OnComplete(() =>
        {
            transform.DOShakeRotation(2f, strengt).OnComplete(() =>
            {
                transform.DOMoveY(-1f, .5f).SetEase(ease).OnComplete(() =>
                {
                    transform.gameObject.SetActive(false);
                });
                isUnlocked = true;
            });
        });
    }
}
