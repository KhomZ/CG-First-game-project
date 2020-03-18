using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public float speed;
    public float increment;
    private Vector2 targetPos;
    public float maxY;
    public float minY;
    public int health = 3;
    public GameObject moveEffect;
    public Text healthDisplay;
    public GameObject gameOver;
    public GameObject dashSound;
    
    void Update()
    {
        healthDisplay.text = health.ToString();
        if (health <= 0)
        {
           
          
            gameOver.SetActive(true);
            Destroy(gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxY)
        {
            Instantiate(dashSound, transform.position, Quaternion.identity);
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + increment);
            transform.position = targetPos;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minY)
        {
            Instantiate(dashSound, transform.position, Quaternion.identity);
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - increment);
            transform.position = targetPos;
        }
    }
}
