using System;
using System.Windows.Forms;
using System.IO;
using canTransport;
using Uds;
using Dongzr.MidiLite;
using System.Collections.Generic;
using SecurityAccess;
using System.Text.RegularExpressions;

namespace Can_Test
{
    public partial class Form1 : Form
    {
        can_driver driver = new can_driver();
        canTrans driverTrans = new canTrans();
        SecurityKey securityDriver = new SecurityKey();
        byte[] RxMsgs = new byte[0];
        public bool testPresentCheckFlag { get; set; } //在线模式放在应用层函数中
                                                       //在主界面中会有一个1s的任务，检查传输层是否应该休眠，每隔5s的时间将3e 80 发出来

        public Form1()
        {
            InitializeComponent();
            BusParamsInit();
        }

        #region BusSetting
        private void BusParamsInit()
        {
            string[] channel = new string[0];
            channel = driver.GetChannel();
            comboBoxCanDevice.Items.Clear();
            comboBoxCanDevice.Items.AddRange(channel);//add items for comboBox
            comboBoxCanDevice.SelectedIndex = 0;//default select the first , physical driver always come first
            comboBoxCanBaudRate.SelectedIndex = 4;//default select 500K           
        }
        private void buttonBusOpenorClose_Click(object sender, EventArgs e)
        {
            if (buttonBusOpenorClose.Text == "Bus Off")
            {
                if (driver.OpenChannel(comboBoxCanDevice.SelectedIndex, comboBoxCanBaudRate.Text) == true)
                {
                    buttonBusOpenorClose.Text = "Bus On";
                    comboBoxCanBaudRate.Enabled = false;
                    comboBoxCanDevice.Enabled = false;
                    tabControl1.SelectedIndex = 1;//自动跳入诊断界面
                    trans_init();
                    driverTrans.Start();
                    label3.Text = "Bus Load:" + driver.BusLoad().ToString() + "%";
                    //使能所有发送数据的开关
                }
                else
                {
                    MessageBox.Show("打开" + comboBoxCanDevice.Text + "通道失败!");  //最好能把原因定位出来 给故障编码写入帮助文件
                }
            }
            else
            {
                driver.CloseChannel();
                buttonBusOpenorClose.Text = "Bus Off";
                comboBoxCanBaudRate.Enabled = true;
                comboBoxCanDevice.Enabled = true;
                driverTrans.Stop();
            }
        }
        #endregion

        byte[] StringToHex(string strings)
        {
            byte[] hex = new byte[0];
            try
            {
                strings = strings.Replace("0x", "");
                strings = strings.Replace("0X", "");
                strings = strings.Replace(" ", "");
                strings = Regex.Replace(strings, @"(?i)[^a-f\d\s]+", "");
                if (strings.Length % 2 != 0)
                {
                    strings += "0";
                }
                hex = new byte[strings.Length / 2];
                for (int i = 0; i < hex.Length; i++)
                {
                    hex[i] = Convert.ToByte(strings.Substring(i * 2, 2), 16);
                }
                return hex;
            }
            catch
            {
                return hex;
            }
        }

        #region Trans
        void trans_init()
        {
            /* 使用事件委托传参 */
            driverTrans.EventTxFarms += new EventHandler(
                (sender1, e1) =>
                {
                    canTrans.FarmsEventArgs args = (canTrans.FarmsEventArgs)e1;
                    EventHandler TextBoxDisplayUpdate = delegate
                    {
                        richTextBoxDisplay.AppendText(args.ToString() + "\r\n");
                    };
                    try { Invoke(TextBoxDisplayUpdate); } catch { };
                }
                );
            driverTrans.EventRxFarms += new EventHandler(
                (sender1, e1) =>
                {
                    canTrans.FarmsEventArgs args = (canTrans.FarmsEventArgs)e1;
                    EventHandler TextBoxDisplayUpdate = delegate
                    {
                        richTextBoxDisplay.AppendText(args.ToString() + "\r\n");
                    };
                    try { Invoke(TextBoxDisplayUpdate); } catch { };
                }
                );
            driverTrans.EventRxMsgs += new EventHandler(
                (sender1, e1) =>
                {
                    canTrans.RxMsgsEventArgs RxMsgs = (canTrans.RxMsgsEventArgs)e1;
                    autoResponse(StringToHex(RxMsgs.ToString()));
                }
                );
            driverTrans.EventError += new EventHandler(
                (sender1, e1) =>
                {
                    canTrans.ErrorEventArgs args = (canTrans.ErrorEventArgs)e1;
                    EventHandler TextBoxDisplayUpdate = delegate
                    {
                        richTextBoxDisplay.AppendText(args.ToString() + "\r\n");
                    };
                    try { Invoke(TextBoxDisplayUpdate); } catch { };
                }
                );
            driverTrans.CanRead += driver.ReadData;
            driverTrans.CanWrite += driver.WriteData;
        }
        #endregion

