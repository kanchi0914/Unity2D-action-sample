using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using DG.Tweening;

public class Human : MonoBehaviour
{
    public int MaxHP = 100;

    public delegate void ValueChangedHandler(int preValue);
    public event ValueChangedHandler HpChanged;

    public int CurrentHP
    {
        get { return currentHp; }
        set
        {
            if (currentHp != value)
            {
                var pre = currentHp;
                currentHp = value;
                HpChanged(pre);
            }
        }
    }
    int currentHp = 100;

    private bool isJumping = false;
    private bool isInvincible = false;
    public string Name { get; private set; } = "";

    Rigidbody2D rigidBody;

    public float PerHP
    {
        get
        {
            float value = (float)CurrentHP / (float)MaxHP;
            return Mathf.Clamp(value, 0, 1);
        }
        private set { }
    }

    void Start()
    {
        var eventTrigger = GetComponent<EventTrigger>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping)
        {
            Land(false);
            rigidBody.AddForce(transform.up * 1200f);
        }
        if (true)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rigidBody.AddForce(transform.right * -100f);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rigidBody.AddForce(transform.right * 100f);
            }
        }
        if (rigidBody.velocity.x > 15f)
        {
            rigidBody.velocity = new Vector2(15f, rigidBody.velocity.y);
        }
        else if (rigidBody.velocity.x < -15f)
        {
            rigidBody.velocity = new Vector2(-15f, rigidBody.velocity.y);
        }
    }

    public void SetDamage(int n)
    {
        if (!isInvincible)
        {
            isInvincible = true;
            StartCoroutine(AddInvincible());
            var renderer = GetComponent<SpriteRenderer>();
            Sequence seq = DOTween.Sequence();
            seq.Append(renderer.DOColor(new Color(1f, 1f, 1f, 0f), 0.1f).SetLoops(9));
            seq.Append(renderer.DOColor(new Color(1f, 1f, 1f, 1f), 0f));
            rigidBody.AddForce(new Vector3(-1.0f, 1.0f, 0) * 900f);
            CurrentHP -= n;
        }
    }

    IEnumerator AddInvincible()
    {
        yield return new WaitForSeconds(1.0f);
        isInvincible = false;
    }

    public void Land(bool isLanding)
    {
        isJumping = !isLanding;
    }

}
