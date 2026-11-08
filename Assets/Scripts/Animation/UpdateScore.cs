using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    [Header("Text UI to update")]
    [SerializeField] private TMPro.TextMeshProUGUI _scoreText;
    [SerializeField] private TMPro.TextMeshProUGUI _lifeText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       _scoreText.text = "Score: " + GameManager.Instance.CurentScore.ToString();
        _lifeText.text = "Lives: " + GameManager.Instance.CurrentLives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
