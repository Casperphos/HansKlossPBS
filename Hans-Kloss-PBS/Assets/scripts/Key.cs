using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool pickUpAllowed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpAllowed)
        {
            PickUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        uint newKey = uint.Parse(Inventory.GetKey()) + 1;

        if (newKey < 10)
        {
            Inventory.SetKey("0" + newKey.ToString());
        }
        else
        {
            Inventory.SetKey(newKey.ToString());
        }

        Destroy(gameObject);
    }
}
