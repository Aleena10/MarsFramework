using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint2")]
        class User : Global.Base
        {
            
            [Test]
           [System.Obsolete]
            public void EnterShareSkill()
       {
                ShareSkill skill = new ShareSkill();
                skill.EnterShareSkill();

            }

            

            [Test]
            [System.Obsolete]
           public void EditSkillTest()
           {
                ManageListings skill = new ManageListings();
                skill.EditManageListings();

           }

            [Test]
            [System.Obsolete]
            public void DeleteSkillTest()
            {
                ManageListings mld = new ManageListings();
                mld.DeleteShareSkill("Yes");

            }



        }
    }
}