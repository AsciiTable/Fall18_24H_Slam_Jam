using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour {

    public float CheckpointHP_Player = 10.0f;
    public int HP_Player = 6;
    public bool isSad = false;

    public int Magenta_Bar = 0;
    public int Cyan_Bar = 0;
    public int Yellow_Bar = 0;

    private int Magenta_Max = 20;
    private int Cyan_Max = 15;
    private int Yellow_Max = 10;

	void Start () {
		
	}
	
	void Update () {
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

        if(HP_Player == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
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
