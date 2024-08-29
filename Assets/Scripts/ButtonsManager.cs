using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ButtonsManager : MonoBehaviour
{
    public static ButtonsManager Instance;
    
    [Header("References")] 
    [SerializeField] private AudioSource laugh;
    [SerializeField] private AmbientMusic ambientMusic;
    [SerializeField] private Texture[] ferTexture;
    [SerializeField] private RawImage ferImage;
    [SerializeField] private GameObject dot;
    private GameObject _pausePanel;
    private GameObject _overPanel;
    private GameObject _startPanel;
    private Image _pauseImage;
    private Image _startImage;
    
    [Header("Variables")]
    private Color _colorOnPause = new Color(0, 0, 0, 0.8705882f);
    private Color _initColor = new Color(0, 0, 0, 0);
    private bool _isPause;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        _pausePanel = GameObject.Find("PausePanel");
        _overPanel = GameObject.Find("OverPane");
        _startPanel = GameObject.Find("StartPanel");
        ambientMusic = FindObjectOfType<AmbientMusic>();
        
        _pauseImage = _pausePanel.GetComponent<Image>();
        _startImage = _startPanel.GetComponent<Image>();
        laugh = _pausePanel.GetComponentInChildren<AudioSource>();
        
        _pausePanel.SetActive(false);
        _overPanel.SetActive(false);
    }

    private void Start()
    {
        _startImage.DOColor(_initColor, 4.5f).OnComplete(() =>
        {
            _startPanel.SetActive(false);
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPause = !_isPause;
            dot.SetActive(false);
            PauseSounds(_isPause);
            if (_isPause)
            {
                _pausePanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                laugh.Pause();
                _pauseImage.DOColor(_colorOnPause, 0.5f).OnComplete(() =>
                {
                    Time.timeScale = 0.0f;
                });
            }else Resume();
        }
    }

    public void Resume()
    { 
        Time.timeScale = 1.0f;
        _isPause = false;
        dot.SetActive(true);
        PauseSounds(_isPause);
        Cursor.lockState = CursorLockMode.Locked;
        _pauseImage.DOColor(_initColor, 0.2f).OnComplete(() =>
        {
            _pausePanel.SetActive(false);
        });
    }

    public void Options()
    {
        Time.timeScale = 1.0f;

        laugh.Play();
        
        
        int i = Random.Range(0, ferTexture.Length);
        
        Debug.Log(i);
        ferImage.texture = ferTexture[i];
        
        ferImage.DOFade(1, 2.5f).OnComplete(() =>
        {
            ferImage.DOFade(0, 2.5f).OnComplete(() =>
            {
                Time.timeScale = 0.0f;
            }); 
        });
    }
    public void Retry()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level");
    }

    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
    public void PauseSounds(bool isPaused)
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();

        
        if (isPaused)
        {
            foreach (var audioSource in audioSources)
            {
                if(audioSource.isPlaying) audioSource.Pause();
            }
        }
        else
        {
            foreach (var audioSource in audioSources)
            {
                if(audioSource.playOnAwake) audioSource.Play();
                
                if (audioSource.clip.name == "AmbientPulseLoop" && ambientMusic.IsEnabled)
                {
                    audioSource.Play();
                }
            }
        }
    }
}
