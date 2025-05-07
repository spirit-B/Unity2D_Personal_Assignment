using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    [SerializeField] private Transform topObject;
    [SerializeField] private Transform bottomObject;

    public float widthPadding = 4f;

    GameManager gameManager;
    // Start is called before the first frame update

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FlappyPlayerController player = collision.GetComponent<FlappyPlayerController>();
        if (player != null)
        {
            gameManager.AddScore(1);
        }
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }
}
