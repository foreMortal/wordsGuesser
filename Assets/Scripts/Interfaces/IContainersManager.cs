using Cysharp.Threading.Tasks;

public interface IContainersManager
{
    public void MoveContainers(float delta);
    public void ReturnContainerToPool(LetterContainerParent cointainer, bool wasPlaced);
    public void RemoveContainerFromPool(LetterContainerParent cointainer);
    public UniTask ReceiveContainers(string[] containers);
}
