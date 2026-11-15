using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour
{
    #region attributs fields
    [Header("Metrics")]
    [SerializeField] private Sprite[] _stateSprite;
    [SerializeField] private int _health = 1;
    [SerializeField] private int _score = 100;
    [SerializeField] private TMPro.TMP_Text _scoreText = null;

    [Header("Animation")]
    [SerializeField] private Animator _scoreAnimator;
    [SerializeField] private Animator _endAnimator;
    [SerializeField] private Animator _badEndAnimator;
    [SerializeField] private GameObject _particuleEffectDestroy;

    [Header("sprite")]
    [SerializeField] private SpriteRenderer _spriteRenderer = null;
    private bool _breakable = true;

    [Header("Sound")]
    [SerializeField] private AudioClip _scoringSound;
    [SerializeField] private AudioClip _starSound;
    [SerializeField] private AudioClip _windSound;
    [SerializeField] private AudioSource _audioSourceReference;
    #endregion attributs fields


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

            _particuleEffectDestroy.SetActive(true);
            Invoke(nameof(DisableParticuleEffect), 0.5f);
            Debug.Log(GameManager.Instance.BrickDeathCount);

            AddScore();
            _scoreAnimator.SetTrigger("PlayAnimation");

            if (_breakable)
            {
                this.Health--;
                if (this.Health <= 0)
                {
                    
                    Destroy(this.gameObject);
                }
                else
                {
                    this._spriteRenderer.sprite = this._stateSprite[this.Health-1];                                       
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

    private void DisableParticuleEffect()
    {
        _particuleEffectDestroy.SetActive(false);
        _audioSourceReference.PlayOneShot(_starSound,1.5f);
        _audioSourceReference.PlayOneShot(_windSound,3f);
    }
    #region Method Animation Lose/Victory
    // VICTORY ANIMATION
    private void LoadLevelIndex()
    {
        _endAnimator.SetTrigger("PlayAnimation");
        Invoke(nameof(OnStopAnimationEnd),2f);
    }
    public void OnStopAnimationEnd()
    {
        GameManager.Instance.WonMenu();
    }
    // LOSE ANIMATION
    private void LoadLoseAnimation()
    {
        _badEndAnimator.SetTrigger("PlayBadAnimation");
        Invoke(nameof(OnStopAnimationBadEnd),1f);
    }
    private void OnStopAnimationBadEnd()
    {
        GameManager.Instance.EndMenu();
    }

    #endregion Method Animation Lose/Victory
    private void AddScore()
    {
        Debug.Log(_score);
        GameManager.Instance.CurentScore += _score;
        _audioSourceReference.PlayOneShot(_scoringSound);
    }

    private void Update()
    {
        if (GameManager.Instance.CurrentLives <= 0)
        {
            LoadLoseAnimation();
        }
    }
}
