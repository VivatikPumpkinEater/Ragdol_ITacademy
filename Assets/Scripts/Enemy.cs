using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    //[SerializeField] private Rigidbody[] _rb;
    private bool _isAlive = true;
    private Rigidbody _rb;
    private Animator _anim;

    private float _posZ;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponentInChildren<Animator>();

       // for (int i = 0; i < _rb.Length; i++)
       // {
       //     _rb[i]ameObject.AddComponent<Enemy>();
       // }
    }

    private void Update()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePosition);
        Debug.Log(objPos);
        switch (_isAlive)
        {
            case true:
                Run();
                break;
            case false:
                break;
        }
    }

    private void Run()
    {
        _rb.velocity = Vector3.back * _speed;
        transform.rotation = Quaternion.LookRotation(_rb.velocity);

/*        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(Vector3.back);*/
    }

    private void OnMouseDrag()
    {
        _isAlive = false;
        //_anim.enabled = false;

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(objPosition.x, objPosition.y, transform.position.z);

        _rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        _rb.isKinematic = false;
        _rb.AddForce(Vector3.forward * _speed, ForceMode.Impulse);
    }
}
