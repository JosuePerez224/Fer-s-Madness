using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonsMenuManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text[] texts;
    [SerializeField] private AudioSource laugh;
    [SerializeField] private RawImage ferImage;
    [SerializeField] private Texture[] ferTexture;
    
    [Header("Variables")]
    private Color _colorOnStart = new Color(0, 0, 0, 0.682353f);
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

    public void Options()
    {
        laugh.Play();
        
        int i = Random.Range(0, ferTexture.Length);
        
        ferImage.texture = ferTexture[i];

        ferImage.DOFade(1, 2.5f).OnComplete(() =>
        {
            ferImage.DOFade(0, 2.5f);
        });
    }

    public void QuitGame()
    {
        foreach (var text in texts)
        {
            text.DOColor(_textColor2, 2.5f);
        }
        image.DOColor(_starColor, 2.8f).OnComplete(() =>
        {
            Application.Quit();
        });
    }
}
