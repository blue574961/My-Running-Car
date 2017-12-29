using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField, Range(0f, 50f)]
    private float speed = 10f;

    public float _horizontal = .0f;
    public float _vertical = .0f;

    private void Awake()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
    }

    private void Update ()
    {
        float deltaTime = Time.deltaTime;

        _horizontal = Input.GetAxis("Horizontal") * speed * deltaTime;
        _vertical = Input.GetAxis("Vertical") * speed * deltaTime;
    }

    private void FixedUpdate()
    {
        Vector3 origin = Vector3.zero;

        Quaternion hq = Quaternion.AngleAxis(-_horizontal, Vector3.up);
        Quaternion vq = Quaternion.AngleAxis(_vertical, Vector3.right);

        Quaternion q = hq * vq;

        _rigidbody.MovePosition(q * (transform.position - origin) + origin);
        _rigidbody.MoveRotation(transform.rotation * q);    
    }
   
}