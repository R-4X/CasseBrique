using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speedBall = Mathf.Clamp(1, 0, 750);
    [SerializeField] private Rigidbody2D _rbBall;
    [SerializeField] private TrailRenderer _trailRenderer;

    public Rigidbody2D RbBall { get => _rbBall; set => _rbBall = value; }


    private void ResetBall()
    {
        if (Input.GetKey(KeyCode.Space) && (GameManager.Instance.BallLost == true))
        {
            this.transform.position = Vector2.zero;  //new Vector3(0, -3.5f, 0)
            this.RbBall.linearVelocity = Vector2.zero;

            GameManager.Instance.BallLost = false;
            Invoke(nameof(MovementBall), 0.4f);
        }
    }

    private void MovementBall()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        this.RbBall.AddForce(force.normalized * this._speedBall);  // 
    }
    

    private void Awake()
    {
        this.RbBall = GetComponent<Rigidbody2D>();
    }


    private void AddSpeed(float speedAdd)
    {
        _speedBall = Mathf.Clamp(1, 0, 350);
        _speedBall += speedAdd;
        Debug.Log("Speed ball increased to: " + _speedBall);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
            // play annimation of ball movement
            // play animation of paddle touche 
            // play sound 
            Invoke(nameof(MovementBall), 2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameManager.Instance.BallLost == true)
        {
            Invoke(nameof(ResetBall), 2f);
            _speedBall = 300;
            Debug.Log("Ball lost, resetting ball position and velocity.");
        }

        else if (GameManager.Instance.CurrentCombo >= 3 && GameManager.Instance.CurrentCombo < 5)
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
            AddSpeed(2f);
            //MovementBall();
            Debug.Log("Speed ball increased to: " + _speedBall);
        }
        else if (GameManager.Instance.CurrentCombo >= 5 && GameManager.Instance.CurrentCombo < 8)
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
            AddSpeed(5f);
            //MovementBall();
        }
        else if (GameManager.Instance.CurrentCombo >= 8)
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
            AddSpeed(10f);
            //MovementBall();
        }

        else         
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
            //_speedBall = Mathf.Clamp(300, 0, 300);
        }
    }
}
