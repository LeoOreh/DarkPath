using UnityEngine;


public class PlayerMoving : MonoBehaviour
{
    GameObject player;
    float speed = 3f;
    private void Start()
    {
        Application.targetFrameRate = 60;
        player = GameObject.FindGameObjectWithTag("Player");

    }
    void FixedUpdate()
    {
        if (arU)
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
            player.transform.rotation = Quaternion.LookRotation(player.GetComponent<Rigidbody>().velocity);
            player.GetComponent<Animator>().SetBool("run", true);
        }
        if (arD)
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed);
            player.transform.rotation = Quaternion.LookRotation(player.GetComponent<Rigidbody>().velocity);
            player.GetComponent<Animator>().SetBool("run", true);
        }
        if (arL)
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(-speed, 0, 0);
            player.transform.rotation = Quaternion.LookRotation(player.GetComponent<Rigidbody>().velocity);
            player.GetComponent<Animator>().SetBool("run", true);
        }
        if (arR)
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
            player.transform.rotation = Quaternion.LookRotation(player.GetComponent<Rigidbody>().velocity);
            player.GetComponent<Animator>().SetBool("run", true);
        }
        
            
    }

    bool arU = false;
    bool arD = false;
    bool arL = false;
    bool arR = false;
    public void ArUp_DOWN()
    {
        arU = true;
    }
    public void ArUp_UP()
    {
        arU = false;
        player.GetComponent<Animator>().SetBool("run", false);
    }
    public void ArDown_Down()
    {
        arD = true;
    }
    public void ArDown_Up()
    {
        arD = false;
        player.GetComponent<Animator>().SetBool("run", false);
    }
    public void ArLeft_Down()
    {
        arL = true;
    }
    public void ArLeft_Up()
    {
        arL = false;
        player.GetComponent<Animator>().SetBool("run", false);
    }
    public void ArRight_Down()
    {
        arR = true;
    }
    public void ArRight_Up()
    {
        arR = false;
        player.GetComponent<Animator>().SetBool("run", false);
    }
}
