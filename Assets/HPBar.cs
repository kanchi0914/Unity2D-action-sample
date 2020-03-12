using DG.Tweening;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField]
    Human human;

    RectTransform rect;

    void Start()
    {
        human.HpChanged += OnHpChanged;
    }

    void Update()
    {

    }

    void OnHpChanged(int preValue)
    {
        transform.DOScaleX(human.PerHP, 0.2f);
    }
}
