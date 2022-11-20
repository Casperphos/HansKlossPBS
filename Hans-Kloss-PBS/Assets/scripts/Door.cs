using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Door : MonoBehaviour
{
    GameObject door;
    private bool openAllowed;

    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door");
        door.GetComponent<Renderer>().sortingLayerName = "Background";
    }

    // Update is called once per frame
    void Update()
    {
        if (openAllowed)
        {
            uint newKey = uint.Parse(Inventory.GetKey().TrimStart('0')) - 1;

            if (newKey < 10)
            {
                Inventory.SetKey("0" + newKey.ToString());
            }
            else
            {
                Inventory.SetKey(newKey.ToString());
            }

            door.GetComponent<Renderer>().sortingLayerName = "Foreground";
            door.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Inventory.GetKey() != "00")
        {
            openAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            openAllowed = false;
        }
    }
}
