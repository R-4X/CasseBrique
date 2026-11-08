using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private Sprite[] _stateSprite;
    [SerializeField] private int _health = 1;
    [SerializeField] private int _score = 100;
    [SerializeField] private TMPro.TMP_Text _scoreText = null;

    [Header("Animation")]
    [SerializeField] private Animator _scoreAnimator;

    [Header("sprite")]
    [SerializeField] private SpriteRenderer _spriteRenderer = null;
    private bool _breakable = true;

    #region properties fields
    public int Health { get => _health; set => _health = value; }
    public Sprite[] StateSprite { get => _stateSprite; set => _stateSprite = value; }
    #endregion properties fields


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!_breakable)
        {Debug.LogWarning("Brick is not breakable, please set the breakable property to true.");
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            GameManager.Instance.CurrentCombo++;
            GameManager.Instance.BrickDeathCount += 1;
            _scoreAnimator.SetTrigger("PlayAnimation");
            if (_breakable)
            {
                this.Health--;
                if (this.Health <= 0)
                {
                    AddScore();
                    Destroy(this.gameObject);
                }
                else
                {
                    this._spriteRenderer.sprite = this._stateSprite[this.Health-1];
                    Debug.Log("Brick health: " + this.Health);
                }
            }

            if (GameManager.Instance.BrickDeathCount >= LevelManager.Instance.NbrBrickToBreak)
            {
                if (LevelManager.Instance.Level1Unlock == false)
                {
                    LevelManager.Instance.Level1Unlock = true;
                    LoadLevelIndex();
                }
                else if (LevelManager.Instance.Level1Unlock == true && LevelManager.Instance.Level2Unlock == false)
                {
                    LevelManager.Instance.Level2Unlock = true;
                    LoadLevelIndex();
                }
            }
        }
    }

    private void LoadLevelIndex()
    {
        GameManager.Instance.WonMenu();
    }

    private void AddScore()
    {
        Debug.Log(_score);
        GameManager.Instance.CurentScore += _score;
        _scoreText.text = GameManager.Instance.CurentScore.ToString();
        //_scoreAnimator.SetTrigger("PlayAnimation");
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
