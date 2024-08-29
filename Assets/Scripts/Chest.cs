using UnityEngine;
using DG.Tweening;
public class Chest : MonoBehaviour, IInteract
{
    [Header("References")]
    [SerializeField] private Transform lockInChest;
    [SerializeField] private Transform doorChest;
    private AudioSource _toolBoxOpen;
    
    [Header("Variables")] 
    [SerializeField] private Ease ease = Ease.Linear;
    [SerializeField] private float duration = 2.3f;
    [SerializeField] private Vector3 endRot;


    private void Start()
    {
        doorChest = transform.GetChild(0);
        lockInChest = transform.GetChild(1);
        _toolBoxOpen = GetComponent<AudioSource>();
    }

    public void Use()
    {
        lockInChest.transform.TryGetComponent(out Lock locker);

        if (locker.IsUnlocked) doorChest.DOLocalRotate(endRot, duration).SetEase(ease);
        else return;
        _toolBoxOpen.Play();
    }
}