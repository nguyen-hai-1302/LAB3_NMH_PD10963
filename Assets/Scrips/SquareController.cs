using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SquareController : MonoBehaviour
{
    public float timeRemaining = 60;
    public Text countdownText;
    public Text scoreText;
    public float score = 0;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 0.5f;
    public float nextFire = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;
        transform.Translate(movement * 5f * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
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
            Vector2 firstPosition = new Vector2(-7.5f, 3.5f); 
            transform.position = firstPosition;
        }
        if (col.gameObject.tag.Equals("Pinwheel"))
        {
            Vector2 firstPosition = new Vector2(-7.5f, 3.5f);
            transform.position = firstPosition;
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
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * 10f;
    }

}
