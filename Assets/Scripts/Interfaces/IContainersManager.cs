public interface IContainersManager
{
    public void MoveContainers(float delta);
    public void ReturnContainerToPool(LetterContainerParent cointainer, bool wasPlaced);
    public void RemoveContainerFromPool(LetterContainerParent cointainer);
    public void ReceiveContainers(string[] containers);
}
