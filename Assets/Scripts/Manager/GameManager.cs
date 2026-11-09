using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private int _curentScore = 0;
    private int _currentLives = 3;
    private string _currentLevel = "TutoLevel";
    private int _currentCombo = 0;
    private int _brickDeathCount = 0;
    private bool _ballLost = false;

    #region Properties
    public static GameManager Instance
    {
        get { return instance; }
    }

    public int CurentScore { get => _curentScore; set => _curentScore = value; }
    public int CurrentLives { get => _currentLives; set => _currentLives = value; }
    public bool BallLost { get => _ballLost; set => _ballLost = value; }
    public int CurrentCombo { get => _currentCombo; set => _currentCombo = value; }
    public int BrickDeathCount { get => _brickDeathCount; set => _brickDeathCount = value; }
    #endregion Properties


    #region Methods
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // supprime une instance précédente
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // conserve l'objet entre scènes
    }

    private void Start()
    {
        BrickDeathCount = 0;
    }

    #region Menu
    public void SelectedLevel()  //string nameLevel
    {
        SceneManager.LoadScene("LevelTuto");
    }

    public void ControlLevel()
    {
        SceneManager.LoadScene("ControlMenu");
    }

    public void GoSelectionLevel()
    {
        ResetGame();
        SceneManager.LoadScene("SelectLevelMenu");
    }

    public void EndMenu()
    {
        ResetGame();
        SceneManager.LoadScene("EndGameMenu");
    }
    public void WonMenu()
    {
        SceneManager.LoadScene("WonMenu");
    }
    public void LinkExterne(string nameLink)
    {
        Application.OpenURL(nameLink);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion Menu
 
    private void ResetGame()
    {
        _curentScore = 0;
        _currentLives = 3;
        _currentCombo = 0;
        _brickDeathCount = 30;
    }

    public void AddScore()
    {
        _curentScore += 100;
    }

    public void LoseLife()
    {
        _currentLives--;
        if (_currentLives <= 0)
        {
            EndMenu();
        }
    }
    #endregion Methods
}
