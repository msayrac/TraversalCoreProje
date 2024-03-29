﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICommentService:IGenericService<Comment>
	{
		List<Comment> TGetByDestinationById();
		List<Comment> TGetListCommentWithDestination();
		public List<Comment> TGetListCommentWithDestinationAndUser(int id);


	}
}
