using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BBDC.Model;
using BBDC.BLL;

namespace BBDC.UI
{
    public partial class FrmGame : Form
    {
        public FrmGame()
        {
            InitializeComponent();
        }
        public int gametype;           //游戏类型
        private int _width = 19;            
        private int _height = 9;
        private Color _bgColor;            //背景色
        private Graphics _gpPalette;        //画布
        private List<Block> _blocks;        //蛇块列表
        private Direction _direction;       //前进方向
        private Block _food;                //当前食物
        private Block _foodfalse;           //当前假食物
        private int _size = 40;             //单位大小
        private int _level = 2;             //游戏等级，即游戏速度
        private bool _isGameOver = false;   //是否游戏结束
        private bool _isdcOvertype1 = false;   //是否完成游戏类型2该单词
        private bool _isdcOvertype1only = false;   //完成游戏类型2该单词后单词只判断一次
        private string dc;                  //游戏类型0的单词
        //private string dctype1;             //游戏类型1的单词
        private string dcfalse;             //假单词
        private string dcfood;              //食物块单词
        private string dcsnake;             //蛇块单词
        private string[] dcs;               //单词数组
        private string[] dcmeans;           //单词中文数组
        private int dccount;                //单词总数
        private int dcnumber = 0;           //游戏到第几个单词
        private int dcnumbertype1 = 0;      //游戏类型1的游戏到第几个单词
        private int[] _speed = new int[] {450, 400, 300, 200, 100};
        private string[] zm = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

        UserInfo userInfo = new UserInfo();     //用户模型
        UidInfo uidInfo = new UidInfo();        //用户个人表模型
        DCInfo dcInfo = new DCInfo();           //单词模型
        UserBLL userBLL = new UserBLL();        
        UidBLL uidBLL = new UidBLL();
        DCBLL dcBLL = new DCBLL();

        public List<UidInfo> uidTableList;      //已经背过并没游戏过的单词集合

