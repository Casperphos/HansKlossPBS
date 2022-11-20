using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void SetKey(string value)
    {
        GameObject.Find("hotbar_key").GetComponent<TextMeshProUGUI>().text = value;
    }

    public static void SetSchemeNormal(string value)
    {
        GameObject.Find("hotbar_scheme_normal").GetComponent<TextMeshProUGUI>().text = value;
    }

    public static void SetSchemeTorn(string value)
    {
        GameObject.Find("hotbar_scheme_torn").GetComponent<TextMeshProUGUI>().text = value;
    }

    public static string GetKey()
    {
        return GameObject.Find("hotbar_key").GetComponent<TextMeshProUGUI>().text;
    }

    public static string GetSchemeNormal()
    {
        return GameObject.Find("hotbar_scheme_normal").GetComponent<TextMeshProUGUI>().text;
    }

    public static string GetSchemeTorn()
    {
        return GameObject.Find("hotbar_scheme_torn").GetComponent<TextMeshProUGUI>().text;
    }

    public static void SetHam(string value)
    {
        GameObject.Find("hotbar_ham").GetComponent<TextMeshProUGUI>().text = value;
    }
}
