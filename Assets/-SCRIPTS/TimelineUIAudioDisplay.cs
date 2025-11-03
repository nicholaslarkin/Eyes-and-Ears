using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using TMPro;

public class TimelineUIAudioDisplay : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] private TMP_Text uiText;

    private AudioClip currentClip;

    private void Start()
    {
        if (director == null)
            director = GetComponent<PlayableDirector>();

        UpdateAudioName();
    }

    private void Update()
    {
        UpdateAudioName();
    }

    void UpdateAudioName()
    {
        if (director == null || director.playableAsset == null) return;

        TimelineAsset timeline = director.playableAsset as TimelineAsset;
        if (timeline == null) return;

        foreach (var track in timeline.GetOutputTracks())
        {
            if (track is AudioTrack audioTrack)
            {
                foreach (var clip in audioTrack.GetClips())
                {
                    double start = clip.start;
                    double end = clip.end;
                    double currentTime = director.time;

                    if (currentTime >= start && currentTime <= end)
                    {
                        AudioPlayableAsset audioAsset = clip.asset as AudioPlayableAsset;
                        if (audioAsset != null && audioAsset.clip != currentClip)
                        {
                            currentClip = audioAsset.clip;
                            uiText.text = currentClip != null ? currentClip.name : "No Audio";
                        }
                        return;
                    }
                }
            }
        }

        // If nothing matches, clear text or show placeholder
        if (currentClip != null)
        {
            currentClip = null;
            uiText.text = "No Audio Playing";
        }
    }
}
