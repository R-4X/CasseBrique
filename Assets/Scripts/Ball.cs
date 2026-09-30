using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speedBall = 5f;
    [SerializeField] private Rigidbody2D _rbBall;
    
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            GoUpBall();
        }
    }
    private void GoUpBall()
    {
        _rbBall.AddForce(new Vector2(_speedBall, 0), ForceMode2D.Impulse);
    }

    private void GoUp()
    {
        print("Collision avec la raquette");
        Vector3 direction = transform.position;
        direction.y = Vector3.up.y * _speedBall;
        transform.position = direction;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
