using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FizzBuzz.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CalculateFizzBuzz(string inputValue)
        {
            string output = string.Empty;
            try
            {          
                string[] input = inputValue.Split(new string[] { "," }, StringSplitOptions.None);
                for (int i = 0; i < input.Length; i++)
                {
                    //check if input is decimal
                    if (input[i].Contains("."))
                    {
                        decimal dNum = 0;
                        if (decimal.TryParse(input[i], out dNum))
                            output += Calculate(dNum);
                        else
                            output += "Invalid Item <br />";
                    }
                    //check if input is integer
                    else
                    {
                        if (int.TryParse(input[i], out int iNum))
                            output += Calculate(iNum);
                        else
                            output += "Invalid Item <br />";
                    }                   
                }         
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }
            return Json(new { outputTxt = output }, JsonRequestBehavior.AllowGet);
        }

        public string Calculate(dynamic value)
        {
            string msg = string.Empty;
            //check if input is multiple of 3 and 5
            if (value % 15 == 0)
                msg += "FizzBuzz <br /> ";
            //check if input is multiple of 3
            else if (value % 3 == 0)
                msg += "Fizz <br /> ";
            //check if input is multiple of 5
            else if (value % 5 == 0)
                msg += "Buzz <br /> ";
            else
                msg += "Divided " + value + " by 3 <br /> Divided " + value + " by 5 <br />";

            return msg;
        }
    }
}