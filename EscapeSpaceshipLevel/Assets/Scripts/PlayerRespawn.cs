using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    public bool firstCheckpoint = false;
    public bool secondCheckpoint = false;
    public bool thirdCheckpoint = false;

    public Transform pos0;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.name.Equals("RespawnCollider"))
        { 
            if(thirdCheckpoint)
            {
                gameObject.GetComponent<CharacterController>().enabled = false;
                transform.position = new Vector3(pos3.position.x, pos3.position.y, pos3.position.z);
                Debug.Log(transform.position);
            }
            else if(secondCheckpoint)
            {
                gameObject.GetComponent<CharacterController>().enabled = false;
                transform.position = new Vector3(pos2.position.x, pos2.position.y, pos2.position.z);
                Debug.Log(transform.position);
            }
            else if (firstCheckpoint)
            {
                gameObject.GetComponent<CharacterController>().enabled = false;
                transform.position = new Vector3(pos1.position.x, pos1.position.y, pos1.position.z);
                Debug.Log(transform.position);
            }
            else
            {
                gameObject.GetComponent<CharacterController>().enabled = false;
                transform.position = new Vector3(pos0.position.x, pos0.position.y, pos0.position.z);
                Debug.Log(transform.position);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Equals("CheckPoint (1)"))
        {
            firstCheckpoint = true;
            Debug.Log("CheckPoint 1");
        }

        if (other.gameObject.name.Equals("CheckPoint (2)"))
        {
            secondCheckpoint = true;
            Debug.Log("CheckPoint 2");
        }

        if (other.gameObject.name.Equals("CheckPoint (3)"))
        {
            thirdCheckpoint = true;
            Debug.Log("CheckPoint 3");
        }
    }

}
