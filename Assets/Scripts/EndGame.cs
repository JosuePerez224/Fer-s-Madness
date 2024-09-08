using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EndGame : MonoBehaviour
{
    [Header("References")] 
    [SerializeField]private GameObject dot;
    private GameObject _winPane;
    private Image _winPaneImage;
    private Color _colorOnWin = new Color(0, 0, 0, 0.8705882f);

    private void Start()
    {
        _winPane = GameObject.Find("WinPane");
        _winPaneImage = _winPane.GetComponent<Image>();
        _winPane.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.name == "Player")
        {
            dot.SetActive(false);
            _winPane.SetActive(true);
            _winPaneImage.DOColor(_colorOnWin, 0.2f).OnComplete(() =>
            {
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0.0f;
            });
        }
    }
}
