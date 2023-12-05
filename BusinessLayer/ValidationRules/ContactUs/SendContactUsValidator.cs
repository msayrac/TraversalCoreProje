using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUs
{
	public class SendContactUsValidator : AbstractValidator<SendMessageDTO>
	{

		public SendContactUsValidator()
		{
			RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Alanı Boş Geçilemez");
			RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Alanı Boş Geçilemez");

			RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
			RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Mesaj Alanı Boş Geçilemez");

			RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Konu Alanına En az 5 karakter Veri Girişi Yapmalısınız");
			RuleFor(x => x.Subject).MaximumLength(5).WithMessage("Konu Alanına En fazla 100 karakter Veri Girişi Yapmalısınız");

			RuleFor(x => x.Mail).MinimumLength(5).WithMessage("Mail Alanına En az 5 karakter Veri Girişi Yapmalısınız");
			RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Konu Alanına En fazla 100 karakter Veri Girişi Yapmalısınız");
		}


	}
}
