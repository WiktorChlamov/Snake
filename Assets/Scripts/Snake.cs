using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private Transform _head, _pathPF,  _tailPF;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _sideSpeed, _forwardSpeed, _pullSpeed, _changeColorSpeed;
    [SerializeField] private GameManager _gameManager;
    private Vector3 _destinationPoint;
    private List<Transform> _snakePaths = new List<Transform>();
    private Transform _lastPiece = null, _tail;
    private Coroutine _changeColor;
    private bool _isFever = false;
    protected int _timer = 250;
    private BodyColor _bodyColor;

    public BodyColor BodyColor { get => _bodyColor; }
    public float PullSpeed { get => _pullSpeed;}
    public bool IsFever { get => _isFever;}
    public float FeverSpeed { get => _forwardSpeed*3 ;}

    protected void Start()
    {   
        _bodyColor = new BodyColor(GetComponent<MeshRenderer>());
        _bodyColor.SetRandomColor();
        CreateTail();
    }

    private void FixedUpdate()
    {
        if (Input.touchCount>0 && !IsFever && _forwardSpeed>0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = _mainCamera.ScreenPointToRay(touch.position);
            bool hit = Physics.Raycast(ray, out RaycastHit raycastHit);
            if (hit)
            {
                float xRange = Mathf.Clamp(raycastHit.point.x, -6f, 6f);
                _destinationPoint = new Vector3(xRange, _head.transform.position.y, _head.transform.position.z);
                _head.transform.position = Vector3.MoveTowards(_head.transform.position, _destinationPoint, _sideSpeed * Time.deltaTime);
            }
            _head.transform.position += new Vector3(0, 0, _forwardSpeed / 1.2f);
        }
        else if (IsFever)
        {
            Fever();
        }
        else
        {
            _head.transform.position += new Vector3(0, 0, _forwardSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collide>() != null)
        {
            ObjectsColliding colliding = new ObjectsColliding(this, other.GetComponent<Collide>(), _gameManager);
            colliding.Colliding();
        }
    }
    
    public void EatHuman()
    {
        Expand();
    }

    public void StartFever()
    {
        _isFever = true;
    }

    private void NormalState()
    {
        _timer = 250;
        _isFever = false;
        _gameManager.ResetCrystals();
    }

    private void Fever()
    {
        _timer--;
        Vector3 center = new Vector3(0, _head.transform.position.y, _head.transform.position.z);
        _head.transform.position = Vector3.MoveTowards(_head.transform.position, center, _sideSpeed * Time.deltaTime);
        _head.transform.position += new Vector3(0, 0, FeverSpeed);
        if (_timer <=0)
        {
            NormalState();
        }
    }

    private void CreateTail()
    {
        _tail = Instantiate(_tailPF, _head.position, Quaternion.identity);
        _tail.GetComponent<MeshRenderer>().material = BodyColor.Material;
        _tail.GetComponent<SnakePath>().prePath = _head;
    }
   
    private void Expand()
    {   
        Transform target = _lastPiece == null ? _head : _lastPiece;
        Transform path = Instantiate(_pathPF, target.position, Quaternion.identity);
        _snakePaths.Add(path);
        path.GetComponent<SnakePath>().prePath = target;
        path.GetComponent<MeshRenderer>().material = BodyColor.Material;
        _lastPiece = path;
        _tail.GetComponent<SnakePath>().prePath = _lastPiece;
    }

    public void StartChangeColor(Material material)
    {
        BodyColor.SetColor(material);
        _changeColor = StartCoroutine(ChangeColor(_changeColorSpeed));
    }

    private IEnumerator ChangeColor(float waitTime)
    {

        foreach(Transform path in _snakePaths.ToArray())
        {
            path.GetComponent<MeshRenderer>().material = BodyColor.Material;
            yield return new WaitForSeconds(waitTime);
        }
        _tail.GetComponent<MeshRenderer>().material = BodyColor.Material;
        if (_changeColor != null)
        {
            StopCoroutine(_changeColor);
        }
    }

    public void Stop()
    {
        _forwardSpeed = 0;
    }
}
