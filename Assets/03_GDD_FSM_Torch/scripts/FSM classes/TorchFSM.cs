// using UnityEngine;
// using System.Collections;

// public enum StateEnum
// {
//     ON,
//     OFF
// }

// public class TorchFSM : MonoBehaviour
// {

//     public float Distance = 1.0f;

//     public State objLightOn { get; private set; }
//     public State objLightOff { get; private set; }

//     private State objActiveState;

//     private GameObject player;
//     private Torchlight torchLight;  // The script that controls the torch animation
//     private float sqrDistance;      // How close to the torch before it turns on

//     void Start()
//     {
//         player = GameObject.FindGameObjectWithTag("Player");
//         torchLight = GetComponent<Torchlight>();
//     }

//     void Update()
//     {
//         if (objActiveState != null)
//         {
//             objActiveState./* Missing code */;
//         }
//     }

//     public void ChangeState(State NextState)
//     {
//         if (objActiveState != null)
//         {
//             objActiveState.Exit();
//         }

//         objActiveState = NextState;

//         if (objActiveState != null)
//         {
//             /* Missing code */
//         }
//     }

//     public GameObject Player
//     {
//         get
//         {
//             return this.player;
//         }
//     }

//     public Torchlight TorchLight
//     {
//         get
//         {
//             return this.torchLight;
//         }
//     }

//     public float SqrDistance
//     {
//         get
//         {
//             return this.sqrDistance;
//         }
//     }
// }
