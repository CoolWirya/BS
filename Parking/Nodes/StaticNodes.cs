using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
    public class JParkingStaticNodes : JStaticNode
    {
        public static JNode _Showshift()
        {

            JNode Node = new JNode(0, "Parking.JDayProfile");
            Node.Name = "JDayProfiles";
            //Node.Icone = 4;
            Node.Hint = "JDayProfiles";
            JAction Ac = new JAction("JShift", " Parking.JDayProfiles.ListView", null, null, true);

            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            Node.ChildsAction = new JAction("JShift", "RealEstate.jMarkets.GetMarketsNode", new object[] { Ac }, null, true);
            return Node;
        }
        public static JNode _ShowUpdate()
        {

            JNode Node = new JNode(0, "Parking.JParkingConfigures");
            Node.Name = "JParkingConfigure";
            //Node.Icone = 4;
            Node.Hint = "JParkingConfigure";
            JAction Ac = new JAction("JParkingConfigure", " Parking.JParkingConfigures.ListView", null, null, true);

            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            return Node;
        }
        public static JNode _ShowGate()
        {

            JNode Node = new JNode(0, "Parking.JGate");
            Node.Name = "JGate";
            //Node.Icone = 4;
            Node.Hint = "JGate";

            JAction Ac = new JAction("JGate", "Parking.JGates.ListView", null, null, true);

            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            Node.ChildsAction = new JAction("JGate", "RealEstate.jMarkets.GetMarketsNode", new object[] { Ac }, null, true);
            return Node;
        }

        public static JNode _ShowDamge()
        {

            JNode Node = new JNode(0, "Parking.JDamge");
            Node.Name = "JDamge";
            //Node.Icone = 4;
            Node.Hint = "JDamge";

            JAction Ac = new JAction("JDamges", "Parking.JDamges.ListView", null, null, true);

            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            Node.ChildsAction = new JAction("JDamges", "RealEstate.jMarkets.GetMarketsNode", new object[] { Ac }, null, true);

            return Node;
        }

        public static JNode _ShowTraficForm()
        {
            JNode Node = new JNode(0, "Parking.JTraficForm");
            Node.Name = "JTraficForm";
            //Node.Icone = 4;
            Node.Hint = "JTraficForm";

            JAction Ac = new JAction("Traffic", "Parking.JTraficForms.ListView", null, null, false);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            return Node;
        }

        public static JNode _ShowTraficFormNode()
        {
            JNode Node = new JNode(0, "Parking.JTraficForm");
            Node.Name = "JTraficForm";
            //Node.Icone = 4;
            Node.Hint = "JTraficForm";

            JAction Ac = new JAction("Traffic", "Parking.JTraficForm.ShowForm", null, null, false);
            //Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            return Node;
        }
       
 
        public static JNode _ShowBaseShift()
        {
            JNode Node = new JNode(0, "Parking.JTraffic");
            Node.Name = "JBaseShifts";
            //Node.Icone = 4;
            Node.Hint = "JBaseShifts";

            JAction Ac = new JAction("DefShift", "Parking.JBaseShifts.ListView", null, null, true);

            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            Node.ChildsAction = new JAction("DefShift", "RealEstate.jMarkets.GetMarketsNode", new object[] { Ac }, null, true);
            return Node;
        }

        public static JNode _ShowTypeDamge()
        {
            JNode Node = new JNode(0, "Parking.JTypeDameges");
            Node.Name = "JTypeDameges";
            //Node.Icone = 4;
            Node.Hint = "JTypeDameges";

            JAction Ac = new JAction("JTypeDameges", "Parking.JTypeDameges.ListView", null, null, true);

            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;

            return Node;
        }

        public static JNode _CarNode()
        {
            JNode Node = new JNode(0, "Parking.JCar");
            Node.Name = "JCar";
            //Node.Icone = 4;
            Node.Hint = "JCar";

            JAction Ac = new JAction("Car", "Parking.JCars.ListView", null, null, true);

            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;

            return Node;
        }

        public static JNode _CardParkingNode()
        {
            JNode Node = new JNode(0, "Parking.JCardParking");
            Node.Name = "JCardParking";
            //Node.Icone = 4;
            Node.Hint = "JCardParking";

            JAction Ac = new JAction("CardParking", "Parking.JCardParkings.ListView", null, null, true);

            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            Node.ChildsAction = new JAction("JCardParking", "RealEstate.jMarkets.GetMarketsNode", new object[] { Ac }, null, true);
            return Node;
        }

        public static JNode _CardParkingCNode()
        {
            JNode Node = new JNode(0, "Parking.JCardParkingC");
            Node.Name = "JCardParkingC";
            //Node.Icone = 4;
            Node.Hint = "JCardParkingC";

            JAction Ac = new JAction("CardParkingC", "Parking.JCardParkings.ListViewC", null, null, true);

            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            Node.ChildsAction = new JAction("JCardParkingC", "RealEstate.jMarkets.GetMarketsNode", new object[] { Ac }, null, true);
            return Node;
        }

        public static JNode _GroupParking()
        {
            JNode Node = new JNode(0, "Parking.JGroupCard");
            Node.Name = "JGroupCard";
            //Node.Icone = 4;
            Node.Hint = "JGroupCard";

            JAction Ac = new JAction("GroupCard", "Parking.JGroupCards.ListView", null, null, true);

            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            Node.ChildsAction = new JAction("JGroupCard", "RealEstate.jMarkets.GetMarketsNode", new object[] { Ac }, null, true);
            return Node;
        }

        public static JNode _BaseDefine()
        {
            JNode Node = new JNode(0, "Parking.JREsBaseDefine");
            Node.Name = "BaseDefine";
            //Node.Icone = 4;
            Node.Hint = "BaseDefine";

            JAction Ac = new JAction("BaseDefine", "Parking.JPrkBaseDefine.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("BaseDefine", "Parking.JPrkBaseDefine.TreeView");
            Node.ChildsAction = CAc;
            return Node;
        }
        public static JNode _PublicDefine()
        {

            JNode Node = new JNode(0, "Parking.JParkingpublicDefine");
            Node.Name = "JpublicDefine";
            //Node.Icone = 4;
            Node.Hint = "JpublicDefine";

            JAction Ac = new JAction("JpublicDefine", "Parking.JParkingpublicDefine.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("JpublicDefine", "Parking.JParkingpublicDefine.TreeView");
            Node.ChildsAction = CAc;
            return Node;
        }
        public static JNode _Information()
        {

            JNode Node = new JNode(0, "Parking.JParkingInformation");
            Node.Name = "JParkingInformation";
            //Node.Icone = 4;
            Node.Hint = "JParkingInformation";

            JAction Ac = new JAction("JParkingInformation", "Parking.JParkingInformation.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("JParkingInformation", "Parking.JParkingInformation.TreeView");
            Node.ChildsAction = CAc;
            return Node;
        }
        public static JNode _Calculate()
        {

            JNode Node = new JNode(0, "Parking.JCalculate");
            Node.Name = "JCalculate";
            //Node.Icone = 4;
            Node.Hint = "JCalculate";

            JAction Ac = new JAction("JParkingInformation", "Parking.JCalculate.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("JParkingInformation", "Parking.JCalculate.TreeView");
            Node.ChildsAction = CAc;
            return Node;
        }
       
        public static JNode _ControlStatus()
        {
            JNode Node = new JNode(0, "Parking.jControlStatuss");
            Node.Name = "ControlStatus";
            //Node.Icone = 4;
            Node.Hint = "ControlStatus";

            JAction Ac = new JAction("ControlStatus", "Parking.jControlStatuss.ListView", null, null, true);

            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;

            return Node;
        }
        public static JNode _ColorCar()
        {

            JNode Node = new JNode(0, "Parking.JColorCars");
            Node.Name = "ColorCar";
            //Node.Icone = 4;
            Node.Hint = "ColorCar";

            JAction Ac = new JAction("CarColor", "Parking.JColorCars.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;

        }
        public static JNode _JTypeCar()
        {

            JNode Node = new JNode(0, "Parking.JTypeCars");
            Node.Name = "TypeCar";
            //Node.Icone = 4;
            Node.Hint = "TypeCar";

            JAction Ac = new JAction("TypeCar", "Parking.JTypeCars.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;

        }

        public static JNode _Status()
        {

            JNode Node = new JNode(0, "Parking.JStatus");
            Node.Name = "JStatus";
            //Node.Icone = 4;

            Node.Hint = "جهت مشخص شدن وضعیت";
            JAction Ac = new JAction("Status", "Parking.JStatuss.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        public static JNode _DueToInactivity()
        {

            JNode Node = new JNode(0, "Parking.JDueToInactivity");
            Node.Name = "JDueToInactivity";
            //Node.Icone = 4;

            Node.Hint = "جهت مشخص شدن علت غیر فعال بودن";
            JAction Ac = new JAction("DueToInactivity", "Parking.JDueToInactivitys.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

       
    }
}
