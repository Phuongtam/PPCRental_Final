using PPC.Models;
using TechTalk.SpecFlow;

namespace PPC.AcceptanceTests.Support
{
    [Binding]
    public class DatabaseTools
    {
        [BeforeScenario]
        public void CleanDatabase()
        {
            using (var db = new DemoPPCRentalEntities())
            {
                //db.OrderLines.RemoveRange(db.OrderLines);
                //db.Orders.RemoveRange(db.Orders);
                db.PROPERTY.RemoveRange(db.PROPERTY);
                db.SaveChanges();
            }
        }
    }
}
