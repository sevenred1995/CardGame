using UnityEngine;
using System.Collections;
using Assets.Scripts.tools;

public class CreateScreen : MonoBehaviour {

    public int INDEX_1=0;
    public int INDEX_2=1;
    public int INDEX_3=2;//创建角色版面的卡片标号；

    public UIButton[] cards;
    private int[] codes = {0,2,13};//卡片唯一标识符

    [SerializeField]
    private UIInput nameInput;

    private int selected=-1;//表示当前被选中的卡牌

    public GameObject zhezhao;
    public void selectCard(int index)
    {
        if(selected!=-1)
        {
            cards[selected].isEnabled = true;
        }
        selected = index;
        cards[selected].isEnabled = false;
    }
    public void createPlayer()
    {
        try
        {
            if (selected == -1)
            {
                //未选择角色
                WarningUtil.ShowWarningWindow("未选择角色");
                return;
            }
            if (nameInput.value == string.Empty || nameInput.value.Length > 6)
            {
                //昵称不合法
                WarningUtil.ShowWarningWindow("昵称不合法");
                return;
            }
            zhezhao.SetActive(true);
            Player player = WebService1.Instance.createPlayer(GameDataUtil.session, nameInput.value, codes[selected]);
            if (player == null)
            {
                zhezhao.SetActive(false);
                WarningUtil.ShowWarningWindow("角色创建失败!");
            }
            else
            {
                GameDataUtil.playerInfo = player;//保存角色数据
                //跳转至主场景
                Application.LoadLevel(2);
            }
        }
        catch
        {
            WarningUtil.ShowWarningWindow("服务器连接失败！");
        }finally
        {
            zhezhao.SetActive(false);
        }
        

    }
}
