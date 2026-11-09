using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    [Header("Text UI to update")]
    [SerializeField] private TMPro.TMP_Text _scoreText;
    [SerializeField] private TMPro.TMP_Text _lifeText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "Score: " + GameManager.Instance.CurentScore.ToString();
        _lifeText.text = "Lives: " + GameManager.Instance.CurrentLives.ToString();

    }
}
