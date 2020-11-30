using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
 
    public class Criterion
    {

        /// <summary>
        // Signals - איתותים
        // LookingAtMirrors - התבוננות במראות
        // Parking - חניה
        // ParkingInReverse - חניה ברוורס
        // KeepDistance - שמירה על מרחק
        // Speed - מהירות
        // Bypassing - עקיפה
        // DriveInTheRightLane - נסיעה בנתיב הימני
        // PreemptiveRight - מתן זכות קדימה
        // Stopping - עצירות, האם עצר בזמן הנכון, עצירות פתאומיות
        // ObedienceToTrafficSigns - ציות לתמרורים
        // AddressingPedestrians - התייחסות להולכי רגל 
        // ALeapInTheRise - זינוק בעליה - אם מדובר ברכב ידני
        // ChangeGears - החלפת הילוכים - אם מדובר ברכב ידני
        // EngineShutdown - המנוע נכבה
        // IntegrationIntoMovement - השתלבות בתנועה
        // SkillForVehicleOperation - מיומנות לתפעול הרכב
        // AeactionTime - זמן תגובה
        /// </summary>

        public bool Signals { get; set; }
        public bool LookingAtMirrors { get; set; }
        public bool Parking { get; set; }
        public bool ParkingInReverse { get; set; }
        public bool KeepDistance { get; set; }
        public bool Speed { get; set; }
        public bool Bypassing { get; set; }
        public bool DriveInTheRightLane { get; set; }
        public bool PreemptiveRight { get; set; }
        public bool Stopping { get; set; }
        public bool ObedienceToTrafficSigns { get; set; }
        public bool AddressingPedestrians { get; set; }
        public bool ALeapInTheRise { get; set; }
        public bool ChangeGears { get; set; }
        public bool EngineShutdown { get; set; }
        public bool IntegrationIntoMovement { get; set; }
        public bool SkillForVehicleOperation { get; set; }
        public bool AeactionTime { get; set; }

        public Criterion()
        {
            Signals = true;
            LookingAtMirrors = true;
            Parking = true;
            ParkingInReverse = true;
            KeepDistance = true;
            Speed = true;
            Bypassing = true;
            DriveInTheRightLane = true;
            PreemptiveRight = true;
            Stopping = true;
            ObedienceToTrafficSigns = true;
            AddressingPedestrians = true;
            ALeapInTheRise = true;
            ChangeGears = true;
            EngineShutdown = true;
            IntegrationIntoMovement = true;
            SkillForVehicleOperation = true;
            AeactionTime = true;
        }

        public Criterion(Criterion crit)
        {
            Signals = crit.Signals;
            LookingAtMirrors = crit.LookingAtMirrors;
            Parking = crit.Parking;
            ParkingInReverse = crit.ParkingInReverse;
            KeepDistance = crit.KeepDistance;
            Speed = crit.Speed;
            Bypassing = crit.Bypassing;
            DriveInTheRightLane = crit.DriveInTheRightLane;
            PreemptiveRight = crit.PreemptiveRight;
            Stopping = crit.Stopping;
            ObedienceToTrafficSigns = crit.ObedienceToTrafficSigns;
            AddressingPedestrians = crit.AddressingPedestrians;
            ALeapInTheRise = crit.ALeapInTheRise;
            ChangeGears = crit.ChangeGears;
            EngineShutdown = crit.EngineShutdown;
            IntegrationIntoMovement = crit.IntegrationIntoMovement;
            SkillForVehicleOperation = crit.SkillForVehicleOperation;
            AeactionTime = crit.AeactionTime;
        }

        public override string ToString()
        {
            string str = "";
            str += Signals.ToString() + ",";
            str += LookingAtMirrors.ToString() + ",";
            str += Parking.ToString() + ",";
            str += ParkingInReverse.ToString() + ",";
            str += KeepDistance.ToString() + ",";
            str += Speed.ToString() + ",";
            str += Bypassing.ToString() + ",";
            str += DriveInTheRightLane.ToString() + ",";
            str += PreemptiveRight.ToString() + ",";
            str += Stopping.ToString() + ",";
            str += ObedienceToTrafficSigns.ToString() + ",";
            str += AddressingPedestrians.ToString() + ",";
            str += ALeapInTheRise.ToString() + ",";
            str += ChangeGears.ToString() + ",";
            str += EngineShutdown.ToString() + ",";
            str += IntegrationIntoMovement.ToString() + ",";
            str += SkillForVehicleOperation.ToString() + ",";
            str += AeactionTime.ToString() + ",";
            return str;
        }

        public static Criterion Parse(string str)
        {
            Criterion criterion = new Criterion();
            string[] values = str.Split(',');
            for (int i = 0; i < values.Length; i++)
            {
                if (i == 0)
                    criterion.Signals = bool.Parse(values[i]);
                if (i == 1)
                    criterion.LookingAtMirrors = bool.Parse(values[i]);
                if (i == 2)
                    criterion.Parking = bool.Parse(values[i]);
                if (i == 3)
                    criterion.ParkingInReverse = bool.Parse(values[i]);
                if (i == 4)
                    criterion.KeepDistance = bool.Parse(values[i]);
                if (i == 5)
                    criterion.Speed = bool.Parse(values[i]);
                if (i == 6)
                    criterion.Bypassing = bool.Parse(values[i]);
                if (i == 7)
                    criterion.DriveInTheRightLane = bool.Parse(values[i]);
                if (i == 8)
                    criterion.PreemptiveRight = bool.Parse(values[i]);
                if (i == 9)
                    criterion.Stopping = bool.Parse(values[i]);
                if (i == 10)
                    criterion.ObedienceToTrafficSigns = bool.Parse(values[i]);
                if (i == 11)
                    criterion.AddressingPedestrians = bool.Parse(values[i]);
                if (i == 12)
                    criterion.ALeapInTheRise = bool.Parse(values[i]);
                if (i == 13)
                    criterion.ChangeGears = bool.Parse(values[i]);
                if (i == 14)
                    criterion.EngineShutdown = bool.Parse(values[i]);
                if (i == 15)
                    criterion.IntegrationIntoMovement = bool.Parse(values[i]);
                if (i == 16)
                    criterion.SkillForVehicleOperation = bool.Parse(values[i]);
                if (i == 17)
                    criterion.AeactionTime = bool.Parse(values[i]);
            }
            return criterion;
        }
    }
    
}
