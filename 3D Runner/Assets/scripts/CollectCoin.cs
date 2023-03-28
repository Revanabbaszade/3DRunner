using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class CollectCoin : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;
    public PlayerController playerController;
    public int maxScore;
    public Animator PlayerAnim;
    public GameObject Player;
    public GameObject EndPanel;

    private void Start()
    {
        PlayerAnim = Player.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("End"))
        {
            Debug.Log("Congrats!..");

            playerController.runningSpeed = 0;
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
            EndPanel.SetActive(true);

            if (score >= maxScore)
            {
                // Debug.Log("WIN!..");
                PlayerAnim.SetBool("win", true);
            }
            else
            {
                //  Debug.Log("you Lose!..");
                PlayerAnim.SetBool("lose", true);
            }


        }

    }
    public void RestartGame() 
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collision"))
        {
            Debug.Log("Touched obstacle!..");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddCoin()
    {
        score++;    
        CoinText.text = "Score: " + score.ToString(); 
       
    }
}
