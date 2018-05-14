using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WpfApp2;
using WpfApp2.ViewModel;
using Excel = Microsoft.Office.Interop.Excel;

namespace WinFom
{
    public partial class Form1 : Form
    {
        LongTimeWork work = new LongTimeWork();
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "form1";
            this.Tag = "我是主窗体";

        }

        private void 销售ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.MdiChildren.Length.ToString());
        }

        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void 进度条测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //LongTimeWork work = new LongTimeWork();
            //work.ValueChanged += Work_ValueChanged;
            //Action handler = new Action(work.LongTimeMethod);
            //handler.BeginInvoke(new AsyncCallback(this.AsynCallBack), handler);

        }
        //void AsynCallBack(IAsyncResult ar)
        //{
        //    Action handler = ar.AsyncState as Action;
        //    handler.EndInvoke(ar);
        //    MessageBox.Show("任务完成", "系统提示");

        //}
        //void Work_ValueChanged(object sender, ValueEventArgs e)
        //{
        //    MethodInvoker invoker =
        //        () => this.progressBar1.Value = e.Value;
        //    if (progressBar1.InvokeRequired)
        //    {
        //        this.progressBar1.Invoke(invoker);
        //    }
        //    else
        //    {
        //        invoker();
        //    }
        //    //this.label1.Text = e.Value.ToString();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            
            this.progressBar1.Maximum = 200;
            work.ValueChanged += ValueChangedMethod;


            //异步执行(方法1)
            //Action handler =() =>work.LongTimeMethod();
            //handler.BeginInvoke(new AsyncCallback(this.AsyncCallback), handler);

            //异步执行(方法2)


        }
        async void ExecuteAsync()
        {
            int a= await Task.
            
        }
        void AsyncCallback(IAsyncResult ar)
        {
            Action handler = ar.AsyncState as Action;
            handler.EndInvoke(ar);
            MessageBox.Show("进度完成", "系统提示");
            MethodInvoker invoker =
                () =>
                {
                    this.button1.Enabled = true;
                    this.progressBar1.Value = 0;
                };

            if (this.InvokeRequired)
            {
                this.Invoke(invoker);
            }
            else
            {
                invoker();
            }
        }
        /// <summary>
        /// ValueChanged事件的注册方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ValueChangedMethod(object sender, ValueChangedEventArgs e)
        {
            MethodInvoker invoker = () =>
            {
                this.progressBar1.Value = e.Value;
                this.label1.Text = string.Format(@"当前进度：{0}/{1}", e.Value.ToString(), this.progressBar1.Maximum);
            };
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(invoker);
            }
            else
            {
                invoker();
            }
        }
    }
}
