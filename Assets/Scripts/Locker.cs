using UnityEngine;
using DG.Tweening;
public class Locker : MonoBehaviour, IInteract
{
    [Header("References")] 
    [SerializeField] private Transform lockerDoorHand;
    [SerializeField] private AudioSource lockerClose;
    private AudioSource _lockerOpen;
    
    [Header("Variables")]
    [SerializeField] private Vector3 endLockerDoor;
    private Vector3 _initLockerDoor;
    private Vector3 _initDoorHandRot;
    private Vector3 _endDoorHandRot;
    private Ease _ease;
    private bool _isOpen;
    private void Start()
    {
        lockerDoorHand = transform.GetChild(0);
        _initDoorHandRot = lockerDoorHand.transform.localRotation.eulerAngles;
        _initLockerDoor = transform.localRotation.eulerAngles;

        _lockerOpen = GetComponent<AudioSource>();
    }

    public void Use()
    {
        _isOpen = !_isOpen;

        if (!_isOpen)
        {
            transform.DOLocalRotate(_initLockerDoor, 0.5f).SetEase(_ease);
            lockerClose.Play();
        }
        
        else
        {
            lockerDoorHand.DOLocalRotate(_endDoorHandRot, 0.5f).SetEase(_ease).OnComplete(() =>
            {
                _lockerOpen.Play(); 
                lockerDoorHand.DOLocalRotate(_initDoorHandRot, 0.3f).SetEase(_ease).OnComplete(()=>
                {
                    transform.DOLocalRotate(endLockerDoor, 0.3f).SetEase(_ease);
                });
            });
        }
    }
}
