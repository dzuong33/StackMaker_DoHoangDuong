using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public static Player instance;
    [SerializeField] GameObject prevBrick;
    [SerializeField] GameObject playerParent;
    public List<GameObject> stackBricks = new List<GameObject>();
    public float speed = 1000f;
    private bool isMoving;

   
    public enum SwipeDirection
    {
        None,
        RIGHT,
        LEFT,
        UP,
        DOWN
    }
    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        rb = GetComponent<Rigidbody>();
        isMoving = false;
    }
    void Update()
    {
        if(rb.velocity == Vector3.zero)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || MobileInput.instance.LEFT)
            {
                rb.velocity = Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || MobileInput.instance.RIGHT)
            {
                rb.velocity = Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || MobileInput.instance.UP)
            {
                rb.velocity = Vector3.forward * speed * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || MobileInput.instance.DOWN)
            {
                rb.velocity = Vector3.back * speed * Time.deltaTime;
            }
        }

    }
    public void PickUpBrick(GameObject pickOb)
    {

        //position to set up for pickup Bricks equals to prevBrick
        pickOb.transform.SetParent(playerParent.transform);
        Vector3 pos = prevBrick.transform.localPosition;
        pickOb.transform.localPosition = pos;
        pos.y -= 0.3f;
        prevBrick.transform.localPosition = pos;

        //change player position
        Vector3 playerPos = transform.position;
        playerPos.y += 0.3f;
        transform.localPosition = playerPos;
    }
    public void SpreadBrick(GameObject brick1)
    {
        Destroy(stackBricks[stackBricks.Count-1]);
        stackBricks.Remove(stackBricks[stackBricks.Count - 1]);
        Vector3 playerPos = transform.position;
        Vector3 brickPos = brick1.transform.localPosition;
        playerPos.y -= 0.3f;
        brickPos.y += 0.3f;
        brick1.transform.localPosition = brickPos;
        transform.localPosition = playerPos;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            rb.velocity = Vector3.zero;
            StartCoroutine(popUpLevelFinish());
        }
    }
    IEnumerator popUpLevelFinish()
    {
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSecondsRealtime(0.5f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        Time.timeScale = 1;
    }
}
