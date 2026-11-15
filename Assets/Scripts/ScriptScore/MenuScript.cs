using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void UpdateLevelUI()
    {
        SceneManager.LoadScene("SelectLevelMenu");
    }

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
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("SelectLevelMenu");
    }

    public void GoMainMenu()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void LinkExterne(string nameLink)
    {
        Application.OpenURL(nameLink);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
