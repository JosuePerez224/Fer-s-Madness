using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ButtonsMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Image image;
    [SerializeField] private Text[] texts;
    private Color _colorOnStart = new Color(0, 0, 0, 0.7294118f);
    private Color _starColor = new Color(0, 0, 0, 1);
    private Color _textColor = new Color(1, 1, 1, 1);
    private Color _textColor2 = new Color(1, 1, 1, 0);

    private void Start()
    {
        image.DOColor(_colorOnStart, 1.5f).OnComplete(() =>
        {
            foreach (var text in texts)
            {
                text.transform.gameObject.SetActive(true);
                text.DOColor(_textColor, 2.5f);
            }
        });
    }

    public void StarGame()
    {
        foreach (var text in texts)
        {
            text.DOColor(_textColor2, 2.5f);
        }
        image.DOColor(_starColor, 1.5f).OnComplete(() =>
        {
            image.DOColor(_starColor, 1.5f).OnComplete(() =>
            {
                SceneManager.LoadScene("Level");
            });
        });
    }

    public void QuitGame()
    {
        foreach (var text in texts)
        {
            text.DOColor(_textColor2, 2.5f);
        }
        image.DOColor(_starColor, 1.5f).OnComplete(() =>
        {
            Application.Quit();
        });
    }
}
