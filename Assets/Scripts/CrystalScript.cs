using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CrystalScript : MonoBehaviour
{
    private void Start()
    {
        Sequence upAndDawn = DOTween.Sequence();
        upAndDawn.Append(transform.DOMoveY(1f, 0.5f)).Append(transform.DOShakeScale(2f,0.3f))
            .Append(transform.DOMoveY(0.3f, 0.5f))
            .SetLoops(100,LoopType.Restart).Play();
    }
}
