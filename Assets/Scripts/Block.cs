using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	public int HitPoints = 2;
	public int ScorePoints = 100;
	public AudioClip OnBreakAudio;

	GameController gameController;
	private void Awake()
	{
		gameController = FindObjectOfType<GameController>();
	}
	public void OnHit()
	{
		HitPoints--;
		
		if (HitPoints <= 0)
		{
			gameController.AddScore(ScorePoints);
			gameController.audioController.PlayClip(OnBreakAudio);
			Instantiate(gameController.ExplosionPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
