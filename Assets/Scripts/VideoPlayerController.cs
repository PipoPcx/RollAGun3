using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Referencia al componente VideoPlayer
    public string nextSceneName; // Nombre de la escena a la que quieres cambiar
    public GameObject videoScreen; // Referencia al objeto que muestra el video

    private void Start()
    {
        videoPlayer.loopPointReached += OnVideoFinished;
        videoPlayer.Play(); // Iniciar la reproducción del video
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        videoPlayer.Stop(); // Detener la reproducción del video
        SceneManager.LoadScene(nextSceneName); // Cambiar a la siguiente escena
    }
}


