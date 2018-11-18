using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour {

    public float CheckpointHP_Player = 10.0f;
    public float HP_Player = 6;
    public bool isSad = false;

    public int Magenta_Bar = 0;
    public int Cyan_Bar = 0;
    public int Yellow_Bar = 0;

    public int Magenta_Max = 20;
    public int Cyan_Max = 15;
    public int Yellow_Max = 10;

    public int Gun_Color = 1;

    public Text HPText;

    private float TotalHP;

    void Start()
    {

        

        GameObject HPBar = GameObject.Find("HPBar");
        HPText = HPBar.GetComponent<Text>();

        

    }

    void Update () {


        if(Input.GetButtonDown("GunColorM"))
        {
            Gun_Color = 1;
        }
        if (Input.GetButtonDown("GunColorC"))
        {
            Gun_Color = 2;
        }
        if (Input.GetButtonDown("GunColorY"))
        {
            Gun_Color = 3;
        }

        if (isSad)
        {
            CheckpointHP_Player -= 0.1f;
            Debug.Log("is Sad");

            if (CheckpointHP_Player <= 0f)
            {
                HP_Player -= 1;
                CheckpointHP_Player = 10.0f;
            }

        }
        else if(!(isSad))
        {
            if (CheckpointHP_Player < 10.0f)
            {
                CheckpointHP_Player += 0.1f;
            }
            else if(CheckpointHP_Player > 10.0f)
            {
                CheckpointHP_Player = 10.0f;
            }
        }

        if(HP_Player <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        TotalHP = (HP_Player - 1) + (CheckpointHP_Player / 10);
        HPText.text = "Health: " + TotalHP.ToString();

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision");
        if(col.gameObject.tag == "Deathness")
        {
            HP_Player -= 1;
            Debug.Log("Got Hurt");
        }

        if(col.gameObject.tag == "Sadness")
        {
            isSad = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Sadness")
        {
            isSad = false;

        }
    }

}
