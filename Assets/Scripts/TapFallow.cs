using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapFallow : MonoBehaviour
{
    [SerializeField] private GameObject _follow = null;
    [SerializeField] private GameObject _followWPhy = null;

    [SerializeField] private float _speed = 10f;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = _followWPhy.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        RaycastHit rayHit;

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }
}
