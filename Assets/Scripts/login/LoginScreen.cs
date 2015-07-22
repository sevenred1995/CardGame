using UnityEngine;
using System.Collections;
using Assets.Scripts.tools;

public class LoginScreen : MonoBehaviour
{

    #region commponent
    [SerializeField]
    private GameObject loginPanel;
    [SerializeField]
    private GameObject regPanel;
    #endregion

    #region loginPanelCommponent
    [SerializeField]
    private UIInput accountInput;
    [SerializeField]
    private UIInput passwardInput;
    #endregion

    #region regPanelCommponent
    [SerializeField]
    private UIInput r_accountInput;
    [SerializeField]
    private UIInput r_passwardInput;
    [SerializeField]
    private UIInput r_passwardsureInput;
    #endregion

    

    [SerializeField]
    private GameObject zhezhao;
    //登录界面的方法
    public void OnLoginClick_login()
    {
        string account = accountInput.value;
        string passward = passwardInput.value;
        if (account == string.Empty || passward == string.Empty)
        {
           WarningUtil.ShowWarningWindow("请输入正确的账号与密码！");
           return;
        }
        //向服务器发送信息；
        zhezhao.SetActive(true);
        try
        {
            //向服务器发出信息。。
            string result = WebService1.Instance.login(account, passward);//连接服务器，并且返回当前登录的密钥。
            if (result==string.Empty)
            {
                WarningUtil.ShowWarningWindow("账号不存在！");
            }
            else if(result=="-1")
            {
                WarningUtil.ShowWarningWindow("密码错误！");
            }
            else
            {
                GameDataUtil.session = result;
                getPlayer();
               // ShowWarningWindow("登陆成功！"+result);
            }
        }
        catch
        {
            WarningUtil.ShowWarningWindow("服务器连接失败！");
        }
        finally
        {
            zhezhao.SetActive(false);
        }
    }
    public void getPlayer()//获取玩家角色
    {
        zhezhao.SetActive(true);  
        Player player = WebService1.Instance.getPlayer(GameDataUtil.session);//连接服务器获取玩家角色；
        if(player==null)
        {
            //跳转到创建场景、
            Application.LoadLevel("createplayer");
        }
        else
        {
            GameDataUtil.playerInfo = player;//保存当前角色。。
            //已有角色跳转至游戏主场景
            Application.LoadLevel("mainGame");
        }
    }

    public void OnRegClick_login()
    {
        loginPanel.SetActive(false);                      
        regPanel.SetActive(true);
    }
    //注册界面方法

    public void OnRegClick_reg()
    {
        string account=r_accountInput.value.Trim();
        string passward=r_passwardInput.value.Trim();
        if (account == string.Empty || passward == string.Empty)
        {
           // Debug.Log("请输入正确的账号与密码！");
            WarningUtil.ShowWarningWindow("请输入正确的账号与密码！");
            return;
        }
        if(passward!=r_passwardsureInput.value)
        {
            //Debug.Log("与输入的密码不一致！");
            WarningUtil.ShowWarningWindow("与输入的密码不一致！");
            return;
        }
        //屏蔽界面；
        zhezhao.SetActive(true);
        try
        {
           //向服务器发出信息。。
           bool result = WebService1.Instance.register(account, passward);
           if(result)
           {
               WarningUtil.ShowWarningWindow("注册成功！");
           }
           else
           {
               WarningUtil.ShowWarningWindow("注册失败！");
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
    public void OnCancleClick_reg()
    {
        clear_login();
        loginPanel.SetActive(true);
        regPanel.SetActive(false);
    }
    public void clear_login()
    {
        r_accountInput.value = string.Empty; 
        r_passwardInput.value = string.Empty;
        r_passwardsureInput.value = string.Empty;
    }
   
}
