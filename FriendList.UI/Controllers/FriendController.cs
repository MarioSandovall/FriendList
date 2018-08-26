using FriendList.Access.Dtos;
using FriendList.Access.Repository;
using System;
using System.Net;
using System.Web.Mvc;

namespace FriendList.UI.Controllers
{
    public class FriendController : Controller
    {

        private readonly FriendRepository _friendRepository;

        public FriendController()
        {
            _friendRepository = new FriendRepository();
        }

        [HttpGet]
        public ActionResult GetAllFriend()
        {
            try
            {
                var friends = _friendRepository.GetAll();
                return Json(friends, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [HttpPost]
        public ActionResult AddFriend(FriendDto friend)
        {
            try
            {
                _friendRepository.Add(friend);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        public ActionResult RemoveFriend(int friendId)
        {
            try
            {
                _friendRepository.Remove(friendId);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public ActionResult UpdateFriend(FriendDto friend)
        {
            try
            {
                _friendRepository.Update(friend);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}