using UnityEngine;
using System.Collections;

public class Sha : MonoBehaviour
{
    // inspiration : https://www.youtube.com/watch?v=-KjlKXTRAT4
    [SerializeField] public float _duration = 0.5f; 
    private bool _isShaking = false;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.BallLost == true)
        {
            if (_isShaking == false)
            {
                StartCoroutine(Shake());
                _isShaking = true;
            }
            
        }
    }

    private IEnumerator Shake()
    {
        Vector3 originalPosition = transform.position;
        float elapsed = 0.0f;
        while (elapsed < _duration)
        {
            float x = Random.Range(-0.2f, 0.2f);
            float y = Random.Range(-0.2f, 0.2f);
            transform.position = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);
            
            elapsed += Time.deltaTime;
            if (elapsed >= _duration)
            {
                originalPosition = transform.position;
            }
            yield return null;
        }
        transform.position = originalPosition;
    }
}