        private void autoResponse(byte[] data)
        {
            if (data[0] == 0x67)
            {
                uint seed = 0;
                byte level;
                uint key = 0;
                if (data.Length == 4)
                {
                    seed = (uint)data[2] << 8
                        | (uint)data[3];
                }
                else if (data.Length == 6)
                {
                    seed = (uint)data[2] << 24
                        | (uint)data[3] << 16
                        | (uint)data[4] << 8
                        | (uint)data[5];
                }
                level = data[1];
                if (seed != 0 && level % 2 != 0)
                {
                    key = securityDriver.UdsCallback_CalcKey(seed, level);
                    if (data.Length == 4)
                    {
                        key &= 0xFFFF;
                        driverTrans.CanSendString("27" + (level + 1).ToString("x2") + key.ToString("x4"));
                    }
                    else if (data.Length == 6)
                    {
                        driverTrans.CanSendString("27" + (level + 1).ToString("x2") + key.ToString("x8"));
                    }
                }
            }
        }

        #region Timer
        public delegate void Tick_1ms();
        public delegate void Tick_10ms();
        public delegate void Tick_100ms();
        public delegate void Tick_1s();

        public Tick_1ms mmtimer_tick_1ms;//委托实例化 
        public Tick_10ms mmtimer_tick_10ms;
        public Tick_100ms mmtimer_tick_100ms;
        public Tick_1s mmtimer_tick_1s;

        public MmTimer mmTimer;

        const int timer_interval = 1;
        //int timer_1ms_counter = 0;
        int timer_10ms_counter = 0;
        int timer_100ms_counter = 0;
        int timer_1s_counter = 0;

        private void mmTime_init()
        {
            mmTimer = new MmTimer();
            mmTimer.Mode = MmTimerMode.Periodic;
            mmTimer.Interval = timer_interval;
            mmTimer.Tick += mmTimer_tick;

            mmtimer_tick_1ms += delegate
            {

            };

            mmtimer_tick_10ms += delegate
            {

            };

            mmtimer_tick_100ms += delegate
            {

            };

            mmtimer_tick_1s += delegate
            {
                EventHandler BusLoadUpdate = delegate
                {
                    label3.Text = "Bus Load:" + driver.BusLoad().ToString() + "%";
                };
                try { Invoke(BusLoadUpdate); } catch { };
            };
        }

        void mmTimer_tick(object sender, EventArgs e)
        {
            mmtimer_tick_1ms();

            timer_10ms_counter += timer_interval;
            if (timer_10ms_counter >= 10)
            {
                timer_10ms_counter = 0;
                if (mmtimer_tick_10ms != null)
                {

                }
            }

            timer_100ms_counter += timer_interval;
            if (timer_100ms_counter >= 100)
            {
                timer_100ms_counter = 0;
                if (mmtimer_tick_100ms != null)
                {
                    mmtimer_tick_100ms();
                }
            }

            timer_1s_counter += timer_interval;
            if (timer_1s_counter >= 1000)
            {
                timer_1s_counter = 0;
                if (mmtimer_tick_1s != null)
                {
                    mmtimer_tick_1s();
                }
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            driverTrans.CanSendString("2701");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 3)
                driverTrans.CanSendString(richTextBox1.Text);
        }
    }
}