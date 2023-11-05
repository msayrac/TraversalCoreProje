

using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Models
{
    public class UserSignInViewModel
    {

        [Required(ErrorMessage ="Lütfen kullanııc adını giriniz")]

        public string userName { get; set; }

        [Required(ErrorMessage ="Lütfen şifrenizi giriniz")]
        public string password { get; set; }


    }
}
