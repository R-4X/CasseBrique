using UnityEditor;
using UnityEngine;

public class DeathZoneBall: MonoBehaviour
{
    #region serialized fields
    [SerializeField] private int _ballCount = 3;
    [SerializeField] private TMPro.TMP_Text _ballCountText;
    [SerializeField] private Rigidbody2D _rbBall;
    [SerializeField] private GameObject _prefabBall;
    [SerializeField] private Transform _ballInitialPossition;
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
            SpawnNewBall();
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
        // position on the paddle
        // Instantiate a new ball prefab at the paddle's position

        Instantiate(_prefabBall, new Vector3(0, -3.5f, 0), Quaternion.identity, _ballInitialPossition.transform);

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
            {
                // set life count text to 3 / initial score
                _ballCountText.text = _ballCount.ToString();
                _newBallSpawned = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            _ballCount--;
            print("ball is in death zone");
            // play sound + vfx
            _ballCountText.text = _ballCount.ToString();
            Destroy(collision.gameObject);
            _newBallSpawned = true;
            DelayToSpawnNewBall();
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
