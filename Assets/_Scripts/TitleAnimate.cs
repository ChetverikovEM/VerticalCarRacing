using DG.Tweening;
using UnityEngine;

public class TitleAnimate : MonoBehaviour
{
    void OnEnable()
    {
        Sequence myTween = DOTween.Sequence();
        myTween.Append(transform.DOLocalMoveX(-10000f, 0.0f));
        myTween.Append(transform.DOLocalMoveX(400f, 0.3f));
        myTween.PrependInterval(0.3f);
        myTween.Append(transform.DOLocalMoveX(0f, 0.3f));
    }

    void OnDisable()
    {
        var position = transform.position;
        position=new Vector3(-1000f,position.y,position.z);
        transform.position = position;
    }
}
