using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
	private float movementSpeed = 1f;
	private float projectileSpeed;
	
	public Button speedUpButton;
	public Button speedDownButton;
	public Button fireButton;
	public Button exitButton;
	public Button pauseButton;
	
	private bool isPaused;
	
	public Text speedDisplay;
	private Rigidbody rb;
	
	private Vector3 initialPosition;
	private Vector3 currentPosition;
	
	public GameObject projectile;
	public GameObject projectileClone;
	
	void Start()
	{
		speedUpButton.onClick.AddListener(TaskOnClickSpeedUp);
		speedDownButton.onClick.AddListener(TaskOnClickSpeedDown);
		fireButton.onClick.AddListener(TaskOnClickFire);
		exitButton.onClick.AddListener(TaskOnClickExit);
		pauseButton.onClick.AddListener(TaskOnClickPause);
		
		speedDisplay.text = $"Current speed: {movementSpeed}";
		rb = gameObject.GetComponent<Rigidbody>();
		isPaused = false;
	}
	
    void Update()
    {
		projectileSpeed = movementSpeed * 1f;
		transform.position += Vector3.forward * Time.deltaTime * movementSpeed;
		
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			
			if (touch.phase == TouchPhase.Began)
			{
				initialPosition = touch.position;
			}
			else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
			{
				Vector3 currentPosition = transform.position;
				var direction = touch.position.x - initialPosition.x;
				int dir = (direction > 0) ? 1 : (direction < 0) ? -1 : 0;
				if (dir == 1 && currentPosition.x < 9)
					transform.Translate(0.5f, 0, 0);
				else if (dir == -1 && currentPosition.x > -9)
					transform.Translate(-0.5f, 0, 0);
				initialPosition = touch.position;
			}
		}
    }
	
	void TaskOnClickSpeedUp()
	{
		movementSpeed += 1f;
		speedDisplay.text = $"Current speed: {movementSpeed}";
	}
	
	void TaskOnClickSpeedDown()
	{
		if (movementSpeed > 1)
		{
			movementSpeed -= 1f;
			speedDisplay.text = $"Current speed: {movementSpeed}";
		}
	}
	
	void TaskOnClickFire()
	{
		Vector3 pos = transform.position;
		pos.z += 1;
		
		projectileClone = Instantiate(projectile, pos, Quaternion.identity) as GameObject;
		projectileClone.GetComponent<Rigidbody>().AddForce(transform.forward * 250f * projectileSpeed);
	}
	
	void TaskOnClickExit()
	{
		Application.Quit();
	}
	
	void TaskOnClickPause()
	{
		if (isPaused)
		{
			Time.timeScale = 1;
			isPaused = false;
		}
		else
		{
			Time.timeScale = 0;
			isPaused = true;
		}
	}
}
