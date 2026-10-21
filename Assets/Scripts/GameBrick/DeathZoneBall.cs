using UnityEditor;
using UnityEngine;

public class DeathZoneBall: MonoBehaviour
{
    #region serialized fields
    [SerializeField] private TMPro.TMP_Text _ballCountText;
    [SerializeField] private Rigidbody2D _rbBall;
    [SerializeField] private GameObject _prefabBall;
    [SerializeField] private Transform _ballInitialPosition = null;
    private MovementPaddle _movementPaddle;
    #endregion serialized fields


    #region private attribut fields
    private float _delayToSpawnNewBall = 2f;
    private float _timer = 0f;
    #endregion private attribut fields
    private bool _newBallSpawned = false;


    #region Methods
    private void DelayToSpawnNewBall()
    {
        if (_timer >= _delayToSpawnNewBall)
        {
            // Code to spawn new ball
            _timer = 0f;
            _newBallSpawned = false;
            GameManager.Instance.BallLost = false;
            print("New ball !");
        }
        else
        {
            print("Waiting to spawn new ball...");
            _timer += Time.deltaTime;
        }
    }

    private void SpawnNewBall()
    {
        Instantiate(_prefabBall, _ballInitialPosition.position, Quaternion.identity, _ballInitialPosition.transform);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // set life count text to 3 / initial score
        _ballCountText.text = GameManager.Instance.CurrentLives.ToString();
        _newBallSpawned = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name =="Ball")
        {
            GameManager.Instance.CurrentLives--;
            print("ball is in death zone");
            // play sound + vfx
            _ballCountText.text = GameManager.Instance.CurrentLives.ToString();
            
            if (GameManager.Instance.CurrentLives <= 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("EndGameMenu");
                //GameManager.Instance.EndGame();
            }

            else
            { 
                GameManager.Instance.BallLost = true;
                collision.gameObject.transform.position = _ballInitialPosition.position;
                collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                
                
                //_newBallSpawned = true;
                //SpawnNewBall();
                //Destroy(collision.gameObject);
                //DelayToSpawnNewBall();
            }
        }
    }



        // Update is called once per frame
        void Update()
        {
            if (_newBallSpawned == true)
            {
                DelayToSpawnNewBall();
                
            }
        
        }
    #endregion Methods
        }
