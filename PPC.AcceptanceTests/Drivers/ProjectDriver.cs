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
        private readonly SearchResultState _context;
        //private ActionResult _result;

        public ProjectDriver(SearchResultState context)
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
                        PropertyType_ID = db.PROPERTY_TYPE.ToList().FirstOrDefault(x => x.CodeType == row["PropertyType"]).ID,
                        Status_ID = db.PROJECT_STATUS.ToList().FirstOrDefault(x => x.Status_Name == row["Status"]).ID,
                        District_ID = db.DISTRICT.ToList().FirstOrDefault(x => x.DistrictName == row["District"]).ID,
                        Street_ID = db.STREET.ToList().FirstOrDefault(x => x.StreetName == row["Street"]).ID,
                        Content = row["Content"],
                        UserID = db.USER.ToList().FirstOrDefault(x => x.FullName == row["Agency"]).ID,
                        Sale_ID = db.USER.ToList().FirstOrDefault(x => x.FullName == row["Sale"]).ID,

                    };

                    //_context.ReferenceBooks.Add(
                    //        givenProjects.Header.Contains("ID") ? row["ID"] : row["PropertyName"],
                    //        property);

                    db.PROPERTY.Add(property);
                }

                db.SaveChanges();
            }
        }


        //public void Login(string email, string pass)
        //{
        //    using (var controller = new AccountController())
        //    {
        //        _context.ActionResult = controller.Login(email,pass);
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
