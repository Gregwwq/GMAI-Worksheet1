using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretAIFSM : MonoBehaviour
{
    FSM<string> fsm = new FSM<string>();
    FSMState<string> idleState, trackState, missileState, beamState, brokenState;

    public bool Broken { private get; set; }

    public Rigidbody bullet;
    public AudioClip laser;
    public float maxTrackDistance = 10f;
    public float maxLaserDistance = 5f;
    public float turnSpeed = 2f;

    // public gets for the states to get the neccassary values
    public Vector3 PlayerDirection
    {
        get
        {
            return (player.position - transform.position);
        }
    }
    public float PlayerDistanceSquared
    {
        get
        {
            return (player.position - transform.position).sqrMagnitude;
        }
    }
    public float MaxTrackDistanceSquared
    {
        get
        {
            return (maxTrackDistance * maxTrackDistance);
        }
    }

    // public gets and private sets for the needed componenets
    public Transform Head { get; private set; }
    public Animator Anim { get; private set; }
    public AudioSource Source { get; private set; }
    public List<Transform> SpawnPts { get; private set; }
    public LaserBeam[] LaserScript { get; private set; }

    Transform player;

    public TurretAIFSM()
    {
        Broken = false;
    }

    void Start()
    {
        // setting the respective componenets
        Anim = GetComponent<Animator>();
        Source = GetComponent<AudioSource>();
        LaserScript = GetComponentsInChildren<LaserBeam>();

        Head = transform.Find("Head");

        SpawnPts = new List<Transform>();
        SetMissileSpawnPoints();

        player = GameObject.FindWithTag("Player").transform;

        idleState = new IdleState(fsm, this);
        trackState = new TrackState(fsm, this);
        missileState = new MissileState(fsm, this);
        beamState = new BeamState(fsm, this);
        brokenState = new BrokenState(fsm);

        fsm.AddState(idleState);
        fsm.AddState(trackState);
        fsm.AddState(missileState);
        fsm.AddState(beamState);
        fsm.AddState(brokenState);

        fsm.SetState("Idle");
    }

    void Update()
    {
        fsm.Update();
    }

    void SetMissileSpawnPoints()
    {
        foreach (Transform child in Head.transform.GetComponentsInChildren<Transform>())
        {
            if (child.CompareTag("MissileSpawnPoint"))
            {
                SpawnPts.Add(child);
            }
        }
    }

    // public function for the states to call to allow the turret to track the player
    public void Track()
    {
        float step = turnSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(Head.forward, PlayerDirection, step, 0.0F);
        Head.rotation = Quaternion.LookRotation(newDir);
    }

    // public function for all the states to be able to check if the turret is broken
    public void CheckBroken()
    {
        if (Broken)
        {
            fsm.SetState("Broken");
        }
    }
}