using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Metrics Ball")]
    [SerializeField] private float _speedBall = 300f;
    [SerializeField] private Rigidbody2D _rbBall;
    [SerializeField] private TrailRenderer _trailRenderer;

    [Header("Animation")]
    [SerializeField] private GameObject _ballNewLife;
    [SerializeField] private Animator  _indicationPlayerInput;

    [Header("Sound")]
    [SerializeField] private AudioClip _brickBlockSound;
    [SerializeField] private AudioClip _brickSecondBlockSound;
    [SerializeField] private AudioClip _brickMultipleBlockSound;
    [SerializeField] private AudioClip _launchBallSound;
    [SerializeField] private AudioSource _audioSourceReference;

    public Rigidbody2D RbBall { get => _rbBall; set => _rbBall = value; }
    private bool _isWaitingToReset = false;
    private bool _canPressSpace = false;
    private int _lastCombo = -1;
    private void ResetBall()
    {
        _indicationPlayerInput.SetTrigger("PlayAnimation");
        if (Input.GetKey(KeyCode.Space))
        {
            _indicationPlayerInput.SetTrigger("StopAnimation");
            _ballNewLife.SetActive(true);
            _audioSourceReference.PlayOneShot(_launchBallSound);
            this.transform.position = Vector2.zero;  //new Vector3(0, -3.5f, 0)
            this.RbBall.linearVelocity = Vector2.zero;

            GameManager.Instance.BallLost = false;
            Invoke(nameof(MovementBall), 0.4f);
            Invoke(nameof(StopActivationNiagara), 2f);

            _canPressSpace = false;
            _lastCombo = -1;
            _isWaitingToReset = false;
        }
    }

    private void MovementBall()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;
        this.RbBall.AddForce(force.normalized * this._speedBall);
    }
    
    private void StopActivationNiagara()
    {
        _ballNewLife.SetActive(false);
    }

    private void Awake()
    {
        this.RbBall = GetComponent<Rigidbody2D>();
    }


    private void AddSpeed(float speedAdd)
    {
        _speedBall += speedAdd;
        _speedBall = Mathf.Clamp(_speedBall, 0f, 303f);
        if (RbBall.linearVelocity != Vector2.zero)
        {
            RbBall.linearVelocity = RbBall.linearVelocity.normalized * (_speedBall * 0.03f);
            // Note : On ajuste le ratio de la vélocité si votre jeu utilise des forces élevées, 
            // ou vous pouvez appliquer une force directionnelle.
        }
        Debug.Log("Speed ball updated to: " + _speedBall);
    }

    private IEnumerator ResetBallRoutine()
    {
        _isWaitingToReset = true;
        yield return new WaitForSeconds(2f);
        _canPressSpace = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(MovementBall),3.5f);
        _audioSourceReference.PlayOneShot(_brickSecondBlockSound);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameManager.Instance.BallLost ==true && !_isWaitingToReset)
        {
            StartCoroutine(ResetBallRoutine());
            _speedBall = 300f;
        }

        if (_canPressSpace)
        {
            ResetBall();
        }

        int currentCombo = GameManager.Instance.CurrentCombo;
        if (currentCombo != _lastCombo)
        {
            _lastCombo = currentCombo;

            if (currentCombo >= 3 && currentCombo < 5)
            {
                _trailRenderer.colorGradient = new Gradient()
                {
                    colorKeys = new GradientColorKey[]
                    {
                        new GradientColorKey(Color.yellow, 1f),
                        new GradientColorKey(Color.white, 1f)
                    },
                    alphaKeys = new GradientAlphaKey[]
                    {
                        new GradientAlphaKey(1f, 1f),
                        new GradientAlphaKey(1f, 0.5f)
                    }
                };
                _audioSourceReference.PlayOneShot(_brickSecondBlockSound);
                AddSpeed(50f);
                Debug.Log(_speedBall);
            }
            else if (currentCombo >= 5 && currentCombo < 8)
            {
                _trailRenderer.colorGradient = new Gradient()
                {
                    colorKeys = new GradientColorKey[]
                    {
                        new GradientColorKey(Color.orange, 1f),
                        new GradientColorKey(Color.yellow, 1f),
                        new GradientColorKey(Color.white, 1f)
                    },
                    alphaKeys = new GradientAlphaKey[]
                    {
                        new GradientAlphaKey(1f, 0f),
                        new GradientAlphaKey(1f, 1f),
                        new GradientAlphaKey(1f, 1f)
                    }
                };
                _audioSourceReference.PlayOneShot(_brickMultipleBlockSound);
                AddSpeed(25f);

            }

            else if (currentCombo >= 8)
            {
                _trailRenderer.colorGradient = new Gradient()
                {
                    colorKeys = new GradientColorKey[]
                    {
                        new GradientColorKey(Color.red, 1f),
                        new GradientColorKey(Color.orange, 1f),
                        new GradientColorKey(Color.yellow, 1f)
                    },
                    alphaKeys = new GradientAlphaKey[]
                    {
                        new GradientAlphaKey(1f, 0f),
                        new GradientAlphaKey(1f, 1f),
                        new GradientAlphaKey(1f, 1f)
                    }
                };
                _audioSourceReference.PlayOneShot(_brickSecondBlockSound);
                AddSpeed(25f);
            }

            else if(currentCombo < 3)
            {
                _trailRenderer.colorGradient = new Gradient()
                {
                    colorKeys = new GradientColorKey[]
                    {
                        new GradientColorKey(Color.white, 1f),
                        new GradientColorKey(Color.white, 1f)
                    },
                    alphaKeys = new GradientAlphaKey[]
                    {
                        new GradientAlphaKey(1f, 0f),
                        new GradientAlphaKey(1f, 1f)
                    }
                };
                _audioSourceReference.PlayOneShot(_brickBlockSound);
                
            }
        }
    }
}
