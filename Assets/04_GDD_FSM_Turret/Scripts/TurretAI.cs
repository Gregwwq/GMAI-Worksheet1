using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretAI : MonoBehaviour 
{
    public Rigidbody bullet;
	public AudioClip laser;
	public float m_maxTrackDistance= 10f;
	public float m_maxLaserDistance = 5.0f;

	Transform m_head; // Turret head
	Transform m_player;
	Vector3 m_playerDirection;
	float m_PlayerDistanceSquared;
	float m_maxTrackDistanceSquared;
	float m_maxLaserDistanceSquared;

	float m_speed = 2.0f;

    float shootDelay = 0.25f;
    float time = 0.0f;

    int missileNum = 0;
    int maxMissileNum;

	LaserBeam[] laserScript;

    private List<Transform> spawnPoints = new List<Transform>();

	Animator anim;

    void SetMissileSpawnPoints()
    {
        foreach (Transform child in m_head.transform.GetComponentsInChildren<Transform>())
        {
            if (child.CompareTag("MissileSpawnPoint"))
            {
                spawnPoints.Add(child);
            }
        }
    }
	
	void Start () {
		anim = GetComponent<Animator> ();
		laserScript = GetComponentsInChildren<LaserBeam> ();

		m_head = transform.Find ("Head");

        SetMissileSpawnPoints();
        maxMissileNum = spawnPoints.Count-1;

		m_player = GameObject.FindWithTag ("Player").transform;
		m_maxTrackDistanceSquared = m_maxTrackDistance * m_maxTrackDistance;
		m_maxLaserDistanceSquared = m_maxLaserDistance * m_maxLaserDistance;
	}

	void Update () {
		m_playerDirection = m_player.position - transform.position;
		m_PlayerDistanceSquared = m_playerDirection.sqrMagnitude;

		if (m_PlayerDistanceSquared < m_maxTrackDistanceSquared)
		{
			if (anim.GetBool("TrackRange") == false)
			{
				anim.SetBool("TrackRange", true);
			}

			// track and shoot laser
			if (m_PlayerDistanceSquared < m_maxTrackDistanceSquared * 0.33f) 
			{
				if (anim.GetBool("ShootRange") == false)
				{
					anim.SetBool("ShootRange", true);
				}					
				Debug.DrawRay(m_head.position, m_playerDirection, Color.red);
				ShootLaser();
			}
			// track and shoot missiles
			else if (m_PlayerDistanceSquared < m_maxTrackDistanceSquared * 0.66f) 
			{
				StopLaser();
				ShootBullet();
			}
			else 
			// track but don't shoot anything
			{
				if (anim.GetBool("ShootRange"))
				{
					anim.SetBool("ShootRange", false);
					StopLaser();
				}
				Debug.DrawRay(m_head.position, m_playerDirection, Color.blue);
			}
			Track();
		}
		// stop tracking
		else
		{
			if (anim.GetBool("TrackRange"))
			{
				anim.SetBool("TrackRange", false);
			}
		}
	}

	void ShootLaser()
    {
		laserScript[0].Fire(true);
		laserScript[1].Fire(true);
		GetComponent<AudioSource>().PlayOneShot (laser, 1.0f);
    }

	void StopLaser()
	{
		laserScript[0].Fire(false);
		laserScript[1].Fire(false);
		GetComponent<AudioSource>().Stop ();
	}

	void ShootBullet()
	{
		time += Time.deltaTime;
		if (missileNum > maxMissileNum)
		{
			missileNum = 0;
		}

		Rigidbody bulletClone;
		float speed = 10f;

		if (time > shootDelay)
		{
			bulletClone = (Rigidbody)Instantiate(bullet, spawnPoints[missileNum].position, Quaternion.identity);
			bulletClone.rotation = spawnPoints[missileNum].rotation;
			bulletClone.AddForce(spawnPoints[missileNum].forward * speed, ForceMode.Force);

			missileNum++;
			time = 0.0f;
		}

	}

	void Track()
	{
		float step = m_speed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(m_head.forward, m_playerDirection, step, 0.0F);
		m_head.transform.rotation = Quaternion.LookRotation(newDir);
	}
}
