using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class defining motion of target prefab

///[RequireComponent(typeof(SongData))]
public class TargetMotion : MonoBehaviour
{
    //pulls static variable from song length
    //defines target motion speed based on song data
    //[SerializeField]
    private float speed= SongData.GetBPM();

    //[SerializeField]
    //private SongData song;

    

    // Start is called before the first frame update
    void Awake()
    {
        //load SongData S.O. asset: Assets/
        //song = Resources.Load<SongData>("Mundian To Bach Ke");
        //speed = song.beatPM;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //restricts motion of target to x-plane at speed defined by beat length
        transform.Translate(speed * Time.deltaTime,0f, 0f, Space.World);

        
        //destroy's gameobject when its position passes camera position
        if (transform.position.x > Camera.main.transform.position.x)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        //Debug.Log(gameObject.name + " triggered " + collider.gameObject.name);
        var part = GetComponentInChildren<ParticleSystem>();

        //if trigger
        //play particle system
        


        
        if (collider.gameObject.CompareTag("interactor"))
        {
                       
            part.Play();

            //destroy all children game objects except explosion
            for (int i = 0; i < transform.childCount-1; i++)
            {
                GameObject go = transform.GetChild(i).gameObject;
                Destroy(go);
            }
            ScoreCounter.score++;
        }


    }

    private void DestroyChildren()
    {
        //
    }
}
