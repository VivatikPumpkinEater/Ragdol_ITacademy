using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragComponent : MonoBehaviour
{
    private EnemyWR _parent = null;
    private Rigidbody _rb;
    private float _posZ;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void SetMain(EnemyWR parent)
    {
        _parent = parent;
    }

    private void OnMouseDown()
    {
        _posZ = transform.position.z;
    }

    private void OnMouseDrag()
    {
        //_isAlive = false;
        //_anim.enabled = false;
       // _parent.DelRB();
        _parent.AliveStatus(false);
        _parent.AnimatorStatus(false);

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = new Vector3(objPosition.x, objPosition.y, _posZ);

        _rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        _rb.isKinematic = false;
        _rb.AddForce(Vector3.forward * _parent.Speed, ForceMode.Impulse);
    }
}
