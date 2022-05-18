using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWR : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    [SerializeField] private Rigidbody[] _rbs;

    [SerializeField] private _vectorDir _dir;
    private enum _vectorDir
    {
        Forward,
        Back,
        Right,
        Left
    }

    private Vector3 _dirMove, _dirLook;

    private Rigidbody _rb = null;
    private Animator _anim = null;
    private List<DragComponent> _bones = new List<DragComponent>();

    private Coroutine _die;
    private int _dieFix = 0;

    private bool _isAlive = true;
    private bool _punch = false;

    public bool IsAlive
    {
        get => _isAlive;
        set => _isAlive = value;
    }

    public float Speed
    {
        get => _speed;
    }

    private void Start()
    {
        InitDir();

        _anim = GetComponent<Animator>();

        _rb = GetComponent<Rigidbody>(); ;

        for (int i = 0; i < _rbs.Length; i++)
        {
            _rbs[i].gameObject.AddComponent<DragComponent>();
            _bones.Add(_rbs[i].gameObject.GetComponent<DragComponent>());
        }

        foreach (var i in _bones)
        {
            i.SetMain(this);
        }
    }

    private void InitDir()
    {
        switch (_dir)
        {
            case _vectorDir.Forward:
                _dirMove = Vector3.forward;
                _dirLook = Vector3.back;
                break;
            case _vectorDir.Back:
                _dirMove = Vector3.back;
                _dirLook = Vector3.forward;
                break;
            case _vectorDir.Right:
                _dirMove = Vector3.forward;
                _dirLook = Vector3.right;
                break;
            case _vectorDir.Left:
                _dirMove = Vector3.left;
                _dirLook = Vector3.right;
                break;
        }
    }

    private void Update()
    {
        switch (_isAlive)
        {
            case true:
                if (!_punch)
                {
                    Run();
                }
                break;
            case false:
                Die();
                break;
        }
    }

    private void Run()
    {
        //_rb.velocity = Vector3.back * _speed;

        //for (int i = 0; i < _rbs.Length; i++)
        //{
        //    _rbs[i].velocity = Vector3.back * _speed;
        //}

        transform.Translate(_dirMove * _speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(_dirLook);
        //transform.rotation = Quaternion.LookRotation(_rb.velocity);

    }

    public void AliveStatus(bool b)
    {
        _isAlive = b;
    }

    public void AnimatorStatus(bool b)
    {
        _anim.enabled = b;
    }

    public void DelRB()
    {
        _rb = null;
    }

    private void Die()
    {
        Destroy(gameObject, 5f);
        //_die = StartCoroutine(DieCoroutine());
    }

    public void PunchCastle()
    {
        _punch = true;
    }

    //Fix Die Anim!
    private IEnumerator DieCoroutine()
    {
        Debug.Log("Coroutine");
        yield return new WaitForSecondsRealtime(2);

        while (gameObject.activeSelf)
        {
            gameObject.transform.localScale = new Vector3(transform.localScale.x - 0.01f, transform.localScale.y - 0.01f, transform.localScale.y - 0.01f);
            yield return new WaitForSecondsRealtime(1);

            if (gameObject.transform.localScale == Vector3.zero)
            {
                gameObject.SetActive(false);
            }
        }

        Destroy(gameObject);
        StopCoroutine(_die);
        _die = null;

    }
}
