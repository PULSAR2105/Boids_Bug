using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{
    public MoveGoal moveGoal;
    public GameObject goal;
    public GameObject dashGoal;
    public GameObject dashTarget;

    public Slider slider;
    public float dashMaxValue;
    public float dashValue;
    public float dashDuration;
    public float dashRecovery;
    bool isDashing = false;
    bool isRecoveryDash = false;

    public Slider sliderDashForward;
    public float dashForwardMaxValue;
    public float dashForwardValue;
    public float dashForwardDuration;
    public float dashForwardRecovery;
    bool isDashingForward = false;
    bool isRecoveryDashForward = false;

    public float multiRotation;
    public float multiSpeed;
    float tmp_multiRotation;
    float tmp_multiSpeed;

    Vector3 vectorMove;
    public int distance;

    void Start()
    {
        tmp_multiRotation = multiRotation;
        tmp_multiSpeed = multiSpeed;
        dashTarget = goal;
    }

    void Update()
    {
        if(goal != null) {
            vectorMove = moveGoal.vectorBetGoal / moveGoal.vectorBetGoal.magnitude * distance;
            transform.position = goal.transform.position + -vectorMove;
        }

        if(Input.GetMouseButton(0)){
            if(dashValue > 0) {

                multiRotation = tmp_multiRotation;
                multiSpeed = tmp_multiSpeed;
                StartCoroutine(DecreaseDashBar());
            } else {
            multiRotation = 1;
            multiSpeed = 1;
            }

        } else {
            multiRotation = 1;
            multiSpeed = 1;
            if(dashValue < dashMaxValue) {
                StartCoroutine(IncreaseDashBar());
            }
        }

        if(Input.GetMouseButton(1)){
            if(dashForwardValue > 0) {
                dashTarget = dashGoal;
                StartCoroutine(DecreaseDashForwardBar());
            } else {
                dashTarget = goal;
            }

        } else {
            if(dashForwardValue < dashForwardMaxValue) {
                dashTarget = goal;
                StartCoroutine(IncreaseDashForwardBar());
            }
        }
    }

    IEnumerator DecreaseDashBar() {
        if(!isDashing) {
            isDashing = true;
            yield return new WaitForSeconds(dashDuration / dashMaxValue);
            dashValue--;
            slider.value = dashValue;
            isDashing = false;
        }
    }

    IEnumerator IncreaseDashBar() {
        if(!isRecoveryDash) {
            isRecoveryDash = true;
            yield return new WaitForSeconds(dashRecovery / dashMaxValue);
            dashValue++;
            slider.value = dashValue;
            isRecoveryDash = false;
        }
    }

    IEnumerator DecreaseDashForwardBar() {
        if(!isDashingForward) {
            isDashingForward = true;
            yield return new WaitForSeconds(dashForwardDuration / dashForwardMaxValue);
            dashForwardValue--;
            sliderDashForward.value = dashForwardValue;
            isDashingForward = false;
        }
    }

    IEnumerator IncreaseDashForwardBar() {
        if(!isRecoveryDashForward) {
            isRecoveryDashForward = true;
            yield return new WaitForSeconds(dashForwardRecovery / dashForwardMaxValue);
            dashForwardValue++;
            sliderDashForward.value = dashForwardValue;
            isRecoveryDashForward = false;
        }
    }
}
