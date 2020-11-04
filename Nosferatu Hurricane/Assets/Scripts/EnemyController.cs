using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

	public Transform player;
	public float playerDistance;
	public float awareAI = 10f;
	public float AIMoveSpeed;
	public float damping = 6.0f;
	public bool isPatrol;
	public GameObject footstepEffects;
	public Transform[] navPoint;
	public UnityEngine.AI.NavMeshAgent agent;
	public int destPoint = 0;
	public Transform goal;

	public bool isTerrified = false;

	public bool activeLevel0 = true;
	public bool activeLevel1 = true;
	public bool activeLevel2 = true;
	public bool activeLevel3 = true;
	public bool activeLevel4 = true;
	public bool activeLevel5 = true;
	public bool activeLevel6 = true;
	public bool activeLevel7 = true;

	private bool isActive = false;
	private int currentLevel = 0;

	private GameObject closestMedBox;
	private float footstepTimer = 0;
	private float footstepInterval = 0.5f;

	void Start()
	{
		UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

		agent.autoBraking = false;

	}

	void Update()
	{

		LevelCheck();
		gameObject.SetActive(isActive);

		if (!isTerrified)
        {
			playerDistance = Vector3.Distance(player.position, transform.position);

			if (playerDistance < awareAI)
			{
				LookAtPlayer();
				Debug.Log("Seen");
			}

			if (playerDistance < awareAI)
			{
				if (playerDistance > 2f)
				{
					Chase();
				}
				else
					GotoNextPoint();
			}


			if (agent.remainingDistance < 0.5f)
				GotoNextPoint();
		}

		if (isPatrol)
        {
			if (footstepTimer <= 0)
			{
				Instantiate(footstepEffects, transform.position, Quaternion.identity);
				footstepTimer = footstepInterval;
			}
			else
			{
				footstepTimer -= Time.deltaTime;
			}
		}

	}

	void LookAtPlayer()
	{
		transform.LookAt(player);
	}


	void GotoNextPoint()
	{
		if (navPoint.Length == 0)
			return;
		agent.destination = navPoint[destPoint].position;
		destPoint = (destPoint + 1) % navPoint.Length;
	}


	void Chase()
	{
		transform.Translate(Vector3.forward * AIMoveSpeed * Time.deltaTime);
	}

	public GameObject FindClosestMedicine()
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("MedicineBox");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos)
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance)
			{
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Psychic"))
		{
			isTerrified = true;
			closestMedBox = null;
			closestMedBox = FindClosestMedicine();
			agent.destination = closestMedBox.transform.position;
		}

		if (other.gameObject.CompareTag("MedicineBox") && isTerrified)
		{
			isTerrified = false;
			agent.destination = navPoint[destPoint].position;
		}
	}

	public bool IsGuardTerrified()
    {
        if (isTerrified)
        {
			return true;
        }
        else
        {
			return false;
        }
    }

	private void LevelCheck()
	{
		currentLevel = LevelManager.currentLevel;

		if (currentLevel == 0 && (isActive != activeLevel0))
		{
			isActive = activeLevel0;
		}
		if (currentLevel == 1 && (isActive != activeLevel1))
		{
			isActive = activeLevel1;
		}
		if (currentLevel == 2 && (isActive != activeLevel2))
		{
			isActive = activeLevel2;
		}
		if (currentLevel == 3 && (isActive != activeLevel3))
		{
			isActive = activeLevel3;
		}
		if (currentLevel == 4 && (isActive != activeLevel4))
		{
			isActive = activeLevel4;
		}
		if (currentLevel == 5 && (isActive != activeLevel5))
		{
			isActive = activeLevel5;
		}
		if (currentLevel == 6 && (isActive != activeLevel6))
		{
			isActive = activeLevel6;
		}
		if (currentLevel == 7 && (isActive != activeLevel7))
		{
			isActive = activeLevel7;
		}
	}
}