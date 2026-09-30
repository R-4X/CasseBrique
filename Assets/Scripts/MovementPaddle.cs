using UnityEngine;

public class MovementPaddle : MonoBehaviour
{
    [SerializeField] private float _speedPaddle = 5f;
    [SerializeField] private Rigidbody2D _rigidbodyPaddle = null;
    private Vector3 _lastVectorPaddleMovement;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

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
        else
        {

        }
    }




    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Start()
    {

    }

}
