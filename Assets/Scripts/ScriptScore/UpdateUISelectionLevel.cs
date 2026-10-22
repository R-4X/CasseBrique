using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpdateUISelectionLevel : MonoBehaviour
{

    // UI MAJ needs
    [SerializeField] private string[] _nameTextLevel;  // player name of level
    [SerializeField] private Sprite[] _spritesLevel;
    // Reference to the UI Text and SpriteRenderer for updating the level name and sprite
    [SerializeField] private Button[] _imageSpriteLevel;
    [SerializeField] private TMPro.TMP_Text[] _textLevel;
    private string _currentLevelName = "TutoLevel";



    // allow to MAJ the UI of the level name and sprite based on NEW LEVEL UNLOCK 
    private void UpdateUI()
    {
        //    switch (_currentLevelIndexUnlock)
        //    {
        //        case 0:
        //            LevelUnlock[0] = true;
        //            break;
        //        case 1:
        //            LevelUnlock[1] = true;
        //            break;
        //        case 2:
        //            LevelUnlock[2] = true;
        //            break;
        //        case 3:
        //            LevelUnlock[3] = true;
        //            break;
        //        case 4:
        //            LevelUnlock[4] = true;
        //            break;
        //        case 5:
        //            LevelUnlock[5] = true;
        //            break;
        //        default:
        //            Debug.LogWarning("Invalid level index: " + _currentLevelIndexUnlock);
        //            break;
        //    }

        if (LevelManager.Instance.LevelUnlock[1])
        {
            _textLevel[0].text = _nameTextLevel[0].ToString();
            _imageSpriteLevel[0].image.sprite = _spritesLevel[0];
            _currentLevelName = "LevelTuto";
            if (LevelManager.Instance.LevelUnlock[2])
            {
                _textLevel[1].text = _nameTextLevel[1].ToString();
                _imageSpriteLevel[1].image.sprite = _spritesLevel[1];
                _currentLevelName = "MainMenu";
                if (LevelManager.Instance.LevelUnlock[3])
                {
                    _textLevel[2].text = _nameTextLevel[2].ToString();
                    _imageSpriteLevel[2].image.sprite = _spritesLevel[2];
                    _currentLevelName = "MainMenu";
                    if (LevelManager.Instance.LevelUnlock[4])
                    {
                        _textLevel[3].text = _nameTextLevel[3].ToString();
                        _imageSpriteLevel[3].image.sprite = _spritesLevel[3];
                        _currentLevelName = "MainMenu";
                        if (LevelManager.Instance.LevelUnlock[5])
                        {
                            _textLevel[4].text = _nameTextLevel[4].ToString();
                            _imageSpriteLevel[4].image.sprite = _spritesLevel[4];
                            _currentLevelName = "MainMenu";
                            if (LevelManager.Instance.LevelUnlock[6])
                            {
                                _textLevel[5].text = _nameTextLevel[5].ToString();
                                _imageSpriteLevel[5].image.sprite = _spritesLevel[5];
                                _currentLevelName = "MainMenu";
                            }
                        }
                    }
                }
            }
        }
    }


    // Allow to references name of level in the button 
    public void UpdateLevelUI()
    {
        SceneManager.LoadScene(_currentLevelName);
    }

    private void Start()
    {
        LevelManager.Instance.LevelUnlock[1] = true;
        LevelManager.Instance.LevelUnlock[LevelManager.Instance.CurrentLevelIndexUnlock] = true;
        UpdateUI();
    }
    private void Update()
    {
        UpdateUI();
    }
}
