using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private Sprite[] _stateSprite;
    [SerializeField] private int _health = 1;
    [SerializeField] private int _score = 100;
    [SerializeField] private TMPro.TMP_Text _scoreText = null;

    private SpriteRenderer _spriteRenderer = null;
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
            // this.Health = this.StateSprite.Length;
            //this._spriteRenderer.sprite = this._stateSprite[this.Health-1];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
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
                    this._spriteRenderer.sprite = this._stateSprite[this.Health - 1];
                }
            }
        }
    }

    private void AddScore()
    {
        Debug.Log(_score);
        GameManager.Instance.CurentScore += _score;
        _scoreText.text = GameManager.Instance.CurentScore.ToString();
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
