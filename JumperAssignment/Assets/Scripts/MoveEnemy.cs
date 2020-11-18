using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public int pos;
    public int speed;
    Vector3 _startingPos;
    Transform _trans;
    void Start()
    {
        _trans = GetComponent<Transform>();
        _startingPos = _trans.position;
    }
    void Update()
    {
        _trans.position = new Vector3(_startingPos.x, _startingPos.y , _startingPos.z + Mathf.PingPong(Time.time * speed, pos));
    }
}