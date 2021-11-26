using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Test.Script
{
    public class Test2View : View<Test2Controller>
    {


        public void GoToTest1()
        {
            UIManager.Ins.Next(new Test1Controller());
        }




        public void Test1Win()
        {
            Test1Controller test2Controller = new Test1Controller();
            test2Controller.type = MoudleType.window;
            UIManager.Ins.Next(test2Controller);
        }
    }
}
