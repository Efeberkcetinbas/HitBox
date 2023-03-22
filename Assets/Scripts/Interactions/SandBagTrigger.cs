
using DG.Tweening;

public class SandBagTrigger : Obstacable
{
    internal override void DoAction(PlayerTrigger player)
    {
        transform.DOLocalMoveZ(0.24f,0.2f);
    }

    internal override void StopAction(PlayerTrigger player)
    {
        transform.DOLocalMoveZ(-0.51864f,1f);
    }
}
