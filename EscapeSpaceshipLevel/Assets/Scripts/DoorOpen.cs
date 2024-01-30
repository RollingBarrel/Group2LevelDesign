using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject[] doorParts;
    public GameObject lever;
    public GameObject handle;
    public GameObject text;

    float doorPos;
    float angle;

    // Start is called before the first frame update
    void Start()
    {
        doorPos = doorParts[0].transform.localPosition.x;
        angle = lever.transform.localRotation.eulerAngles.x;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name.Equals("PlayerArmature"))
        {
            text.SetActive(true);

            if (UnityEngine.Input.GetKeyDown("e"))
            {
                StartCoroutine(RotateLever());
                StartCoroutine(Open());
            }
        }
        else
        {
            text.SetActive(false);
        }
    }

    private IEnumerator RotateLever()
    {
        while (angle < 70.0f)
        {
            Quaternion quat = Quaternion.Euler(angle, 0, 0);

            lever.transform.localRotation = new Quaternion(quat.x, quat.y, quat.z, quat.w);
            handle.transform.localRotation = new Quaternion(quat.x, quat.y, quat.z, quat.w);
            angle += 1;
        }

        yield return null;

    }

    private IEnumerator Open()
    {
        for(int i = 0; i < doorParts.Length; i++)
        {

            doorParts[i].transform.localPosition = new Vector3(0.0f, 0.034f, 0.0f);
       
            doorParts[i].GetComponentInParent<BoxCollider>().center = new Vector3(0.0f, 0.1f, 0.0f);

            yield return null;
        }

    }
}
