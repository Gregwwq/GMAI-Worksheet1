using UnityEngine;
using System.Collections;

public class BulletAI : MonoBehaviour
{
    public GameObject turret { private get; set; }

    void Update()
    {
        if (turret != null)
        {
            if ((turret.transform.position - transform.position).magnitude < .2f)
            {
                turret.GetComponent<TurretAIFSM>().Broken = true;
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
