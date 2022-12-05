using MiniProjectApp.DataModels;
using MiniProjectApp.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace MiniProjectApp.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            var Login = new LoginView();
            return View(Login);
        }

        [HttpPost]
        public ActionResult Login(LoginView postedData)
        {
            if (ModelState.IsValid)
            {
                var context = new DOTNETEntities();
                var user = context.UserTables.Where(cust => cust.UserName == postedData.UserName && cust.password == postedData.password).FirstOrDefault();
                if(user!=null)
                {
                    Session["UserData"] = user;
                }
                else if (user == null)
                {
                    ModelState.AddModelError("Login Failure ","Login failed for the user");
                    return View(postedData);
                }
                
                FormsAuthentication.SetAuthCookie(postedData.UserName, false);
                FormsAuthentication.RedirectFromLoginPage(postedData.password, false);
                return View(postedData);
            }
            else
            {
                return View(postedData);
            }
        }
        public ActionResult Register()
        {
            var UserDetails = new UserDetailsVN();
            return View(UserDetails);
        }
       
        [HttpPost]
        public ActionResult Register(UserDetailsVN user)
        {
            if (ModelState.IsValid && isValidUser(user.UserName))
            {
                var _context = new DOTNETEntities();
                var UserTableRow = new UserTable
                {
                    UserName=user.UserName,
                    Name=user.Name,
                    Address=user.Address,
                    mobileNo=user.mobileNo,
                    email=user.email,
                    password=user.password
                };
                _context.UserTables.Add(UserTableRow);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Failure ","UserName already exists");
                return View();
            }
        }
        public bool isValidUser(string UserName)
        {
            var _context = new DOTNETEntities();
            var selected = _context.UserTables.SingleOrDefault(user => user.UserName == UserName);
            return selected == null ? true : false;
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}
