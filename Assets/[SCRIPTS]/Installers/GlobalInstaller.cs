using UnityEngine;
using UnityEngine.UI;
using Zenject;
using RotationBall.LevelChange;
using RotationBall.UI;
using RotationBall;

public class GlobalInstaller : MonoInstaller<GlobalInstaller>
{
    [SerializeField] GameObject levelChanger;
    [SerializeField] GameObject mainMenuButton;
    [SerializeField] MonoCoroutine monoCoroutine;

    public override void InstallBindings()
    {
        //Container.BindInterfacesTo<GameController>().AsCached();
        //Container.Bind<GameController>().AsCached();
        Container.BindInterfacesAndSelfTo<GameController>().AsSingle();        

        Container.Bind<LevelChanger>().FromComponentInNewPrefab(levelChanger).AsSingle();
        //Container.InstantiatePrefab(mainMenuButton);     
        Container.Bind<BackToMenuButton>().FromComponentInNewPrefab(mainMenuButton).AsSingle();
        Container.Bind<MonoCoroutine>().FromInstance(monoCoroutine).AsSingle();
        

    }
}
