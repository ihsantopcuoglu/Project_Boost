using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;


    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem RocketBoost;
    AudioSource audioSource;

    bool isTransitioning = false;
    bool collisionDisabled = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

   

    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning || collisionDisabled){return;}


        switch (other.gameObject.tag) 
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
         GetComponent<Movements>().enabled = false;
         Invoke("LoadNextLevel", levelLoadDelay);
    }
    
    
    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        crashParticles.Play();
        GetComponent<Movements>().enabled = false;
        Invoke ("ReloadLevel", levelLoadDelay);
    }
    
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int NextSceneIndex = currentSceneIndex + 1;
        if (NextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            NextSceneIndex = 0;
        }

        SceneManager.LoadScene(NextSceneIndex);
    }

   void Update() 
   {
        if(Input.GetKeyDown(KeyCode.U))
        {
            LoadNextLevel();
        }


        {
        RespondToDebugKeys();
        }

    
    void RespondToDebugKeys()

        {
        if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled; // toggle collision
        }
        }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}