using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    private Player PlayerObject;
    private GameObject PlayerGameObject;
    private GameObject Player;
    private float Health;
    private float speed = 4f;
    public float Damage;
    public ParticleSystem Death;
    private Animator animator;
    void Awake()
    {
        animator = this.GetComponent<Animator>();
        Health = 100;
        Damage = 20;
    }
    public void Initialize(GameObject player)
    {
        Player = player;
        PlayerObject = Player.GetComponent<Player>();
    }
    void Start()
    {
        
    }
    public void DummyHit()
    {
        Health -= Damage;
        if (Health <= 0.0f) 
        { 
            Death.Play();
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "player")
        {
            Death.Play();
            Destroy(gameObject);
            PlayerObject.Health -= 20; 
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        if (!Player) 
            return; 
    
        var distance = Vector3.Distance( Player.transform.position, transform.position);
    
        if ( distance < 200  ) 
        { 
        
            Vector3 PlayerDir = new Vector3(Player.transform.position.x,transform.position.y,Player.transform.position.z);
            transform.LookAt(PlayerDir);
            var delta = Player.transform.position - transform.position;
            delta.Normalize();
            
            var moveSpeed = speed * Time.deltaTime;
            animator.Play("Z_Walk");
        
            transform.position = transform.position + (delta * moveSpeed);
        } 
        if ( distance < 1  )
        {
            animator.SetTrigger("Player");
        } 
    }
}
