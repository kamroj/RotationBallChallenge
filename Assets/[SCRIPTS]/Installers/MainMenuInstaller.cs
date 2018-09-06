using UnityEngine;
using Zenject;
using RotationBall.UI;
using RotationBall.Audio;

public class MainMenuInstaller : MonoInstaller<MainMenuInstaller>
{
    [SerializeField] ButtonsCompoments buttonsCompoments;    

    public override void InstallBindings()
    {        
        Container.Bind<ButtonsCompoments>().FromInstance(buttonsCompoments).AsSingle();
        Container.BindInterfacesAndSelfTo<ButtonsView>().AsSingle();        
    }

  
}