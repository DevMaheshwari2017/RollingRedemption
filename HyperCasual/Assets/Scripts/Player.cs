using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private AudioClip moveClip,loseClip;
    [SerializeField]
    private GamePlayManager _gm;
    [SerializeField]
    private GameObject explosionPrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rotateSpeed *= -1f;
            SoundManager.Instance.PlaySound(moveClip);
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //getChild = our circle the first child 
            SoundManager.Instance.PlaySound(loseClip);
            Instantiate(explosionPrefab, transform.GetChild(0).position, Quaternion.identity);
            _gm.GameEnded();
            Destroy(gameObject);
            return;
        }
    }
}
