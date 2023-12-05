using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    CircleCollider2D circleCollider;
	GameObject lastObjectHit;
    public Vector2 velocity;
	public AudioClip OnWallHitAudio;
	public AudioClip OnPaddleHitAudio;

	GameController gameController;

    private void Awake()
    {
		gameController = FindObjectOfType<GameController>();
	}
    void Start()
	{
		circleCollider = GetComponent<CircleCollider2D>();
	}

	// Update is called once per frame
	void Update()
    {
		// update position of the ball
        transform.Translate(velocity * Time.deltaTime);

		// check for collisions
		CheckHits();

		// check if ball lost and lose life
		CheckBallAlive();
	}

	private void CheckHits()
	{
		RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, circleCollider.radius, velocity, (velocity * Time.deltaTime).magnitude);
		foreach (RaycastHit2D hit in hits)
		{
			if (hit.collider != circleCollider && lastObjectHit != hit.transform.gameObject)
			{
				lastObjectHit = hit.transform.gameObject;

				velocity = Vector2.Reflect(velocity, hit.normal);

				if (hit.transform.GetComponent<Paddle>())
				{
					velocity.y = Mathf.Abs(velocity.y);
					gameController.audioController.PlayClip(OnPaddleHitAudio);
				}

				if (hit.transform.GetComponent<Block>())
				{
					hit.transform.GetComponent<Block>().OnHit();
				}

				gameController.audioController.PlayClip(OnWallHitAudio);
			}
		}
	}

	public void ResetBall(Vector3 _defaultPosition)
	{
		transform.position = _defaultPosition;
		velocity.y = Mathf.Abs(velocity.y);
		lastObjectHit = null;
	}

	private void CheckBallAlive()
	{
		if (transform.position.y < -Camera.main.orthographicSize)
		{
			gameController.BallLost();
		}
	}
}
