using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomPatrol : MonoBehaviour
{
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    Vector2 targetPosition;

    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;

    float speed;

    [SerializeField] float secondsToMaxDifficulty;

    [SerializeField] GameObject restartPanel;

    // Start is called before the first frame update
    void Start()
    {
    	targetPosition = GetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector2)transform.position != targetPosition)
	{
		speed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercent());
		transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
	} else {
		targetPosition = GetRandomPosition();
	}
    }

    Vector2 GetRandomPosition()
    {
	float randomX = Random.Range(minX, maxX);
	float randomY = Random.Range(minY, maxY);
	return new Vector2(randomX, randomY);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
	if(collision.tag == "Planets")
	{
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		restartPanel.SetActive(true);
	}
    }

    float GetDifficultyPercent()
    {
	return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }
}
