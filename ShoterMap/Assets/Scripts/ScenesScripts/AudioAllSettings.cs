using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioAllSettings : AwakeMonoBehaviour
{
    #region [SINGLETON ACTIVE]
    public static AudioAllSettings _singleton;

    private void SingletonActive()
    {
        _singleton = this;

        if (_singleton == null)
        {
            _singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (_singleton != this)
            Destroy(this.gameObject);
    }
    #endregion

    [SerializeField] private GameObject _audioGame;

    protected internal static AudioSource _weaponsAudio;
    protected internal static AudioSource _musicGameAudio;

    [Header("AudioSettings")]
    [SerializeField] private Slider _volumeWeapon;
    [SerializeField] private Slider _volumeMusic;
    protected internal static float _volumeWeaponToFloat;
    protected internal static float _volumeMusicToFloat;

    [Header("AudioMusicBackGround")]
    [SerializeField] private AudioClip _musicGameMenu;
    [SerializeField] private AudioClip _musicGamePlay;
    private bool _playingMusicZone = false;

    private void Start()
    {
        SingletonActive();
        FindObjects();
    }

    private void FindObjects()
    {
        _weaponsAudio = _audioGame.transform.GetChild(0).GetComponent<AudioSource>();
        _musicGameAudio = _audioGame.transform.GetChild(1).GetComponent<AudioSource>();

        if (_volumeWeapon != null && _volumeMusic != null)
        {
            _weaponsAudio.volume = _volumeWeaponToFloat;
            _musicGameAudio.volume = _volumeMusicToFloat;

            _volumeWeapon.value = _volumeWeaponToFloat;
            _volumeMusic.value = _volumeMusicToFloat;
        }
    }

    private void Update()
    {
        MusicGameSettings();
        AssignmentParametersSounds();
    }

    private void AssignmentParametersSounds()
    {
        if (_volumeWeapon != null && _volumeMusic != null)
        {
            _volumeWeaponToFloat = _volumeWeapon.value;
            _volumeMusicToFloat = _volumeMusic.value;
        }

        _weaponsAudio.volume = _volumeWeaponToFloat;
        _musicGameAudio.volume = _volumeMusicToFloat;
    }

    private void MusicGameSettings()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 && _playingMusicZone == false)
            MusicGameBackGroundPlay(_musicGameMenu);
        else if (SceneManager.GetActiveScene().buildIndex == 1 && _playingMusicZone == false)
            MusicGameBackGroundPlay(_musicGamePlay);
        else if (SceneManager.GetActiveScene().buildIndex == 2 && _playingMusicZone == false)
            MusicGameBackGroundPlay(_musicGamePlay);
    }

    private void MusicGameBackGroundPlay(AudioClip nameMusic)
    {
        _musicGameAudio.PlayOneShot(nameMusic);
        _playingMusicZone = true;
        _musicGameAudio.loop = true;

    }

}
