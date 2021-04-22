using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tp3_chats.Models;

namespace tp3_chats.Controllers
{
    public class ChatController : Controller
    {
        private static List<Chat> chats = Chat.GetMeuteDeChats();

        // GET: Chat
        public ActionResult Index()
        {
            return View(chats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            return View(chats.FirstOrDefault(c => c.Id == id));
        }

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            return View(chats.FirstOrDefault(c => c.Id == id));
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                chats.Remove(chats.FirstOrDefault(c => c.Id == id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
