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




    // allow to MAJ the UI of the level name and sprite based on NEW LEVEL UNLOCK 
    private void UpdateUI()
    {
        Debug.Log("Level1Unlock: " + LevelManager.Instance.Level1Unlock);
        if (LevelManager.Instance.Level1Unlock == false && LevelManager.Instance.Level2Unlock == false && LevelManager.Instance.Level3Unlock == false && LevelManager.Instance.Level4Unlock == false && LevelManager.Instance.Level5Unlock == false && LevelManager.Instance.Level6Unlock == false)   //LevelManager.Instance.LevelUnlock[1]
        {
            _textLevel[0].text = _nameTextLevel[0].ToString();
            _imageSpriteLevel[0].image.sprite = _spritesLevel[0];
            LevelManager.Instance.LevelCanLoadLevel = true;
        }

        else if (LevelManager.Instance.Level1Unlock == true && LevelManager.Instance.Level2Unlock == false && LevelManager.Instance.Level3Unlock == false && LevelManager.Instance.Level4Unlock == false && LevelManager.Instance.Level5Unlock == false && LevelManager.Instance.Level6Unlock == false)  //LevelManager.Instance.LevelUnlock[2]
        {
            _textLevel[0].text = _nameTextLevel[0].ToString();
            _imageSpriteLevel[0].image.sprite = _spritesLevel[0];
            _textLevel[1].text = _nameTextLevel[1].ToString();
            _imageSpriteLevel[1].image.sprite = _spritesLevel[1];
            LevelManager.Instance.LevelCanLoadLevel = true;
        }

        else if (LevelManager.Instance.Level1Unlock == true && LevelManager.Instance.Level2Unlock == true && LevelManager.Instance.Level3Unlock == false && LevelManager.Instance.Level4Unlock == false && LevelManager.Instance.Level5Unlock == false && LevelManager.Instance.Level6Unlock == false)
        {
            _textLevel[0].text = _nameTextLevel[0].ToString();
            _imageSpriteLevel[0].image.sprite = _spritesLevel[0];
            _textLevel[1].text = _nameTextLevel[1].ToString();
            _imageSpriteLevel[1].image.sprite = _spritesLevel[1];
            _textLevel[2].text = _nameTextLevel[2].ToString();
            _imageSpriteLevel[2].image.sprite = _spritesLevel[2];
            LevelManager.Instance.LevelCanLoadLevel = true;
        }

        else if (LevelManager.Instance.Level1Unlock == true && LevelManager.Instance.Level2Unlock == true && LevelManager.Instance.Level3Unlock == true && LevelManager.Instance.Level4Unlock == false && LevelManager.Instance.Level5Unlock == false && LevelManager.Instance.Level6Unlock == false)
        {
            _textLevel[0].text = _nameTextLevel[0].ToString();
            _imageSpriteLevel[0].image.sprite = _spritesLevel[0];
            _textLevel[1].text = _nameTextLevel[1].ToString();
            _imageSpriteLevel[1].image.sprite = _spritesLevel[1];
            _textLevel[2].text = _nameTextLevel[2].ToString();
            _imageSpriteLevel[2].image.sprite = _spritesLevel[2];
            _textLevel[3].text = _nameTextLevel[3].ToString();
            _imageSpriteLevel[3].image.sprite = _spritesLevel[3];

            LevelManager.Instance.LevelCanLoadLevel = true;
        }

        else if (LevelManager.Instance.Level1Unlock == true && LevelManager.Instance.Level2Unlock == true && LevelManager.Instance.Level3Unlock == true && LevelManager.Instance.Level4Unlock == true && LevelManager.Instance.Level5Unlock == false && LevelManager.Instance.Level6Unlock == false)
        {
            _textLevel[0].text = _nameTextLevel[0].ToString();
            _imageSpriteLevel[0].image.sprite = _spritesLevel[0];
            _textLevel[1].text = _nameTextLevel[1].ToString();
            _imageSpriteLevel[1].image.sprite = _spritesLevel[1];
            _textLevel[2].text = _nameTextLevel[2].ToString();
            _imageSpriteLevel[2].image.sprite = _spritesLevel[2];
            _textLevel[3].text = _nameTextLevel[3].ToString();
            _imageSpriteLevel[3].image.sprite = _spritesLevel[3];
            _textLevel[4].text = _nameTextLevel[4].ToString();
            _imageSpriteLevel[4].image.sprite = _spritesLevel[4];

            LevelManager.Instance.LevelCanLoadLevel = true;
        }
        else if (LevelManager.Instance.Level1Unlock == true && LevelManager.Instance.Level2Unlock == true && LevelManager.Instance.Level3Unlock == true && LevelManager.Instance.Level4Unlock == true && LevelManager.Instance.Level5Unlock == true && LevelManager.Instance.Level6Unlock == false)
        {
            _textLevel[0].text = _nameTextLevel[0].ToString();
            _imageSpriteLevel[0].image.sprite = _spritesLevel[0];
            _textLevel[1].text = _nameTextLevel[1].ToString();
            _imageSpriteLevel[1].image.sprite = _spritesLevel[1];
            _textLevel[2].text = _nameTextLevel[2].ToString();
            _imageSpriteLevel[2].image.sprite = _spritesLevel[2];
            _textLevel[3].text = _nameTextLevel[3].ToString();
            _imageSpriteLevel[3].image.sprite = _spritesLevel[3];
            _textLevel[4].text = _nameTextLevel[4].ToString();
            _imageSpriteLevel[4].image.sprite = _spritesLevel[4];
            _textLevel[5].text = _nameTextLevel[5].ToString();
            _imageSpriteLevel[5].image.sprite = _spritesLevel[5];
            LevelManager.Instance.LevelCanLoadLevel = true;
        }
        else if (LevelManager.Instance.Level1Unlock == true && LevelManager.Instance.Level2Unlock == true && LevelManager.Instance.Level3Unlock == true && LevelManager.Instance.Level4Unlock == true && LevelManager.Instance.Level5Unlock == true && LevelManager.Instance.Level6Unlock == false)
        {
            Debug.Log("All levels unlocked");
        }
        }


    // Allow to references name of level in the button 
    public void UpdateLevelUI(string name)
    {

        if (LevelManager.Instance.LevelCanLoadLevel)
        {
            Debug.Log("Loading level: " + name);
            LevelManager.Instance.LevelCanLoadLevel = false;
            SceneManager.LoadScene(name);
        }
        else
        {
            Debug.Log("Level is locked. Cannot load level: " + name);
        }
        
    }

    private void Start()
    {
        UpdateUI();
    }
    private void Update()
    {
    }
}
