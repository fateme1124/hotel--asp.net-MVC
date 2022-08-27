using hotel.Models.ViewModels;
using Hotel.Models.Context;
using Hotel.Models.Models;
using Hotel.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hotel.Controllers
{
    public class CommentController : Controller
    {
        DbHotelContext db = new DbHotelContext();
        CommentService _commentService;

        public CommentController()
        {
            _commentService = new CommentService(db);
        }
        public ActionResult ShowComments() 
        {
            var comments=_commentService.GetAll().Where(t => t.IsActive ).OrderByDescending(u=>u.CommentId).ToList();
            var commentViewModels=AutoMapperConfig.mapper.Map<IEnumerable<Comment>, List<CommentViewModel>>(comments);
            return PartialView(commentViewModels);
        }

        public ActionResult CreateComment() 
        {
            var commentViewModels = new CommentViewModel();
            return PartialView(commentViewModels);
        }

        [HttpPost]
        public ActionResult CreateComment([Bind(Include = "Name,Email,CommentText")] CommentViewModel commentViewModel)   
        {
            if(ModelState.IsValid)
            {
                Comment comment = AutoMapperConfig.mapper.Map<CommentViewModel, Comment>(commentViewModel);
                comment.RegisterDate = DateTime.Now;
                comment.IsActive = false;
                _commentService.Add(comment);
                _commentService.Save();
                return RedirectToAction("ShowComments");
            }
            return PartialView(commentViewModel);
        }
    }
}