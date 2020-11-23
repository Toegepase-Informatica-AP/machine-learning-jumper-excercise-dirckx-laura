using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{

    private float speed = 10;

    private Rigidbody Rigidbody;

    private float randomizedSpeed = 0f;


    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        randomizedSpeed = speed * Random.Range(0.5f, 2f);
        Rigidbody.velocity = new Vector3(0,0,  randomizedSpeed);
    }
}