using UnityEngine;
using System.Collections;

public class Sha : MonoBehaviour
{
    // inspiration : https://www.youtube.com/watch?v=-KjlKXTRAT4
    [SerializeField] public float _duration = 0.5f; 

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.BallLost == true)
        {
            StartCoroutine(Shake());
        }
    }

    private IEnumerator Shake()
    {
        Vector3 originalPosition = transform.position;
        float elapsed = 0.0f;
        while (elapsed < _duration)
        {
            float x = Random.Range(-0.5f, 0.5f);
            float y = Random.Range(-0.5f, 0.5f);
            transform.position = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);
            
            elapsed += Time.deltaTime;
            if (elapsed >= _duration)
            {
                GameManager.Instance.BallLost = false;
                break;
            }
            yield return null;
        }
        transform.position = originalPosition;
    }
}
