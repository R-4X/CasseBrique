using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private int _curentScore = 0;
    private int _currentLives = 3;
    private int _currentLevel = 1;
    private bool _ballLost = false;

    #region Properties
    public static GameManager Instance
    {
        get { return instance; }
    }

    public int CurentScore { get => _curentScore; set => _curentScore = value; }
    public int CurrentLives { get => _currentLives; set => _currentLives = value; }
    public bool BallLost { get => _ballLost; set => _ballLost = value; }
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

    #region Menu
    public void SelectedLevel()  //string nameLevel
    {
        SceneManager.LoadScene("LevelTuto");
    }

    public void ControlLevel()
    {
        SceneManager.LoadScene("ControlMenu");
    }

    public void EndMenu()
    {
        SceneManager.LoadScene("EndGameMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion Menu
 

    #endregion Methods
}
