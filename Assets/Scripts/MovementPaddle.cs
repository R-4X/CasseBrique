using UnityEngine;

public class MovementPaddle : MonoBehaviour
{
    [SerializeField] private float _speedPaddle = 5f;
    [SerializeField] private Rigidbody2D _rigidbodyPaddle = null;
    private Vector2 _lastVectorPaddleMovement;
    private float _maxBounceAngle = 75f;

    public Vector2 LastVectorPaddleMovement { get => _lastVectorPaddleMovement; set => _lastVectorPaddleMovement = value; }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Q))
        {
            
            this.transform.position += Vector3.left * Time.deltaTime * _speedPaddle;
            Debug.Log("MovementRight");
        }
        else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            
            this.transform.position += Time.deltaTime * _speedPaddle *Vector3.right;
            Debug.Log("MovementLeft");
        }
    }

    private void ResetPaddle()
    {
        this.transform.position = new Vector2(0f, this.transform.position.y); //   0, -3.5f, 0);
        this._rigidbodyPaddle.linearVelocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // tuto : https://www.youtube.com/watch?v=RYG8UExRkhA&t=2649s

        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            Debug.Log("Collision with ball");
            Vector3 paddlePossition = this.transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            // look all on paddle position in % left and right or middle
            float offset = paddlePossition.x - contactPoint.x;
            float widthPaddle = collision.otherCollider.bounds.size.x / 2;


            // calcul angle of bounce based on where the ball hits the paddle
            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.RbBall.linearVelocity);
            float bounceAngle = (offset / widthPaddle) * _maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -_maxBounceAngle, _maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.RbBall.linearVelocity = rotation * Vector2.up * ball.RbBall.linearVelocity.magnitude;
        }
    }


    // Update is called once per frame
    void Update()
    {
        Movement();
        if (GameManager.Instance.BallLost == true)
        {
            ResetPaddle();
        }
    }

    void Start()
    {

    }

}
