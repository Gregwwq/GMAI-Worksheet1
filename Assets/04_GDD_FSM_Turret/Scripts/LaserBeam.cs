using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour {

	public AudioClip laserSound;

    LineRenderer line;
    RaycastHit hit;
	
	GameObject target; // player

    Vector3 origin;
	Vector3 targetPos;
	Vector3 direction;

	bool activate = false;

	private int numLineVerts = 10;

	void Start () 
	{
		target = GameObject.FindGameObjectWithTag("Player");
		line = GetComponent<LineRenderer>();
		line.positionCount = numLineVerts;
		line.startWidth = 0.1f;
		line.endWidth = line.startWidth;
		line.useWorldSpace = true;
	}

	public void Fire(bool isActive)
	{
		activate = isActive;
	}
	
	void Update () {
        if (activate == false)
		{
			line.positionCount = 0;
			return;
		}

		if(line.positionCount == 0)
		{
			line.positionCount = numLineVerts;
		}

		origin = transform.position;
		
		targetPos = target.transform.position;
		targetPos.y = origin.y;

		line.SetPosition (0, origin);
		for(int i=0; i < numLineVerts; i++)
		{
			var pos = Vector3.Lerp(origin, targetPos, i / (float)numLineVerts);
			pos.x += Random.Range(-0.2f,0.2f);
			pos.y += Random.Range(-0.1f,0.1f);
			
			line.SetPosition(i, pos);
		}
		line.SetPosition (numLineVerts-1, targetPos);

        checkHit();
	}

    void checkHit()
    {
		direction = targetPos - origin;
        if (Physics.Raycast(origin, direction, out hit) == true)
        {
            Debug.Log("Hit " + hit.collider.gameObject.name);
        }
    }
}
