using Blogy.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.ValidationRules.CategoryValidator
{
    public class UpdateCategoryValidator : AbstractValidator<Category>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Lütfen kategori adını doldurunuz").MinimumLength(3).WithMessage("Lütfen kategori adını 3 karakterden uzun olacak şekilde tekrar deneyiniz.").MaximumLength(20).WithMessage("Kategori adı 20 karakterden uzun olamaz").Equal("a").WithMessage("Kategori içerisinde  'A' harfi bulunmak zorundadır.");
        }
    }
}
