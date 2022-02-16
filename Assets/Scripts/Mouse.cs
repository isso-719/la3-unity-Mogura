using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    GameObject clickedGameObject;

    public ParticleSystem clickEffect;
    public Transform clickEffectPosition;
    public Transform mouseEffectPosition;

    public AudioSource audioSource;
    public AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(mousePos);

        mouseEffectPosition.position = screenPosition;

        if (Input.GetMouseButtonDown(0))
        {
            clickEffectPosition.position = screenPosition;
            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit2D hit2d = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;
                Destroy(clickedGameObject);
                Debug.Log("Clicked");

                this.SendMessage("CalculateScore", clickedGameObject.tag);

                if (clickedGameObject.tag == "Ok")
                {
                    clickEffect.Play();
                    audioSource.PlayOneShot(clips[0]);
                }
                else if (clickedGameObject.tag == "Special")
                {
                    clickEffect.Play();
                    audioSource.PlayOneShot(clips[1]);
                }
                else if (clickedGameObject.tag == "Ng")
                {
                    audioSource.PlayOneShot(clips[2]);
                }
            }
        }
    }
}
