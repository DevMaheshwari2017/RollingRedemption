using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField]
    private int MainMenu = 0;
    [SerializeField]
    private int Gameplay = 1;

    public bool IsIntialized { get; set; }
    public int CurrentScore { get; set; }

    private string Highscorekey = "HighScore";

    public int HighScore
    {
        get
        {
            return PlayerPrefs.GetInt(Highscorekey, 0);
        }
        set
        {
            PlayerPrefs.SetInt(Highscorekey, value);
        }
    }
    private void Init()
    {
        CurrentScore = 0;
        IsIntialized = false;
    }


    public void GoToMainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void GoToGameplay()
    {
        SceneManager.LoadScene(Gameplay);
    }
}
