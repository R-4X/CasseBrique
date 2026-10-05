using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speedBall = Mathf.Clamp(1, 0, 2);
    [SerializeField] private Rigidbody2D _rbBall;
    
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bricks"))
        {
           
        }
    }

    private void MovementBall()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        this._rbBall.AddForce(force.normalized);  // *this._speedBall
    }
    

    private void Awake()
    {
        this._rbBall = GetComponent<Rigidbody2D>();
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(MovementBall), 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
