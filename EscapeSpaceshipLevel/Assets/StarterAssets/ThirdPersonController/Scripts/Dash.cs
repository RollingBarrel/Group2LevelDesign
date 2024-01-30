using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;


public class Dash : MonoBehaviour
{
    // Start is called before the first frame update

    public float dashSpeed = 20;
    public float dashTime = 0.4f;
    public float coolDown = 1;
    private float dashcounter = 0;
    private bool isDashEnabled = true;

    private Animator _animator;
    private bool _hasAnimator;

    private void Start()
    {
        _hasAnimator = TryGetComponent(out _animator);
    }
    // Update is called once per frame
    void Update()
    {
        if (isDashEnabled)
        {
            if (UnityEngine.Input.GetKeyDown("left ctrl"))
            {
                _hasAnimator = TryGetComponent(out _animator);
                if (_hasAnimator)
                {
                    _animator.SetBool("Dash", true);
                }
                
                StartCoroutine(DashCoroutine());
                isDashEnabled = false;                      
            }
        }
        else
        {
            if (dashcounter >= coolDown)
            {
                isDashEnabled = true;
                dashcounter = 0;
            }
            else
            {
                dashcounter += Time.deltaTime;
                _animator.SetBool("Dash", false);
            }

        }
    }

    IEnumerator DashCoroutine()
    {
        float startTime = Time.time;
        Vector3 targetDirection = Quaternion.Euler(0.0f, gameObject.GetComponent<ThirdPersonController>()._targetRotation, 0.0f) * Vector3.forward;

        while (Time.time < startTime + dashTime)
        {
            gameObject.GetComponent<CharacterController>().Move(targetDirection * dashSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
