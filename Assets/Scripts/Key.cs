using UnityEngine;
using DG.Tweening;

public class Key : MonoBehaviour , IInteract
{
    
    [Header("References")]
    private GameObject _hand;
    private Rigidbody _rb;
    private AudioSource _keyPickUp;
    
    [Header("Variables")]
    [SerializeField] private Vector3 endRot;
    [SerializeField] private Ease ease;
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private string keyCode;
    private bool _isCollected;
    private Vector3 _scale;
    public string KeyCode => keyCode;

    private void Start()
    {
        _hand = GameObject.Find("hand");
        _rb = GetComponent<Rigidbody>();
        _scale = transform.localScale;
        _keyPickUp = GetComponent<AudioSource>();
    }

    public void Use()
    {
        _keyPickUp.Play();
        _isCollected = !_isCollected;
        
        transform.SetParent(_hand.transform);
        transform.localScale = _scale;
        endRot = new Vector3(_hand.transform.eulerAngles.x, 100, -45);
            
        if (_isCollected)
        {
            transform.DOLocalRotate(endRot, duration).SetEase(ease);
            transform.DOMove(_hand.transform.position, duration).SetEase(ease).OnComplete(()=>
            {
                _rb.isKinematic = true;
                _isCollected = !_isCollected;
                FixTransForm();
            });    
        }
    }

    private void FixTransForm()
    {
        endRot = new Vector3(0, 100, -45);
        transform.position = _hand.transform.position;
        transform.localEulerAngles = endRot;
    }
}
