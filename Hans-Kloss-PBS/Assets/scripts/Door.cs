using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool openAllowed;
    private bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().sortingLayerName = "Background";
    }

    // Update is called once per frame
    void Update()
    {
        if (!open)
        {
            CheckIfOpenable();
        }

        if (openAllowed && !open)
        {
            gameObject.GetComponent<Renderer>().sortingLayerName = "Foreground";
            open = true;
            RemoveKey();
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

    private void RemoveKey()
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
    }

    private void CheckIfOpenable()
    {
        if (Inventory.GetKey() != "00")
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
