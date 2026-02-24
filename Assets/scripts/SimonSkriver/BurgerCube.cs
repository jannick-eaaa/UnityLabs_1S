using UnityEngine;

public class BurgerCube : MonoBehaviour
{
    Transform player;
    
    [SerializeField]
    AudioClip soundClip;

    void Start() {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    void Update() {
        if (Vector3.Distance(transform.position, player.position) <= 1.5f){
            player.GetComponent<AudioSource>().PlayOneShot(soundClip, 1f);
            Destroy(gameObject);
        }
    }
}