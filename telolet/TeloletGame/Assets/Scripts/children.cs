using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class children : MonoBehaviour {


    private Vector3 rest;
    private Vector3 go;
    private bool onRest;
    private bool onGo;
    public bool getOnRest() { return onRest; }
    public bool getOnGo() { return onGo; }

    public Text health_bar;
    private float health;
    public float getHealth() { return health; }

    public float coolDownPeriodInSeconds;
    private float timeStamp;

    // Use this for initialization
    void Start()
    {
        go = new Vector2(-8, 2);
        rest = transform.position;
        health = 10;

        onRest = true;
        onGo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            updatePosition();
        }
        if (onGo == true)
        {
            minusHealth();
        }
        else if (onRest == true)
        {
            regenHealth();
        }
        Debug.Log(health);
    }

    public void updatePosition()
    {
        if (transform.position == rest)
        {
            transform.position = go;
            Debug.Log("Om Telolet Om!!!!");

            onGo = true;
            onRest = false;

            timeStamp = Time.time + coolDownPeriodInSeconds;
        }
        else
        {
            if (timeStamp <= Time.time)
            {
                transform.position = rest;
                Debug.Log("Istirahat Sek ben ora pingsan");

                onGo = false;
                onRest = true;
            }
        }

    }

    public void minusHealth()
    {
        if (health > 0)
        {
            health -= Time.deltaTime;
        }
        health_bar.text = "Health: " + ((int)health).ToString();
    }

    public void regenHealth()
    {
        if (health < 10)
        {
            health += Time.deltaTime;
        }
        health_bar.text = "Health: " + ((int)health).ToString();
    }
}
