namespace Photon.Pun
{
    using UnityEngine;
    using UnityEngine.Video;
    [RequireComponent(typeof(VideoPlayer))]
    public class video : MonoBehaviour
    {
        [SerializeField]
        private string relativePath;
        // Start is called before the first frame update
        void Start()
        {
            VideoPlayer player = GetComponent<VideoPlayer>();
            player.source = VideoSource.Url;
            player.url = Application.streamingAssetsPath + "/" + relativePath;
            player.Prepare();
        }
        void Update(){
        }
    }
}