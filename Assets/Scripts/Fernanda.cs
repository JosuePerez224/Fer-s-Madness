using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
public class Fernanda : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject overPane;
    [SerializeField] private GameObject dot;
    private NavMeshAgent _navMeshAgent;
    private GameObject _player;
    private Image _overPaneImage;
    public AudioSource ferCaught;
    
    [Header("variables")]
    private Color _colorOnOver = new Color(0, 0, 0, 0.8705882f);
    private bool _isOver;
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = GameObject.Find("Player");
        _overPaneImage = overPane.GetComponent<Image>();
    }

    private void Update()
    {
        MoverToDestination();
    }

    private void MoverToDestination()
    {
        _navMeshAgent.destination = _player.transform.position;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.name == "Player")
        {
            _isOver = true;
        }
        IsOver(_isOver);
    }

    private void IsOver(bool isOver)
    {
        if (isOver)
        {
            dot.SetActive(false);
            
            ferCaught.Play();
            
            overPane.SetActive(true);
            
            _overPaneImage.DOColor(_colorOnOver, 0.2f).OnComplete(() =>
            {
                Cursor.lockState = CursorLockMode.None;
                _overPaneImage.DOColor(Color.black, 1f).OnComplete(() =>
                {
                    ButtonsManager.Instance.PauseSounds(true);
                    Time.timeScale = 0.0f;  
                });
            });
        }
    }
}
