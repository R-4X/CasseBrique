using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speedBall = Mathf.Clamp(1, 0, 2);
    [SerializeField] private Rigidbody2D _rbBall;

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



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(MovementBall), 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameManager.Instance.BallLost == true)
        {
            Invoke(nameof(ResetBall), 2f);
            Debug.Log("Ball lost, resetting ball position and velocity.");
        }
    }
}
