using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    public SoundLibrary library;
    public static MusicManager instance;

    [SerializeField]
    private AudioSource audioSource;

    // ������� ����, ������� ������
    private AudioClip currentTrack;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        // �������� ��������� AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.volume = 0.5f;
    }

    public void TurnOnMusic()
    {
        audioSource.volume = 1f;
    }

    public void TurnOffMusic()
    {
        audioSource.volume = 0f;
    }

    public void PlayMusic(string trackName, float fadeDuration = 0.5f)
    {
        AudioClip nextTrack = library.GetClipFromName(trackName);

        // �������� �� ��, �� ������ �� ��� ���� ����
        if (nextTrack != null && nextTrack != currentTrack && SoundManager.soundEnabled)
        {
            Debug.Log(nextTrack.name);
            StartCoroutine(AnimateMusicCrossfade(nextTrack, fadeDuration));
            currentTrack = nextTrack;
        }
    }

    IEnumerator AnimateMusicCrossfade(AudioClip nextTrack, float fadeDuration = 0.5f)
    {
        // ������������� ��������������� �������� �����
        audioSource.Stop();

        float startVolume = audioSource.volume;
        // ������������� ����� ����
        audioSource.clip = nextTrack;

        // �������� ��������������� ������ �����
        audioSource.Play();

        // ������ ����������� ��������� ������ �����
        while (audioSource.volume < startVolume)
        {
            audioSource.volume += startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }
    }
}
