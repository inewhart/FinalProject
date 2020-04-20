using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public Player PlayerObject;
    private GameObject PlayerGameObject;
    private GameObject Player;
    private float Health;
    private float speed = 2f;
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
        PlayerObject = PlayerGameObject.GetComponent<Player>();
    }
    void Start()
    {
        
    }
    void DummytHit()
    {
        Health -= Damage;
        if (Health <= 0.0f) 
        { 
            Destroy(this);
            Death.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player) 
            return; 
    
        var distance = Vector3.Distance( Player.transform.position, transform.position);
    
        if ( distance < 100  ) 
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
