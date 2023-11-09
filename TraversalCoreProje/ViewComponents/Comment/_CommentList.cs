using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace TraversalCoreProje.ViewComponents.Comment
{
	public class _CommentList:ViewComponent
	{

		CommentManager commentManager = new CommentManager(new EfCommentDal());
		public IViewComponentResult Invoke(int id)
		{
			var values = commentManager.TGetByID(id);
			
			return View(values);
		}
	}
}
