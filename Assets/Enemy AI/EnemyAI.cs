using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]

public class EnemyAI : MonoBehaviour
{
    public float sight;
    [Range (0, 1)] public float accuracy;
    [SerializeField] int clipSize = 8;
    [SerializeField] float turnSpeed = 2;
    [SerializeField] Transform[] patrolPoints;
    public GameObject muzzelFlash;
    public Transform muzzelSpawn;
    const float reloadTime = 3.3f;
    const float ShootTime = 0.5f;
    Transform player;
    RaycastHit hit;
    Animator anim;
    NavMeshAgent agent;
    Vector3 worldDeltaPosition;
    Vector3 smoothDeltaPosition;
    Vector3 velocity;
    int bullets;
    int currentDestination;
    float enableShoot;
    float enableReload;
    bool found;
    public AudioSource shoot_sound;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        bullets = clipSize;
        enableShoot = ShootTime;
        enableReload = reloadTime;
        found = false;
    }

    void Update()
    {
        if (anim.GetAnimatorTransitionInfo(0).IsName("Reload -> Shoot") || anim.GetAnimatorTransitionInfo(0).IsName("Reload -> Move"))
        {
            bullets = clipSize;
        }
        if (agent.desiredVelocity.sqrMagnitude > 0.01f)
        {
            anim.SetFloat("Forward", agent.velocity.sqrMagnitude / agent.desiredVelocity.sqrMagnitude);
        }

        if (anim.GetBool("Reloading") && !anim.GetBool("Shooting"))
        {
            anim.SetBool("Shooting", true);
           
        }
    }

    void FixedUpdate()
    {
        float dis = Vector3.Distance(player.position, transform.position);

        if (found && dis > sight)
        {
            agent.destination = player.position;
            anim.SetBool("Shooting", false);
        }
        else if (!agent.pathPending && agent.remainingDistance < 0.05f && !found && dis > sight)
        {
            Patrol();
        }

        if (dis < sight)
        {
            agent.isStopped = true;
            found = true;
            Debug.DrawLine(transform.position + Vector3.up, player.position);
            if (Physics.Linecast(transform.position + Vector3.up, player.position, out hit))
            {
                if (hit.transform == player)
                {
                    anim.SetBool("Crouching", false);
                    SmoothLookAt();
                    agent.isStopped = true;
                    
                    if (enableShoot > ShootTime && bullets > 0)
                    {
                        enableShoot = 0;
                        ShootPlayer();
                    }
                    else if (bullets == 0 && enableReload > reloadTime)
                    {
                        enableReload = 0;
                        StartCoroutine(ReloadGun());
                    }
                }
                else
                {
                    anim.SetBool("Crouching", true);
                }
            }
            else
            {
                anim.SetBool("Crouching", false);
                anim.SetBool("Shooting", false);
                agent.isStopped = false;
            }
        }
        else
        {
            anim.SetBool("Crouching", false);
            anim.SetBool("Shooting", false);
            agent.isStopped = false;
        }

        enableShoot += Time.fixedDeltaTime;
        enableReload += Time.fixedDeltaTime;
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0)
        {
            return;
        }

        agent.destination = patrolPoints[currentDestination].position;
        currentDestination = (currentDestination + 1) % patrolPoints.Length;
    }

    void OnAnimatorMove ()
    {
        transform.position = agent.nextPosition;
    }

    public void ShootPlayer()
    {
        anim.SetBool("Shooting", true);
        shoot_sound.Play();

        if (Random.value < accuracy)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().ApplyDamage();
        }
        bullets--;
        Invoke("muzzle", 2.0f);
    }
    void muzzle()
    {
        var clone = Instantiate(muzzelFlash, muzzelSpawn.transform.position+transform.forward/5, muzzelSpawn.transform.rotation * Quaternion.Euler(0,0,90));
        Destroy (clone, 0.05f);
    }
    public IEnumerator ReloadGun()
    {
        anim.SetBool("Reloading", true);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Reloading", false);
    }
    void SmoothLookAt()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), turnSpeed * Time.deltaTime);
    }
}
