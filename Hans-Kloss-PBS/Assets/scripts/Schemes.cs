using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Schemes : MonoBehaviour
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
            PickUpAndShow();
        }

        if (GameObject.Find("Schemes").GetComponent<Canvas>().enabled && Input.GetKey(KeyCode.Space))
        {
            HideSchemes();
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

    private void PickUpAndShow()
    {
        if (gameObject.tag == "SchemeTorn")
        {
            uint newSchemeTorn = uint.Parse(Inventory.GetSchemeTorn()) + 1;

            if (newSchemeTorn < 10)
            {
                Inventory.SetSchemeTorn("0" + newSchemeTorn.ToString());
            }
            else
            {
                Inventory.SetSchemeTorn(newSchemeTorn.ToString());
            }
        }

        if (gameObject.tag == "SchemeNormal")
        {
            uint newSchemeNormal = uint.Parse(Inventory.GetSchemeNormal()) + 1;

            if (newSchemeNormal < 10)
            {
                Inventory.SetSchemeNormal("0" + newSchemeNormal.ToString());
            }
            else
            {
                Inventory.SetSchemeNormal(newSchemeNormal.ToString());
            }
        }

        // update the schemes
        UpdateSchemes();

        // disable current canvas
        GameObject.Find("MobileControlsPanel").GetComponent<Canvas>().enabled = false;

        // change canvas to show the schemes
        GameObject.Find("Schemes").GetComponent<Canvas>().enabled = true;

        Destroy(gameObject);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    private void UpdateSchemes()
    {
        string scheme_torn_num = Inventory.GetSchemeTorn();
        string scheme_normal_num = Inventory.GetSchemeNormal();

        // enable the right schemes
        if (scheme_torn_num != "00")
        {
            string scheme_torn_num_full = "torn" + scheme_torn_num;
            GameObject.Find(scheme_torn_num_full).GetComponent<Image>().enabled = true;
        }

        if (scheme_normal_num != "00")
        {
            string scheme_normal_num_full = "normal" + scheme_normal_num;
            GameObject.Find(scheme_normal_num_full).GetComponent<Image>().enabled = true;
        }
    }

    private void HideSchemes()
    {
        // disable current canvas
        GameObject.Find("Schemes").GetComponent<Canvas>().enabled = false;

        // change canvas to show the schemes
        GameObject.Find("MobileControlsPanel").GetComponent<Canvas>().enabled = true;
    }
}
