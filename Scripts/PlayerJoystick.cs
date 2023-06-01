using JetBrains.Annotations;
using UnityEngine;

//  player control

public class PlayerJoystick : MonoBehaviour
{
    GameObject player;
    public float speedButtons = 2.5f;
    public float speed = 1;
    Joystick joystickCanvas;      // joystick prefab.
     GameObject buttons;
    int intSettingsContro = 2;
    private void Start()
    {
        Application.targetFrameRate = 60;
        player = GameObject.FindGameObjectWithTag("Player");
        buttons = GameObject.FindGameObjectWithTag("NoJoystick");
        if (PlayerPrefs.HasKey("ControlSettings"))
        {
            int intSettingsControl = PlayerPrefs.GetInt("ControlSettings");
            print("ControlSettings: " + intSettingsControl);
            if (intSettingsControl == 1)
            {
                buttons.SetActive(false);
                joystickCanvas = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
                joystickCanvas.gameObject.SetActive(true);
            }
        }
    }
    void FixedUpdate()
    {
        if (joystickCanvas)
        {//  give the object speed in the direction of the joystick
            player.GetComponent<Rigidbody>().velocity = new Vector3(joystickCanvas.Horizontal * speed, 0, joystickCanvas.Vertical * speed);

            if ((joystickCanvas.Horizontal != 0 || joystickCanvas.Vertical != 0))
            {
                //  rotation of the object in the direction of motion
                player.transform.rotation = Quaternion.LookRotation(player.GetComponent<Rigidbody>().velocity);
                player.GetComponent<Animator>().SetBool("run", true);
            }
            else player.GetComponent<Animator>().SetBool("run", false);
        }
        //--------------------------------------------------------------------------------------

        if (arU)
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speedButtons);
            player.transform.rotation = Quaternion.LookRotation(player.GetComponent<Rigidbody>().velocity);
            player.GetComponent<Animator>().SetBool("run", true);
        }
        if (arD)
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speedButtons);
            player.transform.rotation = Quaternion.LookRotation(player.GetComponent<Rigidbody>().velocity);
            player.GetComponent<Animator>().SetBool("run", true);
        }
        if (arL)
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(-speedButtons, 0, 0);
            player.transform.rotation = Quaternion.LookRotation(player.GetComponent<Rigidbody>().velocity);
            player.GetComponent<Animator>().SetBool("run", true);
        }
        if (arR)
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(speedButtons, 0, 0);
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
