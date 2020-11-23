using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class Jump : Agent
{
    [SerializeField] private float jumpForce;
    [SerializeField] private KeyCode jumpKey;

    private bool jumpIsReady = true;
    private Rigidbody rBody;
    private Vector3 startingPosition;
    private int score = 0;
    public event Action OnReset;

    public override void Initialize()
    {
        rBody = GetComponent<Rigidbody>();
        startingPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (jumpIsReady)
            RequestDecision();

    }

    public override void OnActionReceived(float[] vectorAction)
    {
        if ( Mathf.FloorToInt(vectorAction[0]) == 1)    
            Jumper();            
    }

    public override void OnEpisodeBegin()
    {
        Reset();
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 0;
        if (Input.GetKey(jumpKey))
            actionsOut[0] = 1;
    }

    private void Jumper()
    {
        if (jumpIsReady)
        {
            rBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.VelocityChange);
            jumpIsReady = false;
        }
    }


    private void Reset()
    {
        score = 0;
        jumpIsReady = true;

        //Reset Movement and Position
        transform.position = startingPosition;
        rBody.velocity = Vector3.zero;

        OnReset?.Invoke();
    }

    private void OnCollisionEnter(Collision collidedObj)
    {
        if (collidedObj.gameObject.CompareTag("Platform"))
            jumpIsReady = true;

        else if (collidedObj.gameObject.CompareTag("Enemy"))
        {
            AddReward(-1.0f);
            Debug.Log(GetCumulativeReward());
            EndEpisode();
        }
           
    }

    private void OnTriggerEnter(Collider collidedObj)
    {
        if (collidedObj.gameObject.CompareTag("score"))
        {
            Debug.Log("score");
            AddReward(0.1f);
            score++;
            ScoreCollector.Instance.AddScore(score);
        }
    }
}
