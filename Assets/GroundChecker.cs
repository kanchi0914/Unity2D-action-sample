using UnityEngine;

public class GroundChecker : MonoBehaviour
{

    Human human;

    // Start is called before the first frame update
    void Start()
    {
        human = transform.root.gameObject.GetComponent<Human>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "spike")
        {
            SetDamage();
        }
        else
        {
            human.Land(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "spike")
        {
            SetDamage();
        }
        else
        {
            human.Land(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        human.Land(false);
    }

    private void SetDamage()
    {
        human.SetDamage(20);
    }
}
