using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Table() => View();

        public IActionResult Vector() => View();

        [HttpGet]
        [HttpPost]
        public IActionResult CreateTable(TableModel ttable)
        {
            String createdTable = "";

            int i = Convert.ToInt32(Math.Pow(2, ttable.Size));
            int j = 0;
    
            while (j < i)
            {
                createdTable += Convert.ToString(j, 2).PadLeft(ttable.Size, '0') + "|" + "0\n";
                j++;
            }

            ttable.Table = createdTable;

            return View(ttable);
        }

        [HttpPost]
        [HttpGet]
        public IActionResult Min(TableModel ttable)
        {
            //>>>   MAKE A ARRAY OF CONSTATUENTS FROM DEC VECTOR
            //<------------------------------------------->
            String[] newlist = ttable.Vector.Split(' ');
            int max = Convert.ToInt32(newlist[0]);
            foreach(String a in newlist)
            {
                if (Convert.ToInt32(a) > max) max = Convert.ToInt32(a);
            }
            ttable.Size = Convert.ToString(max, 2).Length;

            for (int i = 0; i < newlist.Length; i++)
            {
                newlist[i] = Convert.ToString(Convert.ToInt32(newlist[i]), 2).PadLeft(ttable.Size, '0');
            }
            List<String> data = new List<String>();
            foreach (String a in newlist) data.Add(a);
            ttable.CalcResult = ttable.find_minterms(data);

            return View(ttable);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}