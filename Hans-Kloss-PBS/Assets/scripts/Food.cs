using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (gameObject.tag == "Ham")
            {
                EatHam();
            }

            if (gameObject.tag == "Coffee")
            {
                DrinkCoffee();
            }
        }
    }

    private void EatHam()
    {

        uint newHam = uint.Parse(GetHam()) + 50;

        if (newHam >= 100)
        {
            newHam = 99;
        }

        SetHam(newHam.ToString());
        Destroy(gameObject);
    }

    private void DrinkCoffee()
    {
        uint newCoffee = uint.Parse(GetCoffee()) + 50;

        if (newCoffee >= 100)
        {
            newCoffee = 99;
        }

        SetCoffee(newCoffee.ToString());
        Destroy(gameObject);
    }

    public static void SetHam(string value)
    {
        GameObject.Find("hotbar_ham").GetComponent<TextMeshProUGUI>().text = value;
    }

    public static void SetCoffee(string value)
    {
        GameObject.Find("hotbar_coffee").GetComponent<TextMeshProUGUI>().text = value;
    }

    public static string GetHam()
    {
        return GameObject.Find("hotbar_ham").GetComponent<TextMeshProUGUI>().text;
    }

    public static string GetCoffee()
    {
        return GameObject.Find("hotbar_coffee").GetComponent<TextMeshProUGUI>().text;
    }

   
}
