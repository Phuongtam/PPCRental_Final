using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PPC.Models;
using PPC.Controllers;
using TechTalk.SpecFlow;
using PPC.AcceptanceTests.Common;
using PPC.AcceptanceTests.Support;
using PPC.AcceptanceTests;
using PPC.AcceptanceTests.Drivers;
using FluentAssertions;

namespace PPC.AcceptanceTests.Drivers
{
    public class ProjectDriver
    {
        private readonly CatalogContext _context;
        private ActionResult _result;

        public ProjectDriver(CatalogContext context)
        {
            _context = context;
        }

        public void InsertProjecttoDB(Table givenProjects)
        {
            using (var db = new DemoPPCRentalEntities())
            {
                foreach (var row in givenProjects.Rows)
                {
                    var property = new PROPERTY
                    {
                        PropertyName = row["PropertyName"],
                        PropertyType_ID = int.Parse(row["PropertyType_ID"]),
                        Status_ID = int.Parse(row["Status_ID"]),
                        District_ID = int.Parse(row["District_ID"]),
                        Street_ID = int.Parse(row["Street_ID"]),
                        Content = row["Content"]
                        // PropertyType_ID = db.PROPERTY_TYPE.FirstOrDefault(d => d.ID = int.Parse((row["PropertyType"]).ID)),

                    };

                    _context.ReferenceBooks.Add(
                            givenProjects.Header.Contains("ID") ? row["ID"] : row["PropertyName"],
                            property);

                    db.PROPERTY.Add(property);
                }

                db.SaveChanges();
            }
        }
       

        //public void Navigate(string mail, string pass)
        //{
        //    using (var controller = new HomeController())
        //    {
        //        _result.ActionResult = controller.Login(mail,pass);
        //    }
        //}


        //public void ShowList(Table expectednameList)
        //{
        //    //Arrange
        //    var expected = expectednameList.Rows.Select(x => x["PropertyName"]);

        //    var ShownName = _result.ActionResult.Model<IEnumerable<PROPERTY>>();

        //    //Assert
        //    PropertyAssertions.HomeScreenShouldShow(ShownName, expectednameList);
        //}
    }
}
