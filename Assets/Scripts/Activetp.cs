using UnityEngine;

public class Activetp : MonoBehaviour
{
    [SerializeField] private Vector3 endPos;
    [SerializeField] private GameObject currentTp;

    private void Start()
    {
        endPos = new Vector3(0, 1.125f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentTp.SetActive(true);
        currentTp.transform.localPosition = endPos;
    }
}
