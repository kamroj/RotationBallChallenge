using UnityEngine;
using Zenject;
using RotationBall.UI;
using RotationBall.LevelChange;

public class InstallerUI : MonoInstaller<InstallerUI>
{
    [SerializeField] ButtonsCompoments buttonsCompoments;    

    public override void InstallBindings()    {
        
        Container.Bind<ButtonsCompoments>().FromInstance(buttonsCompoments).AsSingle();
        Container.BindInterfacesAndSelfTo<ButtonsView>().AsSingle();
    }
}