using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public Transform Player;
    public float speed = 1000f;
    public int a;
    public int c;
    public string d;
    // Start is called before the first frame update
    void Start()
    {
        /*rb.useGravity = false;*/
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0, 0, speed * Time.deltaTime);
        if (Input.GetKeyDown("d") && a!=1)
        {
            Player.transform.position += new UnityEngine.Vector3(35, Player.position.y, Player.position.z).normalized;
            //rb.AddForce(600*Time.deltaTime, 0, 0);
        }
        if (Input.GetKeyDown("a") && a != 1)
        {
            Player.transform.position += new UnityEngine.Vector3(-35, Player.position.y, Player.position.z).normalized;
            //rb.AddForce(0, 0, 6000 * Time.deltaTime);
        }
        if (Input.GetButtonDown("Jump") && a != 1)
        {
            Player.transform.position += new UnityEngine.Vector3(Player.position.x, 35, Player.position.z).normalized;
            //rb.AddForce(0, 99999 * Time.deltaTime, 0);
        }
        if (Input.GetKey("c"))
        {
            c = 1;
        }
        if (GameObject.Find("Player").transform.position.y < -2f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            a = 0;
            c = 0;
            GameObject.Find("Main Camera").GetComponent<CameraFollow>().enabled = true;
        }
        if (a != 1)
        {
            d = ((int)transform.position.z + 46).ToString();
        }
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "block" && c!=1 && collision.collider.name != "Final")
        {
            UnityEngine.Debug.Log("Game Over");
            GameObject.Find("Main Camera").GetComponent<CameraFollow>().enabled = false;
            a = 1;
        }
        if (collision.collider.name == "Final" && a != 1)
        {
            Invoke("change", 1);
        }
    }
    public void change()
    {
        SceneManager.LoadScene("Level02");
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score: "+d);
        if (GameObject.Find("Main Camera").GetComponent<CameraFollow>().enabled == false)
        {
            GUI.Label(new Rect(10, 30, 100, 20), "Game Over.");
        }
    }
}
