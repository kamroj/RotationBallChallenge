using UnityEngine;
using Zenject;
using RotationBall.LevelChange;
using RotationBall.Audio;
using RotationBall.UI;
using RotationBall;

public class GlobalInstaller : MonoInstaller<GlobalInstaller>
{
    [SerializeField] GameObject levelChanger;
    [SerializeField] GameObject mainMenuButton;
    [SerializeField] MonoCoroutine monoCoroutine;
    [SerializeField] AudioComponents audioComponents;
    [SerializeField] AudioSource audioSource;


    public override void InstallBindings()
    {
        GlobalInstallers();

        SFXGlobalInstallers();

    }

    private void GlobalInstallers()
    {
        Container.BindInterfacesAndSelfTo<GameController>().AsSingle();
        Container.Bind<LevelChanger>().FromComponentInNewPrefab(levelChanger).AsSingle();
        Container.Bind<BackToMenuButton>().FromComponentInNewPrefab(mainMenuButton).AsSingle();
        Container.Bind<MonoCoroutine>().FromInstance(monoCoroutine).AsSingle();
    }

    void SFXGlobalInstallers()
    {
        Container.Bind<AudioComponents>().FromInstance(audioComponents).AsSingle();
        Container.Bind<AudioMenager>().AsSingle();
        Container.Bind<AudioSource>().FromComponentInNewPrefab(audioSource).AsSingle().NonLazy();
        Container.BindInterfacesTo<AudioController>().AsSingle().NonLazy();
    }
}
