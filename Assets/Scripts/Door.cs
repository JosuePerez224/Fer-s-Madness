using UnityEngine;
using DG.Tweening;
public class Door : MonoBehaviour, IInteract
{
    [Header("References")]
    [SerializeField] private bool isOpen;
    [SerializeField] private Vector3 endPos;
    [SerializeField] private Vector3 initPos;
    [SerializeField] private Transform lockInDoor;
    [SerializeField] private AudioSource doorOpen;   
    [SerializeField] private AudioSource doorClose; 
    
    [Header("Variables")] 
    [SerializeField] private Ease ease = Ease.Linear;

    private void Start()
    {
        initPos = transform.rotation.eulerAngles;
        lockInDoor = transform.GetChild(0);
    }

    public void Use()
    {
        lockInDoor.transform.TryGetComponent(out Lock locker);
        isOpen = !isOpen;

        if (locker.IsUnlocked && isOpen)
        {
            doorOpen.Play();
            transform.DORotate(endPos, 0.3f).SetEase(ease);
        }
        else if (locker.IsUnlocked)
        {
            doorClose.Play();
            transform.DORotate(initPos, 0.3f).SetEase(ease);
        }
    }
}
