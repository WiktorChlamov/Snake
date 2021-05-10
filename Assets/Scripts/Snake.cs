using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Human
{
    [SerializeField] private Transform head, pathPF, tail, tailPF,gameOver;
    [SerializeField] Camera mainCamera;
    [SerializeField] int sideSpeed;
    [SerializeField] float forwardSpeed;
    [SerializeField] private Hud gameManager;
    private Vector3 destinationPoint;
    private List<Transform> snakePaths = new List<Transform>();
    private Transform lastPiece = null;
    public Coroutine coroutine;
    protected int eaten;
    protected int crystals;
    [HideInInspector]
    public bool fever = false,eating = false;
    protected int Timer = 250;
    private void FixedUpdate()
    {
        if (Input.touchCount>0 && !fever && forwardSpeed>0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = mainCamera.ScreenPointToRay(touch.position);
            bool hit = Physics.Raycast(ray, out RaycastHit raycastHit);
            if (hit)
            {
                float xRange = Mathf.Clamp(raycastHit.point.x, -6f, 6f);
                destinationPoint = new Vector3(xRange, head.transform.position.y, head.transform.position.z);
                head.transform.position = Vector3.MoveTowards(head.transform.position, destinationPoint, sideSpeed * Time.deltaTime);
            }
            head.transform.position += new Vector3(0, 0, forwardSpeed / 1.2f);
        }
        else if (fever)
        {
            Fever();
        }
        else
        {
            head.transform.position += new Vector3(0, 0, forwardSpeed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Human>())
        {
                Eating(other.transform);
        }
        else if(other.GetComponent<CrystalScript>())
        {
            CollectCrystal(other.transform);
        }
        
    }
    
    public void GameOver()
    {
        forwardSpeed = 0;
        gameOver.gameObject.SetActive(true);
    }
    private void CollectCrystal(Transform crystal)
    {
        crystal.position = Vector3.MoveTowards(crystal.position, head.position, sideSpeed * Time.deltaTime);
        Destroy(crystal.gameObject, 0.1f);
        crystals++;
        if (crystals >= 3 && !fever)
            {
                fever = true;
                forwardSpeed *= 3;
            }
        gameManager.SetCrystal(crystals);
    }
    private void Eating(Transform food)
    {
        food.position = Vector3.MoveTowards(food.position, head.position, sideSpeed * Time.deltaTime);
        if (food.GetComponent<Human>().material == material || fever)
        {
            eaten++;
            gameManager.SetEaten(eaten);
            Expand();
            Destroy(food.gameObject, 0.1f);
        }
        else GameOver();
    }
    private void NormalState()
    {
        Timer = 250;
        fever = false;
        forwardSpeed /= 3;
        crystals = 0;
        gameManager.SetCrystal(crystals);
    }
    private void Fever()
    {
        Timer--;
        Vector3 center = new Vector3(0, head.transform.position.y, head.transform.position.z);
        head.transform.position = Vector3.MoveTowards(head.transform.position, center, sideSpeed * Time.deltaTime);
        head.transform.position += new Vector3(0, 0, forwardSpeed);
        if (Timer <=0)
        {
            NormalState();
        }
    }
    private void CreateTail()
    {
        tail = Instantiate(tailPF, head.position, Quaternion.identity);
        tail.GetComponent<MeshRenderer>().material = material;
        tail.GetComponent<SnakePath>().prePath = head;
        snakePaths.Add(tail);
    }
    protected void Start()
    {
        CreateTail();
        Expand();
    }
    private void Expand()
    {   
        Transform target = lastPiece == null ? head : lastPiece;
        Transform path = Instantiate(pathPF, target.position, Quaternion.identity);
        snakePaths.Add(path);
        path.GetComponent<SnakePath>().prePath = target;
        path.GetComponent<MeshRenderer>().material = material;
        lastPiece = path;
        tail.GetComponent<SnakePath>().prePath = lastPiece;
    }
    public void StartChangeColor()
    {
        coroutine = StartCoroutine(ChangeColor(0.125f));
    }
        private IEnumerator ChangeColor(float waitTime)
    {
        foreach(Transform path in snakePaths.ToArray())
        {
            path.GetComponent<MeshRenderer>().material = material;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
