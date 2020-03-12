using DG.Tweening;
using TMPro;
using UnityEngine;

public class DamageUI : MonoBehaviour
{
    [SerializeField]
    GameObject humanObject;
    Human human;
    GameObject damageTextPrefab;

    void Start()
    {
        damageTextPrefab = (GameObject)Resources.Load("Prefabs/DamageText");
        human = humanObject.GetComponent<Human>();
        human.HpChanged += ((int pre) => { SetDamageUi(human.CurrentHP - pre); });
    }

    void Update()
    {

    }

    private void SetDamageUi(int damage)
    {
        var pos = humanObject.transform.position;
        damageTextPrefab.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
        GameObject damageText = Instantiate(damageTextPrefab);
        damageText.transform.SetParent(humanObject.transform.GetComponentInChildren<Canvas>().transform);
        damageText.transform.position = pos;
        damageText.SetActive(true);
        damageText.transform.DOLocalMoveY(2.5f, 1.0f).SetRelative().SetEase(Ease.OutCirc).OnComplete(() => Destroy(damageText));
    }





}
