using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControl : MonoBehaviour
{
    private UI ui;
    public swipe swipe;
    private float h, v;
    public float speed;
    private float tempSpeed;
    Vector3 movement;
    private float movementDirection;
    private int PlayerScore = 0;
    public float speedPowerUpTimer;
    bool powerPickedup;
    Scene m_Scene;
    public float powerSpeed;
    void Start()
    {
        powerPickedup = false;
        tempSpeed = speed;
        m_Scene = SceneManager.GetActiveScene();
        if (m_Scene.name == "level1")
        {
            ui = GameObject.FindGameObjectWithTag("manager").GetComponent<UI>();
        }
    }
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (powerPickedup)
        {
            speedPowerUpTimer -= Time.deltaTime;
            speed = powerSpeed;
        }
        if (speedPowerUpTimer <= 0)
        {
            speed = tempSpeed;
        }
     // Debug.Log(PlayerScore);

        //if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    Quaternion q = Quaternion.Euler(0, -90, 0);
        //    transform.rotation = q;
        //}

        //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    Quaternion q = Quaternion.Euler(0, 0, 0);
        //    transform.rotation = q;
        //}
        //if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    Quaternion q = Quaternion.Euler(0, -180, 0);
        //    transform.rotation = q;
        //}
        //if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    Quaternion q = Quaternion.Euler(0, 90, 0);
        //    transform.rotation = q;
        //}

        //if (h < 0)
        //{
        //    movementDirection = -1;
        //    movement = new Vector3(0, 0, -movementDirection) * speed;
        //}
        //if (h > 0)
        //{
        //    movementDirection = 1;
        //    movement = new Vector3(0, 0, movementDirection) * speed;
        //}
        //if (v < 0)
        //{
        //    movementDirection = -1;
        //    movement = new Vector3(0, 0, -movementDirection) * speed;
        //}
        //if (v > 0)
        //{
        //    movementDirection = 1;
        //    movement = new Vector3(0, 0, movementDirection) * speed;
        //}
        if (swipe.SwipeLeft)
        {

            Quaternion q = Quaternion.Euler(0, -90, 0);
            transform.rotation = q;
            movementDirection = -1;
            movement = new Vector3(0, 0, -movementDirection) * speed;

        }
        if (swipe.SwipeRight)
        {
            Quaternion q = Quaternion.Euler(0, 90, 0);
            transform.rotation = q;
            movementDirection = 1;
            movement = new Vector3(0, 0, movementDirection) * speed;
        }
        if (swipe.SwipeDown)
        {

            Quaternion q = Quaternion.Euler(0, -180, 0);
            transform.rotation = q;
            movementDirection = -1;
            movement = new Vector3(0, 0, -movementDirection) * speed;

        }
        if (swipe.SwipeUp)
        {
            Quaternion q = Quaternion.Euler(0, 0, 0);
            transform.rotation = q;
            movementDirection = 1;
            movement = new Vector3(0, 0, movementDirection) * speed;
        }
        playerMovement();


    }
    void playerMovement()
    {
        transform.Translate(movement);
    }
    private void OnTriggerEnter(Collider collison)
    {
        if (collison.tag == "Food")
        {
            GameObject foodobj = collison.transform.gameObject;

            if (foodobj != null)
            {
                Destroy(foodobj);
                ui.foodIncrease();
                PlayerScore += 10;
            }

        }
        if (collison.tag == "speedpower")
        {
            GameObject superfood = collison.transform.gameObject;
            if (superfood != null)
            {
                speedPowerUpTimer = 2f;
                powerPickedup = true;
                Destroy(superfood);
            }
        }
    }
}
