using UnityEngine;

public class HallTp : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject targetTp;
    [SerializeField] private Vector3 playerPositionTouched;
    [SerializeField] private Vector3 targetPositionToTp;
    [SerializeField] private Vector3 currentPositionToTp;
    
    private void Start()
    {
        targetPositionToTp = new Vector3(0, 1.38f, 0.7f);
        currentPositionToTp = new Vector3(0, 1.38f, 0);
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        targetTp.transform.localPosition = targetPositionToTp;
        transform.localPosition = currentPositionToTp;
       
        player.transform.position = targetTp.transform.position;
       
        targetTp.SetActive(false);
        this.gameObject.SetActive(false);
    }
    
    //CODE FUNCTIONAL ABOUT TP, BUT WITH THE ERROR OF TELEPORT AT THE CENTER
    // //player.transform.position = bx.transform.position;
    // targetTp.transform.localPosition = targetPositionToTp;
    // transform.localPosition = currentPositionToTp;
    //
    // player.transform.position = targetTp.transform.position;
    //
    // targetTp.SetActive(false);
    // this.gameObject.SetActive(false);
}
