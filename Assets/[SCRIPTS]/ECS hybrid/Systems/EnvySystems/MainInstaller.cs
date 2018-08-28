using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller<MainInstaller>
{
    
    public override void InstallBindings()
    {
        Container.Bind<EnvyRotationHandler>().AsSingle();        
    }
}