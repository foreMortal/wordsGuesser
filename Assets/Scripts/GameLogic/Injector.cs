using UnityEngine;
using Zenject;

public class Injector : MonoInstaller
{
    [SerializeField] private ContainersManager _containersManager;
    [SerializeField] private WordsManager _wordsManager;
    [SerializeField] private VictoryManager _victoryManager;

    public override void InstallBindings()
    {
        Container.Bind<IContainersManager>().FromInstance(_containersManager);
        Container.Bind<IWordsManager>().FromInstance(_wordsManager);
        Container.Bind<IVicatoryManager>().FromInstance(_victoryManager);
    }
}
