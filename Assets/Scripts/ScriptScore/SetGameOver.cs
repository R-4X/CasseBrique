using UnityEngine;

public class SetGameOver : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _currentScorePlayer;


    private void Start()
    {
        SetScore();
    }

    private void SetScore()
    {
        _currentScorePlayer.text = GameManager.Instance.CurentScore.ToString();
    }
}
