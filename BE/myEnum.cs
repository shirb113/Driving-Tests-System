using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// Gender  = מין
    /// Female = אישה, Male = גבר 
    /// </summary>
    public enum Gender { Male, Female };
    /// <summary>
    /// TypeOfCar = סוג הרכב
    /// PrivateCar = רכב פרטי, TwoWheeledVehicles = רכב דו גלגלי, MediumTruck = משאית בינונית,
    /// HeavyTruck = משאית כבדה, CarService = רכב שירות כגון אוטובוס או מונית
    /// SecurityVehicle = רכב ביטחון
    /// </summary>
    public enum TypeOfCar { PrivateCar, TwoWheeledVehicles, MediumTruck, HeavyTruck, CarService, SecurityVehicle };
    /// <summary>
    /// TypeOfGearbox = סוג תיבת הילוכים
    /// Manual = ידני
    /// Automatic = אוטומטי
    /// </summary>
    public enum TypeOfGearbox { Manual, Automatic }
    /// <summary>
    /// PassOrFail = האם עבר את המבחן
    /// Pass = עבר 
    /// Fail = נכשל
    /// Nun = אין תוצאה מכיוון שהמבחן עוד לא התרחש
    /// </summary>
    public enum PassOrFail {Nun, Pass, Fail }
    /// <summary>
    /// FamilyStatus = מצב משפחתי
    /// Single = רווק\ה
    /// Married = נשוי\אה
    /// Divorcee = גרוש\ה
    /// Widower = אלמן\נה
    /// </summary>
    public enum FamilyStatus { Single, Married, Divorcee, Widower }
   
}
