using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UI.Test.Script
{
    public class Test1View : View<Test1Controller>
    {



        public void GoToTest2()
        {
            UIManager.Ins.Next(new Test2Controller());
        }




        public void Test2Win()
        {
            Test2Controller test2Controller = new Test2Controller();
            test2Controller.type = MoudleType.window;
            UIManager.Ins.Next(test2Controller);
        }

    }
}
