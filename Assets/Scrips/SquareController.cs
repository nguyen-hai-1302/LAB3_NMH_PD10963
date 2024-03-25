using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SquareController : MonoBehaviour
{
    public float timeRemaining = 60;
    public float score = 0;
    public float moveSpeed;
    public float A;
    public float B;
    public Text countdownText;
    public Text scoreText;
    public Text HPText;
    public GameObject bulletPrefab;
    private Vector2 shootDirection;
    public float HP;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
        HPText.text = "HP: " + HP.ToString();
    }
    IEnumerator Countdown()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
            countdownText.text = "Time: "+ timeRemaining.ToString();
        }
        countdownText.text = "Time's up!";
    }
    // Update is called once per frame
    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            shootDirection = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            shootDirection = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            shootDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            shootDirection = Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;
        transform.Translate(movement * 5f * Time.deltaTime);
    }
    public void LoadThisScene()
    {
        int currenstSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currenstSceneIndex);
    }
    public void LoadNextScene()
    {
        int currenstSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currenstSceneIndex + 1);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Circle"))
        {           
            if (HP > 0)
            {
                Vector2 firstPosition = new Vector2(A, B);
                transform.position = firstPosition;
                HP--;
                HPText.text ="HP: " + HP.ToString();
            }
            else
            {
                LoadThisScene();
            }
        }
        if (col.gameObject.tag.Equals("Pinwheel"))
        {
            if (HP > 0)
            {
                Vector2 firstPosition = new Vector2(A, B);
                transform.position = firstPosition;
                HP--;
                HPText.text = "HP: " + HP.ToString();
            }
            else
            {
                LoadThisScene();
            }
        }
        if (col.gameObject.name.Equals("Box"))
        {
            Debug.Log("Win");
            LoadNextScene();
        }
        if (col.gameObject.tag.Equals("CircleYellow"))
        {
            Destroy(col.gameObject);
            score++;
            scoreText.text = "Score: " + score.ToString();
        }        
    }    
    public void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
        {

            bulletRb.velocity = shootDirection * moveSpeed;  
        }
    }

}