        private void FrmGame_Load(object sender, EventArgs e)
        {
            uidTableList = new List<UidInfo>();                                                 //实例已经背过并没游戏过的单词集合
            userInfo = userBLL.GetModel(UserLoginInfo.userid);                                  //取得用户模型
            uidTableList = uidBLL.GetListByGame(userInfo.usertable);                    //取得已经背过并没游戏过的单词集合
            if(uidTableList != null)
            {
                dccount = uidTableList.Count;                                                       //取得单词数量
            }
            else
            {
                DialogResult result = MessageBox.Show("你还没尚未游戏过的单词，请先背单词再来游戏或重置单词游戏记录", "提示", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    this.Close();
                    return;
                }
            }
            dcs = new string[dccount];                                                          //实例化单词数组
            dcmeans = new string[dccount];                                                      //实例化单词中文数组
            for (int i = 0; i < dccount; i++)
            {
                dcs[i] = dcBLL.GetModel(uidTableList[i].bookid, uidTableList[i].wordid).word;                   //取得已经背过并没游戏过的单词的内容-单词
                dcmeans[i] = dcBLL.GetModel(uidTableList[i].bookid, uidTableList[i].wordid).mean.ToString();    //取得已经背过并没游戏过的单词的内容-中文
            }
            单词ToolStripMenuItem.Text = "单词：" + dcs[0];
            总共个ToolStripMenuItem.Text = "总共" + dccount.ToString() + "个";
            if (gametype == 1)
            {
                string dclong ="";
                for (int i = 0; i < dccount; i++)
                {
                    dclong += dcs[i] + " ";
                    //dcmeans[i] = dcBLL.GetModel(uidTableList[i].bookid, uidTableList[i].wordid).mean.ToString();    //取得已经背过并没游戏过的单词的内容-中文
                }
                dcs[0] = dclong;
                dccount = 1;
            }
            pictureBox1.Width = _width * _size;         //图片框，即画布大小
            pictureBox1.Height = _height * _size;
            _gpPalette = pictureBox1.CreateGraphics();  //画布
            _bgColor = this.BackColor;                  //游戏背景

            Start();
        }
        #region 菜单项
        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                timer1.Enabled = true;
                开始ToolStripMenuItem.Enabled = false;
                暂停ToolStripMenuItem.Enabled = true;
            }
        }

        private void 暂停ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                开始ToolStripMenuItem.Enabled = true;
                暂停ToolStripMenuItem.Enabled = false;
            }
        }
        private void 重置游戏记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int result = uidBLL.UpdateGame(userInfo.usertable);
                MessageBox.Show("重置成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.timer1.Dispose();
            pictureBox1.Dispose();
            this.Close();
        }
        private void 入门ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._level = 0;
            timer1.Interval = _speed[this._level];
        }

        private void 初等ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._level = 1;
            timer1.Interval = _speed[this._level];
        }

        private void 中等ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._level = 2;
            timer1.Interval = _speed[this._level];
        }

        private void 高级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._level = 3;
            timer1.Interval = _speed[this._level];
        }

        private void 大师ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._level = 4;
            timer1.Interval = _speed[this._level];
        }
        #endregion
        private void FrmGame_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.W || e.KeyCode == Keys.Up) && _direction != Direction.Down)
            {
                _direction = Direction.Up;
                return;
            }
            if ((e.KeyCode == Keys.D || e.KeyCode == Keys.Right) && _direction != Direction.Left)
            {
                _direction = Direction.Right;
                return;
            }
            if ((e.KeyCode == Keys.S || e.KeyCode == Keys.Down) && _direction != Direction.Up)
            {
                _direction = Direction.Down;
                return;
            }
            if ((e.KeyCode == Keys.A || e.KeyCode == Keys.Left) && _direction != Direction.Right)
            {
                _direction = Direction.Left;
                return;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Movesnake();//移动蛇
            if (this.CheckDead())//游戏失败
            {
                this.timer1.Stop();//停止计时器
                this.timer1.Dispose();//释放内存
                MessageBox.Show("很遗憾，失败了，请继续努力！！！");
                dcnumbertype1 = 0;
                Start();//重新该单词游戏
            }
            if(this._isGameOver)//该单词结束
            {
                this._isGameOver = false;
                this.timer1.Stop();
                this.timer1.Dispose();
                //MessageBox.Show("恭喜过关");
                if(gametype == 0)           //第一种游戏模式
                {
                    try
                    {
                        uidInfo = uidTableList[dcnumber];           //标记已经游戏过的单词
                        uidInfo.game = 1;
                        uidBLL.Update(uidInfo, userInfo.usertable);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


                if (dccount-1 > dcnumber)         //必须还有单词才能继续游戏
                {
                    dcnumber += 1;                //第几个单词加一
                    Start();
                }
                else                                //所有单词结束
                {
                    MessageBox.Show("好厉害，已完成所有单词的游戏，请继续背单词");
                }
            }
            if(gametype == 1 && _isdcOvertype1 == true)
            {
                _isdcOvertype1 = false;
                if (uidTableList.Count - 1 > dcnumbertype1)         //必须还有单词才能继续游戏
                {
                    dcnumbertype1 += 1;                //第几个单词加一
                }
                单词ToolStripMenuItem.Text = "单词：" + dcs[dcnumbertype1];
                中文ToolStripMenuItem.Text = "中文：" + dcmeans[dcnumbertype1];
                第个ToolStripMenuItem.Text = "第" + (dcnumbertype1 + 1).ToString() + "个";
            }
        }
        
        public void Start()//开始游戏
        {
            dc = dcs[dcnumber];                                                         //当前单词
            dcfood = dcs[dcnumber];                                                     //当前食物单词字母
            dcsnake = dcs[dcnumber][0].ToString();                                      //初始蛇头字母
            if(gametype == 0)
            {
                单词ToolStripMenuItem.Text = "单词：" + dc;
            }
            else
            {
                单词ToolStripMenuItem.Text = "单词：" + dcBLL.GetModel(uidTableList[0].bookid, uidTableList[0].wordid).word; ;
            }
            中文ToolStripMenuItem.Text = "中文：" + dcmeans[dcnumber];
            第个ToolStripMenuItem.Text = "第" + (dcnumber + 1).ToString() + "个";
            

            _blocks = new List<Block>();                //实例蛇块列表
            _blocks.Insert(0, (new Block(Color.Red, _size, new Point(_width / 2, _height / 2))));  //开始游戏时的蛇
            
            _food = GetFood();                          //生成食物
            do                                          //生成假食物
            {
                _foodfalse = GetFood();
                Random r = new Random();
                int dcf = r.Next(0, 26);
                dcfalse = zm[dcf];                      //假单词
                if (dcfood.Count() > 1)                 //判断食物是否已经剩第一个字母，即开始时蛇头字母
                {
                    if (_food.Point != _foodfalse.Point && dcfalse != dcfood[1].ToString())    //判断假食物与真食物是否重叠,并且字母不同
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            } while (true);
            timer1.Interval = _speed[this._level];      //设置刷新时间，即游戏速度
            timer1.Enabled = true;                      //设置定时器可用
            timer1.Start();                             //开启定时器
        }
        private Block GetFood()//生成食物
        {
            Block food = null;                          //食物块实例
            Random r = new Random();
            bool redo = true;                           //判断是否合格的食物
            while (redo)
            {
                redo = false;
                int x = r.Next(this._width);            //食物坐标
                int y = r.Next(this._height);
                for (int i = 0; i < this._blocks.Count; i++)//是否和蛇身重叠
                {
                    Block b = this._blocks[i];
                    if (b.Point.X == x && b.Point.Y == y)
                    {
                        redo = true;
                        break;
                    }
                }
                if (redo == false)
                {
                    food = new Block(Color.Yellow, this._size, new Point(x, y));//合格实例一个食物块返回
                }
            }
            return food;
        }
        private void Movesnake()//移动一节
        {
            Point p;
            Block head = this._blocks[0];                       //取蛇头
            if(this._direction == Direction.Up)                 //各种方向
            {
                p = new Point(head.Point.X, head.Point.Y - 1);
            }
            else if(this._direction == Direction.Down)
            {
                p = new Point(head.Point.X, head.Point.Y + 1);
            }
            else if (this._direction == Direction.Left)
            {
                p = new Point(head.Point.X - 1, head.Point.Y);
            }
            else
            {
                p = new Point(head.Point.X + 1, head.Point.Y);
            }
            Block b = new Block(Color.Red, this._size, p);      //实例一个新蛇块
            if(this._food.Point != p)                           //判断蛇头坐标是否等于食物
            {
                this._blocks.RemoveAt(this._blocks.Count - 1);  //不是，去掉最后一节
            }
            else                                                //是，生成一个新的的食物与假食物
            {
                dcsnake = dcsnake.Insert(dcsnake.Count(), dcfood[1].ToString());////食物已吃，增加食物单词上该字母
                dcfood = dcfood.Remove(1,1);                //食物已被吃，去掉食物单词上该字母
                this._food = this.GetFood();
                do                                          //生成假食物
                {
                    _foodfalse = GetFood();
                    Random r = new Random();
                    int dcf = r.Next(0, 26);
                    dcfalse = zm[dcf];                      //假单词
                    if (dcfood.Count() > 1)                 //判断食物是否已经剩第一个字母，即开始时蛇头字母
                    {
                        if (_food.Point != _foodfalse.Point && dcfalse != dcfood[1].ToString())    //判断假食物与真食物是否重叠,并且字母不同
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }

                } while (true);
            }
            this._blocks.Insert(0, b);                      //增加蛇块，即前进一格
            this.Refreshgp(this._gpPalette);                //刷新画布
        }
        private bool CheckDead() //检查游戏是否结束
        {
            Block head = (this._blocks[0]);//获得蛇头
            if (head.Point.X < 0 || head.Point.Y < 0 || head.Point.X >= this._width || head.Point.Y >= this._height)//蛇头出界，游戏结束
            {
                return true;
            }
            for (int i = 1; i < this._blocks.Count; i++)//取蛇身各块
            {
                Block b = this._blocks[i];
                if (head.Point.X == b.Point.X && head.Point.Y == b.Point.Y)//蛇头与蛇身重叠，游戏结束
                {
                    return true;
                }
            }
            if (head.Point == _foodfalse.Point)//吃到假食物，游戏结束
            {
                return true;
            }
            if (gametype == 1 && dcfood.Count() >1)//游戏类型1，本单词结束
            {
                if (dcfood[1].ToString() == " " )
                {
                    if (_isdcOvertype1only == true)
                    {
                        _isdcOvertype1only = false;
                        this._isdcOvertype1 = true;
                    }
                }
                else
                {
                    _isdcOvertype1only = true;
                }   
            }
            if (_blocks.Count == dc.Count())//蛇长度等于单词长度，本单词游戏结束，进入下一个单词
            {
                this._isGameOver = true;
            }
            return false;
        }
        public void Refreshgp(Graphics gp)//更新画布
        {
            gp.Clear(this._bgColor);    //画布填底色
            this._food.Paint(gp);       //画食物
            this._foodfalse.Paint(gp);  //画假食物

            SolidBrush sbf = new SolidBrush(Color.Blue);        //画刷
            Font f = new Font("宋体", 30, FontStyle.Italic);      //字母字体
            if (dcfood.Count() > 1)//画食物字母
            {
                gp.DrawString(dcfood[1].ToString(), f, sbf, this._food.Point.X * this._size, this._food.Point.Y * this._size);//真，取第二个字母，第一个已给蛇头
                gp.DrawString(dcfalse, f, sbf, this._foodfalse.Point.X * this._size, this._foodfalse.Point.Y * this._size);//假
            }
            for (int i = 0; i < dcsnake.Count(); i++)//画蛇
            {
                Block b = this._blocks[i];//取蛇块
                b.Paint(gp);//画蛇
                gp.DrawString(dcsnake[i].ToString(), f, sbf, b.Point.X * this._size, b.Point.Y * this._size);//蛇身字母
            }
        }

        private void FrmGame_FormClosed(object sender, FormClosedEventArgs e)//窗体关闭
        {
            this.timer1.Stop();
            this.timer1.Dispose();
            pictureBox1.Dispose();
            this.Close();
        }
    }
    public enum Direction//枚举，四个方向
    {
        Left, Right, Up, Down
    }

    //食物与蛇块类
    public class Block
    {
        private Color _color;  //颜色
        private int _size;      //块大小
        private Point _point;   //坐标
        public Block(Color color,int size,Point p)
        {
            this._color = color;
            this._size = size;
            this._point = p;
        }
        public Point Point
        {
            get { return this._point; }
        }
        //绘制自身到画布
        public void Paint(Graphics g)
        {
            SolidBrush sb = new SolidBrush(_color);
            g.FillRectangle(sb, this.Point.X * this._size, this.Point.Y * this._size, this._size - 1, this._size - 1);
        }
    }
}
