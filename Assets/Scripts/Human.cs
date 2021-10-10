
using System.Collections;
using UnityEngine;

public class Human : Collide
{
    private Coroutine _moveToSnake;
    private BodyColor _bodyColor;

    public BodyColor BodyColor { get => _bodyColor; set => _bodyColor = new BodyColor(GetComponent<MeshRenderer>()); }

    public void StartMoving(Transform target, float pullSpeed)
    {
      _moveToSnake =  StartCoroutine(Moving(target,pullSpeed));
    }

    private IEnumerator Moving(Transform target, float pullSpeed)
    {
        while (true)
        {
           transform.position = Vector3.MoveTowards(transform.position, target.position, pullSpeed * Time.deltaTime);
           yield return null;
        }
    }

    public override void Destroy(float time)
    {
        Destroy(gameObject, time); 
        
        
    }
    private void OnDestroy()
    {   
        if(_moveToSnake != null)
        StopCoroutine(_moveToSnake);
    }
}
