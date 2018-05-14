using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WinFom
{

    public delegate void ValueEventHandler(object sender, ValueChangedEventArgs e);
    public class ValueChangedEventArgs : EventArgs
    {
        public int Value { get; set; }
    }
    public class LongTimeWork
    {
        public event ValueEventHandler ValueChanged;
        /// <summary>
        /// 触发事件的方法
        /// </summary>
        /// <param name="e"></param>
        void OnValueChanged(ValueChangedEventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }
        public int LongTimeMethod()
        {
            int cycle = 0;
            for (int j= 0; j < 10; j++)
            {
                
                for (int i = 0; i < 20; i++)
                {
                    Thread.Sleep(50);
                    ValueChangedEventArgs e = new ValueChangedEventArgs()
                    {
                        Value = i + 1 + cycle
                    };
                    OnValueChanged(e);
                }
                cycle += 20;
            }
            return 1;
        }
    }

}
