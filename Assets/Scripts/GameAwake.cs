using System.Collections.Generic;
using DinoHitMaster.DataSet;
using DinoHitMaster.Interface;
using DinoHitMaster.Controllers;


namespace DinoHitMaster
{
    class GameAwake
    {
        public void AwakeGame(Data data, MainControllers mainControllers)
        {
            List<IAwakeble> AwakeObjectList = new List<IAwakeble>();

            AddInMainController(AwakeObjectList, mainControllers);

            mainControllers.Awakeble();
        }

        private void AddInMainController(List<IAwakeble> AwakeObjectList, MainControllers mainControllers)
        {
            foreach (IAwakeble AwakeObject in AwakeObjectList)
            {
                mainControllers.Add(AwakeObject);
            }
        }
    }
}
