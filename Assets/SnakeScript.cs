using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    private Vector2 snakeDirection = Vector2.right;
    private List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;
    public MainMenuScript mainMenuScript;
    public bool snakeIsAlive = true;
    public int initialSize = 5;

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        if (!snakeIsAlive)
            return;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            snakeDirection = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            snakeDirection = Vector2.down;
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            snakeDirection = Vector2.right;
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            snakeDirection = Vector2.left;
    }

    private void FixedUpdate()
    {
        if (!snakeIsAlive)
            return;

        for (int i = segments.Count - 1; i > 0; i--)
            segments[i].position = segments[i - 1].position;

        transform.position += (Vector3)snakeDirection;
    }

    private void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    private void ResetState()
    {
        foreach (Transform segment in segments)
            Destroy(segment.gameObject);

        segments.Clear();
        segments.Add(transform);

        for (int i = 1; i < initialSize; i++)
            segments.Add(Instantiate(segmentPrefab));

        transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
            Grow();
        else if (collision.CompareTag("Obstacle"))
        {
            mainMenuScript.GameOver();
            snakeIsAlive = false;
            snakeDirection = Vector2.zero;
        }
    }
}
