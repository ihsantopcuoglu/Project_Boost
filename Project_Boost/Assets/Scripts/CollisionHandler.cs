using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    void OnCollisionEnter(Collision other) 
    {
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
        // todo add sfx upon crash
        // todo add particle effect uppon crash
         GetComponent<Movements>().enabled = false;
         Invoke("LoadNextLevel", levelLoadDelay);
    }
    
    
    void StartCrashSequence()
    {
        // todo add sfx upon crash
        // todo add particle effect uppon crash
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

   void Update() {
        if(Input.GetKeyDown(KeyCode.U)){
            LoadNextLevel();
        }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}