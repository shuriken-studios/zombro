using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Text LeeName;
    public Text ChrisName;
    public Text JohnName;
    public Text LeeWeapon;

    // Start is called before the first frame update
    void Start()
    {
        LeeName.GetComponent<Text>().text = "Lee";
        ChrisName.GetComponent<Text>().text = "Chris";
        JohnName.GetComponent<Text>().text = "John";
        //LeeWeapon.GetComponent<Text>().text = "" Do this after deciding on all of Lee's weapons
        //LeeAmmoCount - Should be one of these for each weapon that's adjusted accordingly depending on the current weapon.

    }

    // Update is called once per frame
    void Update()
    {
        if (LeeController.leeActive)
        {
            LeeName.color = Color.black;
            LeeName.fontSize = 20;
            //LeeName.transform.position = new Vector3(0, 0, 0f);
            ChrisName.color = Color.white;
            ChrisName.fontSize = 15;
            JohnName.color = Color.white;
            JohnName.fontSize = 15;
        }

        if (ChrisController.chrisActive)
        {
            ChrisName.color = Color.black;
            ChrisName.fontSize = 20;
            LeeName.color = Color.white;
            LeeName.fontSize = 15;
            JohnName.color = Color.white;
            JohnName.fontSize = 15;
        }

        if (JohnController.johnActive)
        {
            JohnName.color = Color.black;
            JohnName.fontSize = 20;
            LeeName.color = Color.white;
            LeeName.fontSize = 15;
            ChrisName.color = Color.white;
            ChrisName.fontSize = 15;
        }
    }
}
