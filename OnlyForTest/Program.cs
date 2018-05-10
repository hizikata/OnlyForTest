using System;
using System.Threading;

namespace OnlyForTest
{
    delegate string BirthdayEventHandler(object sender, BirthdayEventArgs e);
    class BirthdayEventArgs : EventArgs
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public BirthdayEventArgs(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            
            //Me me = new Me("xuxu", 18);
            //BestFriend bestFriend = new BestFriend("your lover");
            //Friend friend = new Friend("your friend");
            ////订阅事件
            //me.BirthdayEvent += new BirthdayEventHandler(bestFriend.DoSomething);
            //me.BirthdayEvent += new BirthdayEventHandler(friend.DoSomething);
            //me.TimeUp();
            //Console.ReadKey();
        }


    }
    public class Test
    {
        public Test()
        {

        }
        public int Add(int x,int y)
        {
            return x + y;
        }
    }
    class Subject
    {
        public event BirthdayEventHandler BirthdayEvent;//事件声明
        public void Notify(BirthdayEventArgs e)
        {
            BirthdayEvent?.Invoke(this, e);
        }
    }
    class Me : Subject
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Me(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public void TimeUp()
        {
            BirthdayEventArgs e = new BirthdayEventArgs(this.Name, this.Age);
            this.Notify(e);//触发事件的代码
        }
    }
    class Friend
    {
        public string Name { get; set; }
        public virtual string DoSomething(object sender, BirthdayEventArgs e)
        {
            Console.WriteLine(string.Format("{1} Happy Birthday of {2},Best Reagrds From {0} !", this.Name, e.Name, e.Age));
            return "11";
        }
        public Friend(string name)
        {
            this.Name = name;
        }
    }
    class BestFriend : Friend
    {

        public BestFriend(string name) : base(name)
        {

        }
        //事件处理方法
        public override string DoSomething(object sender, BirthdayEventArgs e)
        {
            Console.WriteLine("{0}，Happy Birthday of{1},I bring a cake for you ,{2}", e.Name, e.Age, this.Name);
            return "11";
        }
    }

}