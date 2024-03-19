using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SquareController : MonoBehaviour
{
    public float timeRemaining = 60;
    public Text countdownText;
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
            Vector2 firstPosition = new Vector2(-8f, 1.5f); 
            transform.position = firstPosition;
        }
        if (col.gameObject.name.Equals("Box"))
        {
            Debug.Log("Win");
            LoadNextScene();
        }
    }

}
