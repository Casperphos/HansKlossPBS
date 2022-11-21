using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HungerController : MonoBehaviour
{
    private readonly float hungerRate = 2.5F;

    // Start is called before the first frame update
    void Start()
    {
        Food.SetHam("99");
        Food.SetCoffee("99");

        InvokeRepeating("IncreaseHunger", 0, hungerRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseHunger()
    {
        if (IsDead())
        {
            CancelInvoke("IncreaseHunger");
            SceneManager.LoadScene("GameOver");
            return;         
        }

        uint ham = uint.Parse(Food.GetHam());
        uint coffee = uint.Parse(Food.GetCoffee());

        if (ham > 0)
        {
            ham--;
            Food.SetHam(ham.ToString());
        }
        if (coffee > 0)
        {
            coffee--;
            Food.SetCoffee(coffee.ToString());
        }
    }

    public bool IsDead()
    {
        if (Food.GetHam() == "0" && Food.GetCoffee() == "0")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
