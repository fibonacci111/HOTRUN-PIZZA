using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can_Text_Rotation : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private int _distance;
    //[SerializeField] private Vector3 _transform;
    private float _x;
    private float _y;
    private float _z;

    // Start is called before the first frame update
    void Start()
    {
        _rotation = new Vector3(0, 0, 0.1f);
        _distance = 0;
        //_transform = new Vector3(0, 0.1f, 0);
        _x = this.transform.position.x;
        _y = this.transform.position.y;
        _z = this.transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.rotation *= Quaternion.Euler(_rotation);
        var _position = Mathf.PingPong(Time.time, _distance);
        transform.position = new Vector3(_x, _y *_position, _z);
    }
}
