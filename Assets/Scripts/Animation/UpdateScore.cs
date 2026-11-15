using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    [Header("Text UI to update")]
    [SerializeField] private TMPro.TMP_Text _scoreText;
    [SerializeField] private TMPro.TMP_Text _lifeText;


    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "Score: " + GameManager.Instance.CurentScore.ToString();
        _lifeText.text = "Lives: " + GameManager.Instance.CurrentLives.ToString();

    }
}
